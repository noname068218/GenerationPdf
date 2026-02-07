using Microsoft.Extensions.Configuration;
using TemplateManager.APIs.Application;
using TemplateManager.Common.ObjectModel;
using System.Linq.Expressions;
using TemplateManager.DAL.Application;

namespace TemplateManager.APIs
{
    public static class ExtensionMethodsAPIs
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        public static string TokenAccess { get => $"NmV0d3ExaXpzVVZrSFJYRVhwdFBmYlBQYkwyQjdSYXR0REI4TDJOOVFVczVjNk44WUJkVS9vbUZXTGNWZDhwakU4T2ozeW1pUDhJYnZrNUlGakg2SXdSejA0Q2RBM2JxaXpaSlZXUjdUdTJYQ2doU2FqWkdmZk5vcjlpT3dEY2FTbUIzU0JyMGxWdWdXS1ZUVSt6TGJPMDNOeExZbE5vTWczMGZOeTRvVnR2bnRiYU5MWkZtK0VpUXpQR1A5Wm85N01Xa3F4VnVhcVFlU1NTSUVnUXA2U1lVUGNRTk1XUHROU0VLWDBlMVJoNStUL2FvdFdkb1UxMDNlMnQ3SzdabVpoMUc2NXltdGZxdWhwcFNPUHFjRmVSK3dqSkhscmp5Y283TUlBMW1ZMGZ1KzhTMC84TGNZdEtwdTZ1aDZvUDdQaTc5cWViTUVrbHhzd3UzaWd3ZUhTTmdMS1Mwand6NFZjanplR210cHFqMWtaek9QZHFJNndtc3J0RkxaS0NGaHJNZ2JYYVJzNFJKNWFySDQwYUNoOTNmL0djZ0JZT3lHL0NxV1pCUnBnUzV3QXFyNjMvNEJkZkhlaS9wUnlrZnI3cWxOdHNOZERNc2o0c09JQ1B1STBRSVphcHFVdmptZ015QjR4akxnWGFKeWcrYTZGbWM2ZHV6UEwvejJsL2tRd29mci8zYS9hQXJGQUxqOU9yMmtuckJjZDJrZEFoa3R5eHBBVW93b2E0YTZLc3lHL0V2L014bytiYmJxOUhHdm45Ly9hOUZWRlFBbFUrNkVhQVJwSWVSTDkzeEdLUStWWGNhNktITng0MjRTREtWL3cvUkZqMFpORmFSTWNTbkhQUjhSN3hqKzY5WmFTOXIvK2oxOGErRnpQODlkUVJ1d2RZK1VaVjUwTHozSzlPMG5DVWxxVFRndERDSGhhTkFYZ3hLS2dJT3JseWI0Z09XWGx2YStNb1Z1Ym9uK1Z3OWU2N2pESUprNndhaGY1UEpYeDVBYlIwNVF0eUs5cm5RcGZNWnJTVjdqRjAyMUFSUVlGY0ZGZzdaWVYzYWhyWmlKcEY0TWUvMXdyYlJXVmN4VEVnQXQ3ZlFFSXFHMlVjOXo2YnV5ZVVZbytzY0dITWIwVjNqQ3FtaTdnV2hrRXI3VlJqeEZUVHBMNkRjdk4zM2t1K0FEV2tuUzV3WjNOV2daZW1acVpZWlp5U3NGY0V0RVdSdVdKekZ2WlZvOStPZTJPVzhOV2pZaTVBL2xxMUsyYWtrbHBQa1hPekdvUGtXQnVWVXd4bm9tLzJOdWhXaW1Uek9GL0xDU2dWK2hLdzZwcW0vMC9KTW1LQ0tEZFFEa2NWL3VTcklTTzBSQld6ZjhiZlpHaURIdnpud2RiVGRKZTA0VDBUQXBVc29mQkFOVTBqS2pEdlR2TW9kVlFzQzRkcjlKQmVrQzlwTk9nNkpYSVBLbXNOY2x6aXFPaldSalEvMU5yc1ZwWEVpK3p1VS8zeDFJbnBtNVVXNkdUTW9YamxZZ0JzTk51WnRhM2lZZmtrWEVrRG9EODBsdVBHMmo1OGhObkpOMmtkQ2VWVnB1WXZtTHJZM3F5VjNSbWsrRklYOFE3TTA5bFVWT1ZBU1lycGI2MC9GMlBqVDVnUzVVQ0dUNUNBa093d0dkV1dIaE9SZ3RzWnVuRHNzelNWWU1UU2w2UFlmSi9FUjVuQXpNUUYxZjlqTkxObWc3Z0M4SXlYSEpYZlRzTlZESTYyOFhiODZkMTZPMkxBc3NVUGF2VXhCK2FJYUp3Vkc5QVhsYUNxS0VYaVYzdWFwbE1lcjRuSG1wRjV2U0JPVEowWGdoWHZrbjV0OXFqd28zS2loMjNJUHkzbEFBcnBiWVhGVnNLbXpmNFh3SmJHTFBRMExIQUNrdGFoM3UxTEhUZjRoaFp6QTFkNWFUS2JPS2RPUUc2WFQybndBemhBWmYrV3lzSng5ZExRNWFUWFFTZFBZc2gvNDNSK1Q5ajNTcTlxV1hNOHVsSEtJR3M2aEg2VWdoZWE0WFF4b00vRzRLWFVSM2JlSG5Tc1lQT3FwdjlheG9kdW1WU25UTmEwS1RHR012bTJJcllwU2tONC9HeFZwckt2WUpvZStUWkZScUx0QnBQejJxMUJETkxzYStNRWtyWmpBRjduYi81eCtKT2dsVnVMQVBUWk1INm5MWlZQYlhFR0VTeUp1WXNVYXR5dUVyMU14TTc0TEE1L0Z0cnBycEt4cXhscVNndHdGNWpTQWlFemtRNkFUK0I0dTg2UDk3SXZhcVp2ZGlSZWZZdlI1QlF4UUlLazAzdWJuMlhEMTNwcWY0bFZBU0pBU3AwVkRhY0xlaDh3aTJPTkFmV29FVmNhTUl5RWhIajFHK0lCNjhRVVpldUxQS0k0UkVybFU4eGFiYld5NW9JdFJWd2R6ejF6T09mMGdPOWtaMDNlWkdGWkMrZWtVd050dEphdytHdnVHcFJpWjk3L01vSjlQM2VqZ0F0Tk1Oa0xYdHBmcWZuVnhIM2JITzlzSDB6UmVKaFZ1Q1N6N2EzZ1JLTzNweXNJb1FFdjdsdEZ5VG1LOGM2YnBOWkY1eEhNNFQ1U003ZHZwRE9vZUZ5Y0RlQkU2djdzeHVnVXJ2VC8vOTRGUU5qY0k4Vm8zTWNNNXl0QVQvbGx1OHJmWmxlcXk2TExyYnFFY2FKem5iQUlSZW9iSUZQTlBiR3c5VUJ2UzZGOTYwek9XcTkwZ1RxN2ZZSjR4RG4xQ3dUajZHdDh6a2hsSFd5NE05aHdtSW9pZ3pEVHFhM2t6RmZydnVLYzNLb094aTlNVUM3OERkdnNxS0d3dTZobjY0UnMyZ1QxRU1xVW9UOElGU0R3cmh5QzNVdWhFSDlwZ2pJVUVaTEVoMVJKM2tUNFhnV0FpNjVmSVBlWThMbHh0YzExS0FJb29BaTFNeDYrWDExRmlQUjIyYUZhTmNKSWNqQTJXenFoeGNYWjBtSmpKU0JmMzJxbWJoUTlwa2p5WWFNcXZrN2hUVWZNMXMySnByR2RmSStvUlhIb051WVNiYUJvZDV1L2wvUk1WWC9BRXprVStabHJ2SGMxZk5JOEZFcWpPWjFEQ2F0U2JnUUdtekdVY3d0TDJVMnNycmxqaEpHd25PbURrWkQrekZFYzIvSUFnVTl6RE5TN0FWSFdPeGc9PQ=="; }


