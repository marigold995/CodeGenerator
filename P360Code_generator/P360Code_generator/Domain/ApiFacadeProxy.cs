using P360Code_generator.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P360Code_generator.Domain
{
    class ApiFacadeProxy
    {
        private Module Module { get; set; }
        public ApiFacadeProxyTemplate apiFacadeProxyTemplate { get; set; }
        public ApiFacadeProxyProfileTemplate apiFacadeProxyProfileTemplate { get; set; }

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

            //this.CreateApiFacadeProxyProfileTemplate();
        }

        //public void CreateApiFacadeProxyProfileTemplate()
        //{
        //    apiFacadeProxyProfileTemplate = new ApiFacadeProxyProfileTemplate();
        //    apiFacadeProxyProfileTemplate.Session = new Dictionary<string, object>();
        //    string moduleName = this.Module.ModuleName;
        //    apiFacadeProxyProfileTemplate.Session["module"] = moduleName;
        //    apiFacadeProxyProfileTemplate.Initialize();

        //    StringBuilder path = new StringBuilder("../../GeneratedCode/");
        //    path.Append(moduleName + "Profile.cs");


        //    string pageContent = apiFacadeProxyProfileTemplate.TransformText();
        //    System.IO.File.WriteAllText(path.ToString(), pageContent);
        //}
    }
}
