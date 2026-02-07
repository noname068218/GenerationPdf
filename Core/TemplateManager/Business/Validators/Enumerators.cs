
namespace TemplateManager.Business
{
    #region Validators

    /// <summary>
    /// Enum per le eccezioni relative alla validazione.
    /// </summary>
    public enum ValidationException
    {
        /// <summary>
        /// Campo AncestorsMustBeSavedFirst non valorizzato.
        /// </summary>
        AncestorsMustBeSavedFirst = 1001,
        /// <summary>
        /// Campo CoreApplication non valorizzato.
        /// </summary>
        CoreApplication = 1002,
        /// <summary>
        /// Campo ConfigurationContex non valorizzato.
        /// </summary>
        ConfigurationContex = 1003,
        /// <summary>
        /// Campo ContexManager non valorizzato.
        /// </summary>
        ContexManager = 1004,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        DomainModel = 1005,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        Gateway = 1006,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        Repository = 1007,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        CoreBusiness = 1008,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        ArgumentIsNullOrEmpty = 1010,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        MissingRequiredField = 1011,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        InvalidFieldValue = 1012,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        DuplicateEntity = 1013,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        OnAddAction = 1013,

        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        OnSaveAction = 1014,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        OnCustomAction = 1015,
        /// <summary>
        /// Campo obbligatorio non valorizzato.
        /// </summary>
        OnRemoveAction = 1016
    }

    /// <summary>
    /// Enum per le Azioni di validazione da passare come argomenti.
    /// </summary>
    public enum ValidationAction
    {

        /// <summary>
        /// Validazione all'aggiunta dell'item.
        /// </summary>
        OnAddAction,

        /// <summary>
        /// Validazione della Collection al save del Padre.
        /// </summary>
        OnSaveAction,

        /// <summary>
        /// Azione che non rientra nelle categorie precedenti.
        /// </summary>
        OnCustomAction,

        /// <summary>
        /// Validazione in fase di Cancellazione
        /// </summary>
        OnRemoveAction,
    }

    #endregion
}
