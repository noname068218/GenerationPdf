using TemplateManager.Common.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.APIs.Constants
{
    public class TemplateApiBuilderArgs
    {

        #region DYNAMIC

        #region METHODS
        #region PUBLIC
        internal TemplateApiBuilderArgs(TemplateApi _itemsInput)
        {
            Template = _itemsInput;
        }
        #endregion
        public TemplateApi Template { get; private set; }

        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion

    }
}
