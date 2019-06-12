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
            string pathDomain = CreateFolder(rootPath, "FacadeProxy");
            string pathGenerated = CreateFolder(pathDomain, "generated");

            foreach (var entity in Module.Entities)
            {
                string pathEntity = CreateFolder(pathGenerated, entity.EntityName);
                apiFacadeProxyTemplate = new ApiFacadeProxyTemplate();
                apiFacadeProxyTemplate.Session = new Dictionary<string, object>();

                var module = this.Module;
                var screensList = entity.Screens;
                apiFacadeProxyTemplate.Session["module"] = module;
                apiFacadeProxyTemplate.Session["entity"] = entity.EntityName;
                apiFacadeProxyTemplate.Session["screens"] = screensList;
                apiFacadeProxyTemplate.Session["facade"] = entity.Facade;

                apiFacadeProxyTemplate.Initialize();

                string path = pathEntity;
                path += "/" + entity.EntityName + ".cs";

                string pageContent = apiFacadeProxyTemplate.TransformText();
                System.IO.File.WriteAllText(path.ToString(), pageContent);
            }
        }



    }
}
