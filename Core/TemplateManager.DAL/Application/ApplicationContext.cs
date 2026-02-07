using TemplateManager.DAL.ContexManager;
using Epy.Standard.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;


namespace TemplateManager.DAL.Application
{
    /// <summary>
    /// Classe da cui recuperare l'istanza di IDALContext utilizzata dal thread corrente.
    /// 
    /// Si tratta di un'evoluzione del framework precedente che costringeva il passaggio del Context tra un service e l'altro o tra
    /// un service e un repository/dal.
    /// In questo caso il Context è fisso per ogni thread e viene recuperato tramite accesso singleton, il che copre quasi tutte le casistiche
    /// Se invece si vuole tornare all'approccio classico, è sufficiente invocare i vari metodi SetDalContext(Context) per trasferire il
    /// contesto esplicitamente da un punto all'altro (può essere utile in applicazioni multithread ecc)
    /// </summary>
    public class ApplicationContext
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

        /// <summary>
        /// Utente connesso nel thread dell'applicazione.
        /// E' quello che viene preso per settare l'utente creazione/modifica e cancellazione
        /// </summary>
        [ThreadStatic]
        private static int _idutente;

        /// <summary>
        /// Account connesso nel thread dell'applicazione.
        /// E' quello che viene preso per settare l'utente creazione/modifica e cancellazione
        /// </summary>
        [ThreadStatic]
        private static string _utenteAzione;


        public static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
                return builder.Build();
            }
        }


        public static String GetConnectionString
        {
            get
            {
                return Configuration.GetConnectionString(ConfigurationService.MainConnectionStringKey);
            }
        }
        static MainDALContext mainDALContext;
        public static MainDALContext MainDALContext
        {
            get
            {

                if (mainDALContext == null)
                    mainDALContext = new MainDALContext();

                return mainDALContext;
            }
        }
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        /// <summary>
        /// Ritorna il ContextBilling corrente in funzione della chiave specificata.
        /// </summary>
        /// <value>ContextBilling corrente in funzione della chiave specificata.</value>
        public static DbContextOptions DbContextOptions
        {
            get
            {
                string connectionString = Configuration.GetConnectionString(ConfigurationService.MainConnectionStringKey);
                var builder = new DbContextOptionsBuilder<MainContext>();
                builder.UseSqlServer(connectionString);
                return builder.Options;
            }
        }
        /// <summary>
        /// Ritorna il ContextBilling corrente in funzione della chiave specificata.
        /// </summary>
        /// <value>ContextBilling corrente in funzione della chiave specificata.</value>
        public static MainContext CurrentContext
        {
            get
            {
                return MainDALContext.BuildNewDbContext();
            }
        }

        static MemoryCache cacheIdUtente = new(new MemoryCacheOptions { SizeLimit = 1024 });
        /// <summary>
        /// Ritorna o imposta l'utente connesso nel thread dell'applicazione.
        /// E' quello che viene preso per settare l'utente creazione/modifica e cancellazione
        /// </summary>
        public static int IdUtente
        {
            set
            {

                var options = new MemoryCacheEntryOptions().SetSize(1);
                cacheIdUtente.Set("_IdUtente_", value, options);
            }
            get { return cacheIdUtente.Get("_IdUtente_").ToInt(); }
        }

        static MemoryCache cacheUtenteAzione = new(new MemoryCacheOptions { SizeLimit = 1024 });

        /// <summary>
        /// Ritorna o imposta l'utente connesso nel thread dell'applicazione.
        /// E' quello che viene preso per settare l'utente creazione/modifica e cancellazione
        /// </summary>
        public static String UtenteAzione
        {
            set
            {

                var options = new MemoryCacheEntryOptions().SetSize(1);
                cacheUtenteAzione.Set("_utenteAzione_", value, options);
                _utenteAzione = value;

            }
            get { return cacheUtenteAzione.Get("_utenteAzione_").ToString(); }
        }

        #endregion
        #region NOT PUBLIC


        #endregion
        #endregion

        #region EVENT HANDLER
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region METHODS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC


        #endregion
        #endregion

        #endregion

    }
}
