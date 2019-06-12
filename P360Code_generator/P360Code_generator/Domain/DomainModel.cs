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
            domainModelTemplate = new DomainModelTemplate();
            domainModelTemplate.Session = new Dictionary<string, object>();
            string moduleName = this.Module.ModuleName;
            domainModelTemplate.Session["module"] = moduleName;
            domainModelTemplate.Initialize();

            //string path = CreateFolder("Controllers");
            //path += moduleName + "Profile.cs";

            //string pageContent = domainModelTemplate.TransformText();
            //System.IO.File.WriteAllText(path.ToString(), pageContent);
        }   
    }
}
