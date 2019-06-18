using P360Code_generator.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P360Code_generator.Domain
{
    class ApiRepository
    {
        private Module Module;
        public ApiInterfaceRepositoryTemplate apiInterfaceRepositoryTemplate { get; set; }
        public ApiRepositoryTemplate apiRepositoryTemplate { get; set; }

        public ApiRepository(Module repositoryModule)
        {
            this.Module = repositoryModule;
        }

        public void CreateApiInterfaceRepositoryTemplate()
        {
            apiInterfaceRepositoryTemplate = new ApiInterfaceRepositoryTemplate();
            apiInterfaceRepositoryTemplate.Session = new Dictionary<string, object>();
            string moduleName = this.Module.ModuleName;
            apiInterfaceRepositoryTemplate.Session["module"] = moduleName;
            apiInterfaceRepositoryTemplate.Initialize();

            StringBuilder path = new StringBuilder("../../GeneratedCode/I");
            path.Append(moduleName + "ProfileRepository.cs");


            //StringBuilder path = new StringBuilder("../../../360.Api.Repository.");
            //path.Append(moduleName + "/I" + moduleName + "ProfileRepositoryNEW.cs");

            string pageContent = apiInterfaceRepositoryTemplate.TransformText();
            System.IO.File.WriteAllText(path.ToString(), pageContent);
            this.CreateApiRepositoryTemplate();
        }

        public void CreateApiRepositoryTemplate()
        {
            apiRepositoryTemplate = new ApiRepositoryTemplate();
            apiRepositoryTemplate.Session = new Dictionary<string, object>();
            string moduleName = this.Module.ModuleName;
            apiRepositoryTemplate.Session["module"] = moduleName;
            apiRepositoryTemplate.Initialize();

            StringBuilder path = new StringBuilder("../../GeneratedCode/");
            path.Append(moduleName + "ProfileRepository.cs");

            //StringBuilder path = new StringBuilder("../../../360.Api.Repository.");
            //path.Append(moduleName + "/" + moduleName + "ProfileRepositoryNEW.cs");

            string pageContent = apiRepositoryTemplate.TransformText();
            System.IO.File.WriteAllText(path.ToString(), pageContent);
        }
    }
}