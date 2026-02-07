using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.DomainService
{
    public interface IQuestPdfRenderer
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Genera PDF da OfferContract.
        /// </summary>
        Byte[] GeneratePdf(OfferContract offer);

        #endregion

        #region METHODS

        #region PUBLIC

        #region METODI Members

        #endregion

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion
    }
}
