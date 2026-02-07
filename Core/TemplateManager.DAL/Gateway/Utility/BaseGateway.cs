using Epy.Standard.Core.Common;
using Epy.Standard.Core.DAL;
using Epy.Standard.ef;
using TemplateManager.DAL.Application;
using Microsoft.EntityFrameworkCore;
using System;
using TemplateManager.DAL.ContexManager;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace TemplateManager.DAL.Gateway
{
    /// <summary>
    /// Classe base per i Repository.
    /// </summary>
    internal abstract class BaseGateway
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
        private readonly String _connectionstring;
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
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
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

        #region DYNAMIC

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

        #region CONSTRUCTORS
        #region PUBLIC

        protected BaseGateway(
            string connectionstring
        )
        {
            _connectionstring = connectionstring ?? throw new ArgumentNullException(nameof(connectionstring));

            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);

        }
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
        /// <summary>
        /// Ritorna il ContextBilling relativo ad EF per SQLClient.
        /// </summary>
        /// <value>
        /// ContextBilling relativo ad EF per SQLClient.
        /// </value>
        protected String ConnectionStringSQL
        {
            get
            {
                return _connectionstring;
            }
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
        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion

    }
}