        public static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
                return builder.Build();
            }
        }


        public static List<UrlTemplate> UrlTemplateManager
        {
            get
            {
                List<UrlTemplate> urlTemplate = new();

                try
                {
                    Configuration.GetSection("ManagerUrlTemplate").Bind(urlTemplate);
                }
                catch (Exception)
                {
                }
                return urlTemplate;
            }
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



        public static UrlTemplate? GetUrlTemplate(ListOfCodeTemplate codeTemplate)
        {
            int innerCode = (int)codeTemplate;

            return UrlTemplateManager.SingleOrDefault(s => s.Code == innerCode);
        }


        ///// <summary>
        ///// Ritorna un'istanza del service relativo all'entità a livello Object Model.
        ///// </summary>
        ///// <returns>istanza del service relativo all'entità a livello Object Model.</returns>
        internal static IServiceLocatorFactory GetServiceLocatore() => ServiceLocatorFactory.Instance;

        public static string FirstCharToUpper(this string input) =>
                input switch
                {
                    null => throw new ArgumentNullException(nameof(input)),
                    "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                    _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
                };
        public static string BuildNameFromEmailAddress(this string input)
        {
            string identityName = string.Empty;
            try
            {
                string[] itemArray = input.Split(new char[] { '@' });

                if (itemArray[0] != null && itemArray.Count() == 2)
                {
                    string baseAccount = itemArray[0].Trim();
                    string[] listitem = baseAccount.Split(new char[] { '.' });

                    if (listitem[0] != null && listitem.Any())
                    {
                        var ilstnewitem = new List<String>();
                        foreach (var item in listitem)
                        {
                            ilstnewitem.Add(item.FirstCharToUpper());
                        }

                        identityName = String.Join(" ", ilstnewitem.ToArray());
                    }
                }
                else if (itemArray[0] != null && itemArray.Count() == 1)
                {
                    identityName = itemArray[0].Trim();
                }

            }
            catch (Exception)
            {
            }
            return identityName;
        }


        internal static Common.ObjectModel.EVLogApi TOEVLogApi(this EVLog eVLog)
        {
            if (eVLog == null)
                return null;
            return new Common.ObjectModel.EVLogApi()
            {
                CodeError = eVLog.CodeError,
                MessageErrore = eVLog.MessageErrore,
                NameSpaceClassError = eVLog.NameSpaceClassError,
                InnerMessageErrore = eVLog.InnerMessageErrore
            };
        }

        internal static Common.StatusCodesApi TOStatusCodesApi(this DomainObject.StatusCodes eVLog)
        {
            return eVLog switch
            {
                DomainObject.StatusCodes.Success => Common.StatusCodesApi.Success,
                DomainObject.StatusCodes.Warning => Common.StatusCodesApi.Warning,
                DomainObject.StatusCodes.Error => Common.StatusCodesApi.Error,
                DomainObject.StatusCodes.CannotNotBeExecute => Common.StatusCodesApi.CannotNotBeExecute,
                DomainObject.StatusCodes.NotFound => Common.StatusCodesApi.NotFound,
                _ => Common.StatusCodesApi.Success,
            };
        }

        internal static EVLog TOEVLog(this Common.ObjectModel.EVLogApi eVLog)
        {
            if (eVLog == null)
                return null;
            return new EVLog()
            {
                CodeError = eVLog.CodeError,
                MessageErrore = eVLog.MessageErrore,
                NameSpaceClassError = eVLog.NameSpaceClassError,
                InnerMessageErrore = eVLog.InnerMessageErrore
            };
        }

        internal static DomainObject.StatusCodes TOStatusCodes(this Common.StatusCodesApi eVLog)
        {
            return eVLog switch
            {
                Common.StatusCodesApi.Success => DomainObject.StatusCodes.Success,
                Common.StatusCodesApi.Warning => DomainObject.StatusCodes.Warning,
                Common.StatusCodesApi.Error => DomainObject.StatusCodes.Error,
                Common.StatusCodesApi.CannotNotBeExecute => DomainObject.StatusCodes.CannotNotBeExecute,
                Common.StatusCodesApi.NotFound => DomainObject.StatusCodes.NotFound,
                _ => DomainObject.StatusCodes.Success,
            };
        }


        #endregion

        #region METHODS

        #region PUBLIC


        #region METODI Members

        public static string GetCurrentBaseUrlRestApiService
        {
            get
            {
                var itemselement = Configuration.GetSection("BaseURLMicroServices:CompanyRegister");
                string _currentBaseUrlRestApiService = itemselement.Exists() ? itemselement.Value : null;

                if (String.IsNullOrWhiteSpace(_currentBaseUrlRestApiService))
                    throw new ArgumentNullException("Manca la configurazione della section BaseURLMicroServices nel appsettings.json");

                return _currentBaseUrlRestApiService;
            }
        }



        /// <summary>
        /// Controlla se la stringa è null, vuota o composta di spazi bianchi
        /// </summary>
        /// <param name="value">parametro da controllare </param>
        /// <returns></returns>
        internal static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            try
            {
                if (String.IsNullOrEmpty(value))
                    return true;
                if (String.IsNullOrWhiteSpace(value))
                    return true;
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }


        #endregion

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

    }
}
