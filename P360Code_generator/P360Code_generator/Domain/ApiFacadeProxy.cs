using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Metadata;
using _360Generator.Templates;

namespace _360Generator.Domain
{
    class ApiFacadeProxy : RootDomain
    {
        private Module Module { get; set; }
        public ApiFacadeProxyTemplate apiFacadeProxyTemplate { get; set; }
        
        public ApiFacadeProxy(Module apiFacadeProxyModule)
        {
            this.Module = apiFacadeProxyModule;
        }

        public void CreateApiFacadeProxyTemplate()
        {
            apiFacadeProxyTemplate = new ApiFacadeProxyTemplate();
            apiFacadeProxyTemplate.Session = new Dictionary<string, object>();
            string moduleName = this.Module.ModuleName;
            apiFacadeProxyTemplate.Session["module"] = moduleName;
            apiFacadeProxyTemplate.Initialize();

            StringBuilder path = new StringBuilder("../../GeneratedCode/");
            path.Append(moduleName + "FacadeProxy.cs");

            string pageContent = apiFacadeProxyTemplate.TransformText();
            System.IO.File.WriteAllText(path.ToString(), pageContent);            
        }

        
    }
}
