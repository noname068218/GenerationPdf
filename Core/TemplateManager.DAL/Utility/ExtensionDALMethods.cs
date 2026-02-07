using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TemplateManager.DAL.Application;
using System.Xml;
using System.Reflection;
using System.Net;
using Epy.Standard.ef;

namespace TemplateManager.DAL
{
    internal static class ExtensionDALMethods
    {

        #region STATIC

        #region EVENTS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region FIELDS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
        ///// <summary>
        ///// Ritorna un'istanza del service relativo all'entità a livello Object Model.
        ///// </summary>
        ///// <returns>istanza del service relativo all'entità a livello Object Model.</returns>
        internal static IServiceLocatorFactory GetServiceLocatore()
        {
            return ServiceLocatorFactory.Instance;
        }

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region EVENT HANDLER
        #region PUBLIC
        #endregion
        #region PRIVATE
        #endregion
        #endregion

        #region METHODS
        #region PUBLIC

        #region Reflection

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> IndexRange<TSource>(
                this IList<TSource> source,
                int fromIndex,
                int toIndex)
        {
            int currIndex = fromIndex;
            while (currIndex <= toIndex)
            {
                yield return source[currIndex];
                currIndex++;
            }
        }

        /// <summary>
        /// Restituisce il nome di una proprieta di un object appartenente nella classe base <see cref="System.Object"/>
        /// </summary>
        /// <typeparam name="TPropertySource"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetPropertyName<TPropertySource>
        (Expression<Func<TPropertySource, object>> expression)
        {
            var lambda = expression as LambdaExpression;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = lambda.Body as UnaryExpression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambda.Body as MemberExpression;
            }

            System.Diagnostics.Debug.Assert(memberExpression != null,
               "Please provide a lambda expression like 'n => n.PropertyName'");

            if (memberExpression != null)
            {
                var propertyInfo = memberExpression.Member as System.Reflection.PropertyInfo;

                return propertyInfo.Name;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atype"></param>
        /// <returns></returns>
        public static string[] GetListProperties(object atype)
        {
            if (atype == null) return Array.Empty<string>();

            Type t = atype.GetType();

            PropertyInfo[] props = t.GetProperties();

            List<string> propNames = new();

            foreach (PropertyInfo prp in props)
            {
                propNames.Add(prp.Name);
            }

            return propNames.ToArray();
        }


        /// <summary>
        /// Restituisce il Valore di una proprieta di un object appartenente nella classe base <see cref="System.Object"/>
        /// </summary>
        /// <typeparam name="TPropertySource"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static object GetPropertyValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }


        #endregion

        #region Validators
        #endregion

        #region EncodeDecode64

        /// <summary>
        /// Dato un array di byte (string) ne decodifica il contenuto restituendolo in string
        /// </summary>
        /// <param name="item">base64 string</param>
        /// <returns>string</returns>
        public static string Base64Decode(string item)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(item);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Data una stringa lo converte in un base64 string
        /// </summary>
        /// <param name="item">string</param>
        /// <returns>base64 string</returns>
        public static string Base64Encode(string item)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(item);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        #endregion

        #region Builders

        #endregion

        #region AreaPA

        #region Xml Estension

        /// <summary>
        /// Converte una stringa xml in un documento xml
        /// </summary>
        /// <param name="xml">xml string</param>
        /// <returns>xml document</returns>
        public static XmlDocument XmlStringToXmlDocument(string xml)
        {
            XmlDocument output = new();
            output.LoadXml(xml);
            return output;
        }


        #endregion

        #region Check Web Service

        public static bool CheckWebServiceUpAndRunning(string url)
        {
            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)myRequest.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #endregion

        public static bool IsNullOrMinValue(this DateTimeOffset? dateTime) => !dateTime.HasValue || dateTime.Value <= DateTimeOffset.MinValue;

        public static bool IsNullOrMinValue(this DateTime? dateTime) => !dateTime.HasValue || dateTime.Value <= DateTime.MinValue;

        internal static bool HasNonZeroValue(this int? value)
        {
            if (value.HasValue)
                return value > 0;
            else
                return false;
        }

        public static bool IsValidEmailAddress(this string emailaddress)
        {
            try
            {
                System.Net.Mail.MailAddress m = new(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Marca <paramref name="destination"/> come cancellato
        /// impostando le property:
        /// <para>- IdUtenteCancellazione</para>
        /// <para>- DataCancellazione</para>
        /// <para>- State</para>
        /// <para>con lo stesso valore di <paramref name="source"/></para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="destination"></param>
        /// <param name="source">istanza cancellata, deve avere State == State.Deleted</param>
        /// <exception cref="System.ArgumentNullException">source, destination</exception>
        public static void ApplyChanges<T>(this EFDAO<T> destination, State state)
            where T : IObjectWithState
        {
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            switch (state)
            {
                case State.Added:
                case State.RelationAdded:
                case State.Unchanged:
                    destination.IdUserCreation = Application.ApplicationContext.IdUtente;
                    destination.DateCreation = DateTimeOffset.UtcNow;
                    break;
                case State.Modified:
                    destination.IdUserChange = Application.ApplicationContext.IdUtente;
                    destination.DateChange = DateTimeOffset.UtcNow;
                    break;
                case State.Deleted:
                case State.RelationDeleted:
                    destination.IdUserDeleting = Application.ApplicationContext.IdUtente;
                    destination.DateDeleting = DateTimeOffset.UtcNow;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Determina se un oggetto è not null e ha tipo T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">Oggetto.</param>
        /// <param name="parameterName">Nome del parametro <paramref name="item"/> da restituire nei messaggi associati alle eccezioni.</param>
        /// <param name="nullMsg">Messaggio se <paramref name="item" /> è null.</param>
        /// <param name="wrongTypeMessage">Messaggio se <paramref name="item" /> non ha tipo T.</param>
        /// <returns>
        ///   <c>true</c> se <paramref name="item" /> non è null e ha tipo T; un'eccezione altrimenti.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static bool IsNotNullAndHasType<T>(
            this Object item,
            String parameterName = null,
            String nullMsg = null,
            String wrongTypeMessage = null)
        {
            if (String.IsNullOrWhiteSpace(parameterName))
                parameterName = "item";

            if (String.IsNullOrWhiteSpace(nullMsg))
                nullMsg = parameterName;

            if (String.IsNullOrWhiteSpace(wrongTypeMessage))
                wrongTypeMessage = parameterName + " non è di tipo " + typeof(T).AssemblyQualifiedName;

            if (item == null)
                throw new ArgumentNullException(nullMsg);

            if (!(item is T))
                throw new ArgumentException(wrongTypeMessage);

            return true;
        }

        #endregion
        #region NOT PUBLIC
        /// <summary>
        /// Data una lista <paramref name="sequence"/> ritorna le coppie di elementi in <paramref name="sequence"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">lista</param>
        /// <returns>coppie di elementi in <paramref name="sequence"/></returns>
        internal static IEnumerable<Tuple<T, T>> AsPairs<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            bool isFirst = true;
            T first = default;

            foreach (var item in sequence)
            {
                if (isFirst)
                {
                    first = item;
                    isFirst = false;
                }
                else
                {
                    isFirst = true;
                    yield return new Tuple<T, T>(first, item);
                }
            }
        }
        #endregion
        #endregion

        #endregion

    }
}
