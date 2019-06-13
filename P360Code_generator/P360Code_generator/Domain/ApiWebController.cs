using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Templates;
using _360Generator.Metadata;
using System.IO;
using _360Generator.Domain;
using _360Generator.Templates.Backend.Controller;

namespace _360Generator
{
    class ApiWebController: RootDomain
    {
        private Module Module { get; set; }
        public ApiWebControllerTemplate apiWebControllerTemplate { get; set; }

        public ApiWebController(Module apiWebModule)
        {
            this.Module = apiWebModule;            
        }

        public void CreateApiWebControllerTemplate()
        {
            string path0 = CreateFolder(rootPath, "360.Api.Web." + Module.ModuleName);
            string pathDomain = CreateFolder(path0, "Controllers");

            foreach (var entity in Module.Entities)
            {                
                apiWebControllerTemplate = new ApiWebControllerTemplate();
               //InitializeParameters(this.Module, apiWebControllerTemplate);
                apiWebControllerTemplate.Session = new Dictionary<string, object>();                
                
                var module = this.Module;
                var screensList = entity.Screens;
                apiWebControllerTemplate.Session["module"] = module;
                apiWebControllerTemplate.Session["entity"] = entity.EntityName;
                apiWebControllerTemplate.Session["screens"] = screensList;

                apiWebControllerTemplate.Initialize();
                
                string path = pathDomain;
                path += "/" + entity.EntityName + "Controller.cs";

                string pageContent = apiWebControllerTemplate.TransformText();
                System.IO.File.WriteAllText(path.ToString(), pageContent);
            }
        }
       
    }
}
