using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.APIs.Exceptions
{
    /// <summary>
    /// Enum che indica il livello a cui è avvenuto un'eccezione.
    /// </summary>
    public enum Layer
    {
        /// <summary>
        /// Domain
        /// </summary>
        Domain = 2,
        /// <summary>
        /// Service
        /// </summary>
        Service = 3,
        /// <summary>
        /// DAL
        /// </summary>
        DAL = 4,
        /// <summary>
        /// Authorization
        /// </summary>
        Authorization = 5,

        /// <summary>
        /// Authentication
        /// </summary>
        Authentication = 6

    }
    

    /// <summary>
    /// Enum relativo alle eccezioni a livello DAL.
    /// </summary>
    public enum CodeOfEventCategory
    {
        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        ApllicationManager = 1000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        CompanyRegister = 2000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        DeviceCompany = 3000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        FlussoManager = 4000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        MasterDataCompany = 5000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        MasterDataRegister = 6000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        MailNotifications = 7000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        EVLogNotifications = 8000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        IncidentManager = 9000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        UserManager = 10000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        EpyCentral = 11000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        SchedulerManager = 12000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        ParameterManager = 13000,

        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        EventLogOnSite = 14000,
        
    }

    /// <summary>
    /// Enum relativo alle eccezioni a livello DAL.
    /// </summary>
    public enum DALDBException
    {
        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        AncestorsMustBeSavedFirst = 1
    }
}
