using System;
using System.Linq;
using System.Data.Common;
using System.Data;
using TemplateManager.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Epy.Standard.Core.Common;
using Epy.Standard.ef;
using TemplateManager.DAL.DomainModel;
using Microsoft.Data.SqlClient;

namespace TemplateManager.DAL.Gateway
{
    /// <summary>
    /// L'implementazione dell'interfaccia Repository <see cref="TemplateManager.DAL.Gateway.ITemplateGateway"/> per l'entità <see cref="TemplateManager.DAL.DomainModel.Template"/>.
    /// </summary>
    internal class TemplateGateway: BaseGateway, ITemplateGateway
    {

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

        public TemplateGateway(String connectionString): base(connectionString)
        {
           SqlClientTransaction.ConnectionStringName = connectionString;
         }

        #endregion

        #region NOT PUBLIC
        #endregion

        #endregion

        #region PROPERTIES

        #region PUBLIC


        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion


        #region METHODS

        #region PUBLIC
        /// <summary>
        /// Salva un'istanza dell'entità. 
        /// </summary>
        /// <param name="item">istanza dell'entità.</param>
        /// <param name="args">argomenti che descrivono l'operazione di save sull'istanza dell'entità.</param>
        public ITemplateObjectModel Save(ITemplateObjectModel item, TemplateSaveArgs args = null)
        {
            if (!item.IsNotNullAndHasType<Template> (
                      "Template",
                      "Template: lo Casse non può essere null",
                      "Template: non è di tipo TemplateManager.DAL.DomainModel.ITemplateObjectModel"
                      )
                    )
                    return null;

            var itemModel = item as Template;

            SqlConnection con = SqlClientTransaction.CreateConnection(ConnectionStringSQL);
            SqlCommand cmd;

            if (con.State != ConnectionState.Open)
                con.Open();

            if (itemModel.Id <= 0)
            {
                itemModel.ApplyChanges(State.Added);
                cmd = SqlClientTransaction.CreateNewCommandConnection("SP_Template_Insert", con);
            }
            else
            {
                itemModel.ApplyChanges(State.Modified);
                cmd = SqlClientTransaction.CreateNewCommandConnection("SP_Template_Update", con);
                SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.Id), itemModel.Id);
            }

            if (args != null && args.DisabilitySoftDeleted)
            {
                SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => args.IsSoftDelete), args.IsSoftDelete);
                itemModel.IdUserDeleting = null;
                itemModel.DateDeleting = null;
            }

            
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.Code), itemModel.Code);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.Name), itemModel.Name);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.AlphaCode), itemModel.AlphaCode);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.Description), itemModel.Description);


            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.IdUserCreation), itemModel.IdUserCreation);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.DateCreation), itemModel.DateCreation);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.IdUserChange), itemModel.IdUserChange);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.DateChange), itemModel.DateChange);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.IdUserDeleting), itemModel.IdUserDeleting);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.DateDeleting), itemModel.DateDeleting);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.IsSoftDelete), itemModel.IsSoftDelete);


            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            con.Dispose();

            var result = dt.ToMappingQueryable <Template> ();

            return result.FirstOrDefault();
        }


        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id e alle viste specificate negli <c>args</c>.
        /// </summary>
        /// <param name="id">Id numerico associato all'entità</param>
        /// <param name="args">argomenti che descrivono l'operazione di select su un'istanza dell'entità</param>
        /// <returns>Istanza dell'entità in base all'id e alle viste specificate negli <c>args</c></returns>
        public ITemplateObjectModel GetById(int id, TemplateSelectArgs args = null)
        {
            args ??= new();
			var criteria = new TemplateSearchCriteria() { Id = id, IncludeSoftDeleted = args.IncludeSoftDeleted };
			var result = Search(criteria);

			return result.FirstOrDefault();
        }



        /// <summary>
        /// Recupera un'insieme di istanze dell'entità considerata in base ai criteri di ricerca definiti negli <c>args</c>.
        /// </summary>
        /// <param name="criteria">argomenti che descrivono l'operazione di search sulle istanze dell'entità</param>
        /// <returns>Insieme di instanze dell'entità considerata.</returns>
        public IEnumerable<ITemplateObjectModel > Search(TemplateSearchCriteria criteria)
        {
            SqlConnection con = SqlClientTransaction.CreateConnection(ConnectionStringSQL);
			SqlCommand cmd;

			con.Open();

			cmd = SqlClientTransaction.CreateNewCommandConnection("SP_Template_Search", con);

			if (!criteria.IncludeSoftDeleted.HasValue || !criteria.IncludeSoftDeleted.Value)
				SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => criteria.IsSoftDelete), criteria.IsSoftDelete);

			criteria.ToWhereClauseGateway(cmd);

			DataTable dt = new();
			dt.Load(cmd.ExecuteReader());
			con.Close();
			con.Dispose();

			var result = dt.ToMappingQueryable <Template> ();

			result.ForEachAsync(rm => rm.LoadViewsGateway(criteria.Views));



			return result;
        }


        /// <summary>
        /// Elimina un'istanza dell'entità. 
        /// </summary>
        /// <param name="item">istanza dell'entità.</param>
        /// <param name="args">argomenti che descrivono l'operazione di delete sull'istanza dell'entità.</param>
        public void Delete(ITemplateObjectModel item, TemplateDeleteArgs args = null)
        {
            if (!item.IsNotNullAndHasType<Template> (
                    "Template",
                    "Template: lo Casse non può essere null",
                    "Template: non è di tipo TemplateManager.DAL.DomainModel.ITemplateObjectModel"
                )
               )
                return;

            args ??= new();

            var itemModel = item as Template;

            SqlConnection con = SqlClientTransaction.CreateConnection(ConnectionStringSQL);
            SqlCommand cmd;

            con.Open();

            if (itemModel.Id > 0)
            {
                if (args.IsSoftDelete)
                {
                    itemModel.ApplyChanges(State.Deleted);

                    cmd = SqlClientTransaction.CreateNewCommandConnection("SP_Template_SoftDelete", con);
                    SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.Id), itemModel.Id);
                    SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.IdUserDeleting), itemModel.IdUserDeleting);
                    SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.DateDeleting), itemModel.DateDeleting);

                }
                else
                {
                    cmd = SqlClientTransaction.CreateNewCommandConnection("SP_Template_Delete", con);
                    SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.Id), itemModel.Id);
                }

                cmd.ExecuteNonQuery();
            }
            con.Close();
            con.Dispose();

        }

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

        #endregion

    }
}
