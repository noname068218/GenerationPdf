using System;
using System.Text.RegularExpressions;

namespace TemplateManager.APIs.DomainService
{
    /// <summary>
    /// Simple helper to convert Base64 string to byte array for signature images.
    /// Handles various Base64 formats including Data URLs and raw Base64 strings.
    /// </summary>
    public static class Base64Helper
    {
        /// <summary>
        /// Converts Base64 string to byte array.
        /// Supports Data URL format (data:image/png;base64,...) and raw Base64 strings.
        /// Automatically removes whitespace and newlines from Base64 content.
        /// </summary>
        /// <param name="base64">Base64 string (can be Data URL or raw Base64)</param>
        /// <returns>Byte array if conversion succeeds, null otherwise</returns>
        public static byte[]? ToBytes(string? base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
                return null;

            try
            {
               
                var cleanBase64 = base64.Trim();
                if (cleanBase64.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
                {
                    var base64Index = cleanBase64.IndexOf("base64,", StringComparison.OrdinalIgnoreCase);
                    if (base64Index >= 0)
                    {
                        cleanBase64 = cleanBase64.Substring(base64Index + "base64,".Length).Trim();
                    }
                }


                cleanBase64 = Regex.Replace(cleanBase64, @"\s+", "");

                if (string.IsNullOrEmpty(cleanBase64))
                    return null;

          
                var padding = cleanBase64.Length % 4;
                if (padding != 0)
                {
                    cleanBase64 += new string('=', 4 - padding);
                }

                return Convert.FromBase64String(cleanBase64);
            }
            catch (FormatException)
            {
  
                return null;
            }
            catch (Exception ex)
            {
              
                return null;
            }
        }
    }
}