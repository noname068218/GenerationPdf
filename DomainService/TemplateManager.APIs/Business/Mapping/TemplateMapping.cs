using TemplateManager.Common.Arguments;
using TemplateManager.Common.ObjectModel;
using TemplateManager.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;

namespace TemplateManager.APIs.Constants.Business.Mapping
{
    internal static class TemplateMapping
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        #region PUBLIC

        #region Mapping Entity TemplateMapping 

        /// <summary>
        /// mapping from source <see cref="ITemplate"/> To target <see cref="TemplateApi"/>
        /// </summary>
        /// <param name="source"><see cref="ITemplate"/></param>
        /// <param name="target"><see cref="TemplateApi"/></param>
        /// <returns><see cref="TemplateApi"/></returns>
        internal static TemplateApi Map(this ITemplate source, TemplateApi target = null)
        {
            if (source == null)
                return null;

            if (target == null)
                target = new TemplateApi();


            target.Id = source.Id;
            target.Code = source.Code;
            target.Name = source.Name;
            target.AlphaCode = source.AlphaCode;
            target.Description = source.Description;


            return target;
        }

        /// <summary>
        /// mapping from source <see cref="TemplateApi"/> To target <see cref="ITemplate"/>
        /// </summary>
        /// <param name="source"><see cref="TemplateApi"/></param>
        /// <param name="target"><see cref="ITemplate"/></param>
        /// <returns>target <see cref="ITemplate"/></returns>
        internal static ITemplate Map(this TemplateApi source, ITemplate target = null)
        {
            if (source == null)
                return null;

            if (target == null)
                target = DomainServiceLocator.GetTemplateService().NewTemplate();


            target.Code = source.Code.Value;
            target.Name = source.Name;
            target.AlphaCode = source.AlphaCode;
            target.Description = source.Description;


            return target;
        }

        /// <summary>
        /// mapping from source <see cref="TemplateApiSearchCriteria"/> To target <see cref="TemplateSearchCriteria"/>
        /// </summary>
        /// <param name="source"><see cref="TemplateApiSearchCriteria"/></param>
        /// <returns>target <see cref="TemplateSearchCriteria"/></returns>
        internal static TemplateSearchCriteria Map(this TemplateApiSearchCriteria source)
        {
            if (source == null)
                return null;

            TemplateSearchCriteria target = new();


            target.Id = source.Id;
            target.Code = source.Code;
            target.Name = source.Name;
            target.AlphaCode = source.AlphaCode;
            target.Description = source.Description;


            return target;
        }

        /// <summary>
        /// mapping from source <see cref="TemplateApi"/> To target <see cref="ITemplate"/>
        /// </summary>
        /// <param name="source"><see cref="TemplateApi"/></param>
        /// <param name="target"><see cref="ITemplate"/></param>
        /// <returns>target <see cref="ITemplate"/></returns>
        internal static List<TemplateApi> Map(this IEnumerable<ITemplate> source, List<TemplateApi> target = null)
        {
            if (source == null)
                return null;

            if (target == null)
                target = new List<TemplateApi>();

            foreach (var item in source)
            {
                if (item != null)
                    target.Add(item.Map());
            }
            return target;
        }

        /// <summary>
        /// mapping from source <see cref="TemplateApi"/> To target <see cref="ITemplate"/>
        /// </summary>
        /// <param name="source"><see cref="TemplateApi"/></param>
        /// <param name="target"><see cref="ITemplate"/></param>
        /// <returns>target <see cref="ITemplate"/></returns>
        internal static List<ITemplate> Map(this List<TemplateApi> source, List<ITemplate> target = null)
        {
            if (source == null)
                return null;

            if (target == null)
                target = new List<ITemplate>();

            foreach (var item in source)
            {
                if (item != null)
                    target.Add(item.Map());
            }
            return target;
        }


        #endregion


        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

    }
}
