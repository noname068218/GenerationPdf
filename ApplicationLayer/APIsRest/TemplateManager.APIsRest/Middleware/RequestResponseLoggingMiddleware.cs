using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraceActivityAPIsRest.DomainObject;

namespace Middleware.APIsRest
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            //First, get the incoming request
            var request = await FormatRequest(context.Request);
            DateTime dataInput = DateTime.Now;
            TimeSpan starttime = dataInput.TimeOfDay;

            String userAgent = context.Request.Headers["User-Agent"].ToString();
            String requestType = context.Request.Method.ToString();
            String scheme = context.Request.Scheme;
            String host = context.Request.Host.ToString();
            String path = context.Request.Path.ToString();
            String queryString = context.Request.QueryString.ToString();
            String? remoteIpAddress = context.Connection.RemoteIpAddress?.ToString();

            remoteIpAddress = String.IsNullOrEmpty(remoteIpAddress) ? String.Empty : remoteIpAddress;

            //Copy a pointer to the original response body stream
            var originalBodyStream = context.Response.Body;

            //Create a new memory stream...
            using var responseBody = new MemoryStream();
            //...and use that for the temporary response body
            context.Response.Body = responseBody;

            //Continue down the Middleware pipeline, eventually returning to this class
            await _next(context);

            //Format the response from the server
            var response = await FormatResponse(context.Response);

            // CalculatePerformance
            decimal duration = CalculatePerformance(starttime);

            //TODO: Save log to chosen datastore
            ClientMessage msg = new();
            TraceAPIsRest traceAPIsRest = new(requestType, request, response, scheme, host, path, queryString, duration, remoteIpAddress, userAgent, dataInput,false, PathAPIsRestToBeTrace.PathToBeTrace,ref msg);

            //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
            await responseBody.CopyToAsync(originalBodyStream);
        }

        private static async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;

            //This line allows us to set the reader for the request back at the beginning of its stream.
            request.EnableBuffering();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length)).ConfigureAwait(false);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            // reset the stream position to 0, which is allowed because of EnableBuffering()
            request.Body.Seek(0, SeekOrigin.Begin);

            return $"{bodyAsText}";
        }

        private static async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return $"{text}";
        }

        private static decimal CalculatePerformance(TimeSpan starttime)
        {
            try
            {

                TimeSpan endtime = DateTime.Now.TimeOfDay;

                double secs = endtime.TotalSeconds - starttime.TotalSeconds;
                return (decimal)secs;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
