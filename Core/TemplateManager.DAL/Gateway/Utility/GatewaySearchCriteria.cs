using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Concurrent;
using TemplateManager.DAL.Data;
using System.Data.Common;
using Epy.Standard.Core.Common;
using Microsoft.Data.SqlClient;

namespace TemplateManager.DAL.Gateway
{
    /// <summary>
    /// Classe contenente gli extension methods per SQL Server.
    /// </summary>
    internal static class GatewaySearchCriteria
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

        #region EVENT HANDLER
        #region PUBLIC
        #endregion
        #region PRIVATE
        #endregion
        #endregion

        #region METHODS
        #region PUBLIC

        #region Task 


        public static System.Data.DataTable ToParallelDataTable<T>(this IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            System.Data.DataTable dataTable = new();
            Parallel.ForEach(properties, info =>
            {
                dataTable.Columns.Add(new System.Data.DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            });

            Parallel.ForEach(list, entity =>
            {
                object[] values = new object[properties.Length];

                Parallel.For(0, properties.Length, i =>
                {
                    values[i] = properties[i].GetValue(entity);
                });

                dataTable.Rows.Add(values);
            });

            return dataTable;
        }

        public static async Task RunWithMaxDegreeOfConcurrency<T>(
             int maxDegreeOfConcurrency, IEnumerable<T> collection, Func<T, Task> taskFactory)
        {
            var activeTasks = new List<Task>(maxDegreeOfConcurrency);
            foreach (var task in collection.Select(taskFactory))
            {
                activeTasks.Add(task);
                if (activeTasks.Count == maxDegreeOfConcurrency)
                {
                    await Task.WhenAny(activeTasks.ToArray());
                    //observe exceptions here
                    activeTasks.RemoveAll(t => t.IsCompleted);
                }
            }
            await Task.WhenAll(activeTasks.ToArray()).ContinueWith(t =>
            {
                //observe exceptions in a manner consistent with the above   
            });
        }

        public static Task ForEachAsync<T>(
              this IEnumerable<T> source, int dop, Func<T, Task> body)
        {
            return Task.WhenAll(
                from partition in Partitioner.Create(source).GetPartitions(dop)
                select Task.Run(async delegate {
                    using (partition)
                        while (partition.MoveNext())
                            await body(partition.Current).ContinueWith(t =>
                            {
                                //observe exceptions
                            });

                }));
        }

        #endregion



        #region Extension

        #region Template

        /// <summary>
        /// Restituisce l'expression linq da applicare alla lista dei Comuni per ottenere quelle filtrate
        /// con i criteri di ricerca in ingresso
        /// </summary>
        ///  <param name=criteria></param>
        /// <returns>Implementazione concreta del gateway relativo all'entità (<see cref= TemplateManager.DAL.DomainModel.ITemplateObjectModel/>).</returns>
        internal static void  ToWhereClauseGateway(this TemplateSearchCriteria criteria, SqlCommand cmd)
         {
          if (criteria is null)
               throw new ArgumentNullException(nameof(criteria));

          if (criteria.RowsTop.HasValue)
               SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.RowsTop), criteria.RowsTop);

            if (criteria.Id.HasValue)
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.Id), criteria.Id);

            if (criteria.Code.HasValue)
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.Code), criteria.Code);

            if (!criteria.Name.IsNullOrEmptyOrWhiteSpace())
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.Name), criteria.Name);

            if (!criteria.AlphaCode.IsNullOrEmptyOrWhiteSpace())
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.AlphaCode), criteria.AlphaCode);

            if (!criteria.Description.IsNullOrEmptyOrWhiteSpace())
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.Description), criteria.Description);


         }
        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Restituisce l'expression linq da applicare alla lista dei Comuni per ottenere quelle filtrate
        /// con i criteri di ricerca in ingresso
        /// </summary>
        ///  <param name=criteria></param>
        /// <returns>Implementazione concreta del gateway relativo all'entità (<see cref= TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel/>).</returns>
        internal static void  ToWhereClauseGateway(this TemplateParagraphSearchCriteria criteria, SqlCommand cmd)
         {
          if (criteria is null)
               throw new ArgumentNullException(nameof(criteria));

          if (criteria.RowsTop.HasValue)
               SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.RowsTop), criteria.RowsTop);

            if (criteria.Id.HasValue)
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.Id), criteria.Id);

            if (criteria.CodeTemplate.HasValue)
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.CodeTemplate), criteria.CodeTemplate);

            if (!criteria.NameOfTemplate.IsNullOrEmptyOrWhiteSpace())
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.NameOfTemplate), criteria.NameOfTemplate);

            if (!criteria.AlphaCode.IsNullOrEmptyOrWhiteSpace())
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.AlphaCode), criteria.AlphaCode);

            if (criteria.PositionIndex.HasValue)
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.PositionIndex), criteria.PositionIndex);

            if (!criteria.PresentationInfo.IsNullOrEmptyOrWhiteSpace())
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.PresentationInfo), criteria.PresentationInfo);

            if (!criteria.Title.IsNullOrEmptyOrWhiteSpace())
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.Title), criteria.Title);

            if (!criteria.Subtitle.IsNullOrEmptyOrWhiteSpace())
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.Subtitle), criteria.Subtitle);

            if (!criteria.Paragraph.IsNullOrEmptyOrWhiteSpace())
                SqlClientTransaction.AddParameterWithValue(cmd, criteria.GetPropertyName(c => c.Paragraph), criteria.Paragraph);


         }
        #endregion



        #endregion
        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion
    }
}
