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
    /// L'implementazione dell'interfaccia Repository <see cref="TemplateManager.DAL.Gateway.ITemplateParagraphGateway"/> per l'entità <see cref="TemplateManager.DAL.DomainModel.TemplateParagraph"/>.
    /// </summary>
    internal class TemplateParagraphGateway: BaseGateway, ITemplateParagraphGateway
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

        public TemplateParagraphGateway(String connectionString): base(connectionString)
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
        public ITemplateParagraphObjectModel Save(ITemplateParagraphObjectModel item, TemplateParagraphSaveArgs args = null)
        {
            if (!item.IsNotNullAndHasType<TemplateParagraph> (
                      "TemplateParagraph",
                      "TemplateParagraph: lo Casse non può essere null",
                      "TemplateParagraph: non è di tipo TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel"
                      )
                    )
                    return null;

            var itemModel = item as TemplateParagraph;

            SqlConnection con = SqlClientTransaction.CreateConnection(ConnectionStringSQL);
            SqlCommand cmd;

            if (con.State != ConnectionState.Open)
                con.Open();

            if (itemModel.Id <= 0)
            {
                itemModel.ApplyChanges(State.Added);
                cmd = SqlClientTransaction.CreateNewCommandConnection("SP_TemplateParagraph_Insert", con);
            }
            else
            {
                itemModel.ApplyChanges(State.Modified);
                cmd = SqlClientTransaction.CreateNewCommandConnection("SP_TemplateParagraph_Update", con);
                SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.Id), itemModel.Id);
            }

            if (args != null && args.DisabilitySoftDeleted)
            {
                SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => args.IsSoftDelete), args.IsSoftDelete);
                itemModel.IdUserDeleting = null;
                itemModel.DateDeleting = null;
            }

            
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.CodeTemplate), itemModel.CodeTemplate);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.NameOfTemplate), itemModel.NameOfTemplate);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.AlphaCode), itemModel.AlphaCode);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.PositionIndex), itemModel.PositionIndex);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.PresentationInfo), itemModel.PresentationInfo);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.Title), itemModel.Title);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.Subtitle), itemModel.Subtitle);
            SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.Paragraph), itemModel.Paragraph);


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

            var result = dt.ToMappingQueryable <TemplateParagraph> ();

            return result.FirstOrDefault();
        }


        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id e alle viste specificate negli <c>args</c>.
        /// </summary>
        /// <param name="id">Id numerico associato all'entità</param>
        /// <param name="args">argomenti che descrivono l'operazione di select su un'istanza dell'entità</param>
        /// <returns>Istanza dell'entità in base all'id e alle viste specificate negli <c>args</c></returns>
        public ITemplateParagraphObjectModel GetById(int id, TemplateParagraphSelectArgs args = null)
        {
            args ??= new();
			var criteria = new TemplateParagraphSearchCriteria() { Id = id, IncludeSoftDeleted = args.IncludeSoftDeleted };
			var result = Search(criteria);

			return result.FirstOrDefault();
        }



        /// <summary>
        /// Recupera un'insieme di istanze dell'entità considerata in base ai criteri di ricerca definiti negli <c>args</c>.
        /// </summary>
        /// <param name="criteria">argomenti che descrivono l'operazione di search sulle istanze dell'entità</param>
        /// <returns>Insieme di instanze dell'entità considerata.</returns>
        public IEnumerable<ITemplateParagraphObjectModel > Search(TemplateParagraphSearchCriteria criteria)
        {
            SqlConnection con = SqlClientTransaction.CreateConnection(ConnectionStringSQL);
			SqlCommand cmd;

			con.Open();

			cmd = SqlClientTransaction.CreateNewCommandConnection("SP_TemplateParagraph_Search", con);

			if (!criteria.IncludeSoftDeleted.HasValue || !criteria.IncludeSoftDeleted.Value)
				SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => criteria.IsSoftDelete), criteria.IsSoftDelete);

			criteria.ToWhereClauseGateway(cmd);

			DataTable dt = new();
			dt.Load(cmd.ExecuteReader());
			con.Close();
			con.Dispose();

			var result = dt.ToMappingQueryable <TemplateParagraph> ();

			result.ForEachAsync(rm => rm.LoadViewsGateway(criteria.Views));



			return result;
        }


        /// <summary>
        /// Elimina un'istanza dell'entità. 
        /// </summary>
        /// <param name="item">istanza dell'entità.</param>
        /// <param name="args">argomenti che descrivono l'operazione di delete sull'istanza dell'entità.</param>
        public void Delete(ITemplateParagraphObjectModel item, TemplateParagraphDeleteArgs args = null)
        {
            if (!item.IsNotNullAndHasType<TemplateParagraph> (
                    "TemplateParagraph",
                    "TemplateParagraph: lo Casse non può essere null",
                    "TemplateParagraph: non è di tipo TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel"
                )
               )
                return;

            args ??= new();

            var itemModel = item as TemplateParagraph;

            SqlConnection con = SqlClientTransaction.CreateConnection(ConnectionStringSQL);
            SqlCommand cmd;

            con.Open();

            if (itemModel.Id > 0)
            {
                if (args.IsSoftDelete)
                {
                    itemModel.ApplyChanges(State.Deleted);

                    cmd = SqlClientTransaction.CreateNewCommandConnection("SP_TemplateParagraph_SoftDelete", con);
                    SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => c.Id), itemModel.Id);
                    SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.IdUserDeleting), itemModel.IdUserDeleting);
                    SqlClientTransaction.AddParameterWithValue(cmd, itemModel.GetPropertyName(c => itemModel.DateDeleting), itemModel.DateDeleting);

                }
                else
                {
                    cmd = SqlClientTransaction.CreateNewCommandConnection("SP_TemplateParagraph_Delete", con);
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
