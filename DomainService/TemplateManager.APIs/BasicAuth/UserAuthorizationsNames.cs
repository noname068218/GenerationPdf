using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.APIs.BasicAuth
{

    /// <summary>
    /// Nome delle entita esposte
    /// </summary>
    public static class UserAuthorizationsNames
    {
        //
        // Summary:
        //     The URI for a claim that specifies the actor,
        public const string Readonly = "TemplateManagerReadonly";


        //
        // Summary:
        //     The URI for a claim that specifies the actor,
        public const string Write = "TemplateManagerWrite";

        //
        // Summary:
        //     The URI for a claim that specifies the actor
        public const string FullAccess = "TemplateManagerFullAccess";
    }

}
