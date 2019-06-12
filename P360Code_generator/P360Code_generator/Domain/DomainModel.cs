using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Templates;
using _360Generator.Metadata;
using System.IO;

namespace _360Generator.Domain
{
    class DomainModel : RootDomain
    {
        private Module Module { get; set; }
        public DomainModelTemplate domainModelTemplate { get; set; }

        public DomainModel(Module domainModelModule)
        {
            this.Module = domainModelModule;
        }

        public void CreateDomainModelTemplate()
        {            
            string pathDomain = CreateFolder(rootPath, "Domain");

            foreach (var entity in Module.Entities)
            {
                domainModelTemplate = new DomainModelTemplate();               
                domainModelTemplate.Session = new Dictionary<string, object>();

                var module = this.Module;
                var screensList = entity.Screens;
                domainModelTemplate.Session["module"] = module;
                domainModelTemplate.Session["entity"] = entity.EntityName;
                domainModelTemplate.Session["screens"] = screensList;

                domainModelTemplate.Initialize();

                string path = pathDomain;
                path += "/" + entity.EntityName + ".cs";

                string pageContent = domainModelTemplate.TransformText();
                System.IO.File.WriteAllText(path.ToString(), pageContent);
            }
        }   
    }
}
