using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Common.ObjectModel
{
    public class RenderRequest<TModel>
    {
        public string ViewName { get; set; }
        public TModel Model { get; set; }
    }
}
