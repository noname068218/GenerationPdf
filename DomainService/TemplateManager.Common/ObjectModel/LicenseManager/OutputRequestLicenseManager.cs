using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Output entity for License Manager / Email operations.
    /// Used to return feedback from PDF generation and email sending operations.
    /// </summary>
    [DataContract(Name = "OutputRequestLicenseManager")]
    public class OutputRequestLicenseManager
    {
        #region DYNAMIC

        #region CONSTRUCTORS
        #region PUBLIC

        /// <summary>
        /// Default constructor. Initializes Feedback with default values.
        /// </summary>
        public OutputRequestLicenseManager()
        {
            Feedback = new BaseApiFeedback();
        }

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        /// <summary>
        /// Returns or sets the Feedback property of the entity <c>OutputRequestLicenseManager</c>
        /// Contains operation status, error codes, and messages.
        /// </summary>
        /// <value>
        /// Feedback of type <c>BaseApiFeedback</c>.
        /// </value>
        [DataMember(IsRequired = true)]
        public BaseApiFeedback Feedback { get; set; }

        #endregion
        #endregion

        #endregion
    }
}

