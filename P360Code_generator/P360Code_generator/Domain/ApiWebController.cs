using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Templates;
using _360Generator.Metadata;
using System.IO;
using _360Generator.Domain;

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
            string path1 = CreateFolder("Controllers");

            foreach (var entity in Module.Entities)
            {                
                apiWebControllerTemplate = new ApiWebControllerTemplate();
                
                apiWebControllerTemplate.Session = new Dictionary<string, object>();
                //string moduleName = this.Module.ModuleName;
                
                var module = this.Module;
                var screensList = entity.Screens;
                apiWebControllerTemplate.Session["module"] = module;
                apiWebControllerTemplate.Session["entity"] = entity.EntityName;
                apiWebControllerTemplate.Session["screens"] = screensList;

                apiWebControllerTemplate.Initialize();

                //StringBuilder path = new StringBuilder("../../GeneratedCode/");
                //path.Append(entity.EntityName + "Controller.cs");
                string path = path1;
                path += "/" + entity.EntityName + "Controller.cs";

                //StringBuilder path = new StringBuilder("../../../360.Api.Web.");
                //path.Append(moduleName + "/Controllers/" + moduleName + "ProfileControllerNEW.cs");

                string pageContent = apiWebControllerTemplate.TransformText();
                System.IO.File.WriteAllText(path.ToString(), pageContent);
            }
        }
       
    }
}
