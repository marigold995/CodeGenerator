using P360Code_generator.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P360Code_generator.Domain
{
    class DomainModel
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

            StringBuilder path = new StringBuilder("../../GeneratedCode/");
            path.Append(moduleName + "Profile.cs");       

            string pageContent = domainModelTemplate.TransformText();
            System.IO.File.WriteAllText(path.ToString(), pageContent);
        }
    }
}
