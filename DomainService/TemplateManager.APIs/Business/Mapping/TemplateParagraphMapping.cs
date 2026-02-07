using TemplateManager.Common.Arguments;
using TemplateManager.Common.ObjectModel;
using TemplateManager.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;

namespace TemplateManager.APIs.Constants.Business.Mapping
{
    internal static class TemplateParagraphMapping
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        #region PUBLIC

        #region Mapping Entity TemplateParagraphMapping 

        /// <summary>
        /// mapping from source <see cref="ITemplateParagraph"/> To target <see cref="TemplateParagraphApi"/>
        /// </summary>
        /// <param name="source"><see cref="ITemplateParagraph"/></param>
        /// <param name="target"><see cref="TemplateParagraphApi"/></param>
        /// <returns><see cref="TemplateParagraphApi"/></returns>
        internal static TemplateParagraphApi Map(this ITemplateParagraph source, TemplateParagraphApi target = null)
        {
            if (source == null)
                return null;

            if (target == null)
                target = new TemplateParagraphApi();


            target.Id = source.Id;
            target.CodeTemplate = source.CodeTemplate;
            target.NameOfTemplate = source.NameOfTemplate;
            target.AlphaCode = source.AlphaCode;
            target.PositionIndex = source.PositionIndex;
            target.PresentationInfo = source.PresentationInfo;
            target.Title = source.Title;
            target.Subtitle = source.Subtitle;
            target.Paragraph = source.Paragraph;


            return target;
        }

        /// <summary>
        /// mapping from source <see cref="TemplateParagraphApi"/> To target <see cref="ITemplateParagraph"/>
        /// </summary>
        /// <param name="source"><see cref="TemplateParagraphApi"/></param>
        /// <param name="target"><see cref="ITemplateParagraph"/></param>
        /// <returns>target <see cref="ITemplateParagraph"/></returns>
        internal static ITemplateParagraph Map(this TemplateParagraphApi source, ITemplateParagraph target = null)
        {
            if (source == null)
                return null;

            if (target == null)
                target = DomainServiceLocator.GetTemplateParagraphService().NewTemplateParagraph();


            target.CodeTemplate = source.CodeTemplate.Value;
            target.NameOfTemplate = source.NameOfTemplate;
            target.AlphaCode = source.AlphaCode;
            target.PositionIndex = source.PositionIndex.Value;
            target.PresentationInfo = source.PresentationInfo;
            target.Title = source.Title;
            target.Subtitle = source.Subtitle;
            target.Paragraph = source.Paragraph;


            return target;
        }

        /// <summary>
        /// mapping from source <see cref="TemplateParagraphApiSearchCriteria"/> To target <see cref="TemplateParagraphSearchCriteria"/>
        /// </summary>
        /// <param name="source"><see cref="TemplateParagraphApiSearchCriteria"/></param>
        /// <returns>target <see cref="TemplateParagraphSearchCriteria"/></returns>
        internal static TemplateParagraphSearchCriteria Map(this TemplateParagraphApiSearchCriteria source)
        {
            if (source == null)
                return null;

            TemplateParagraphSearchCriteria target = new();


            target.Id = source.Id;
            target.CodeTemplate = source.CodeTemplate;
            target.NameOfTemplate = source.NameOfTemplate;
            target.AlphaCode = source.AlphaCode;
            target.PositionIndex = source.PositionIndex;
            target.PresentationInfo = source.PresentationInfo;
            target.Title = source.Title;
            target.Subtitle = source.Subtitle;
            target.Paragraph = source.Paragraph;


            return target;
        }

        /// <summary>
        /// mapping from source <see cref="TemplateParagraphApi"/> To target <see cref="ITemplateParagraph"/>
        /// </summary>
        /// <param name="source"><see cref="TemplateParagraphApi"/></param>
        /// <param name="target"><see cref="ITemplateParagraph"/></param>
        /// <returns>target <see cref="ITemplateParagraph"/></returns>
        internal static List<TemplateParagraphApi> Map(this IEnumerable<ITemplateParagraph> source, List<TemplateParagraphApi> target = null)
        {
            if (source == null)
                return null;

            if (target == null)
                target = new List<TemplateParagraphApi>();

            foreach (var item in source)
            {
                if (item != null)
                    target.Add(item.Map());
            }
            return target;
        }

        /// <summary>
        /// mapping from source <see cref="TemplateParagraphApi"/> To target <see cref="ITemplateParagraph"/>
        /// </summary>
        /// <param name="source"><see cref="TemplateParagraphApi"/></param>
        /// <param name="target"><see cref="ITemplateParagraph"/></param>
        /// <returns>target <see cref="ITemplateParagraph"/></returns>
        internal static List<ITemplateParagraph> Map(this List<TemplateParagraphApi> source, List<ITemplateParagraph> target = null)
        {
            if (source == null)
                return null;

            if (target == null)
                target = new List<ITemplateParagraph>();

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
