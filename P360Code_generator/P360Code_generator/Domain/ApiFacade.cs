using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Metadata;
using _360Generator.Templates;
using _360Generator.Templates.Backend.Facade;

namespace _360Generator.Domain
{
    class ApiFacade : RootDomain
    {
        private Module Module { get; set; }
        public ApiFacadeConverterTemplate apiFacadeConverterTemplate { get; set; }
        public ApiFacadeServiceTemplate apiFacadeServiceTemplate { get; set; }
        public ApiFacadeFacadeTemplate apiFacadeFacadeTemplate { get; set; }
        public ApiFacadeFacadeInterfaceTemplate apiFacadeFacadeInterfaceTemplate { get; set; }
        public ApiFacadeServiceInterfaceTemplate apiFacadeServiceInterfaceTemplate { get; set; }

        public ApiFacade(Module apiFacadeModule)
        {
            this.Module = apiFacadeModule;
        }

        public void CreateApiFacadeTemplate()
        {
            //string pathDomain = CreateFolder(rootPath, "Facade");
            //string pathGenerated = CreateFolder(pathDomain, "generated");

            foreach (var entity in Module.Entities)
            {
                var module = this.Module;
                var screensList = entity.Screens;

                string path0 = CreateFolder(rootPath, "360.Api.Facade." + entity.Facade + "." + Module.ModuleName);

                //string pathFacadeType = CreateFolder(pathDomain, entity.Facade.ToString());
                string pathGenerated = CreateFolder(path0, "generated");
                string pathEntity = CreateFolder(pathGenerated, entity.EntityName);
                string pathEntityConverter = CreateFolder(pathEntity, "Converter");
                string pathEntityFacade = CreateFolder(pathEntity, "Facade");
                string pathEntityService = CreateFolder(pathEntity, "Service");

                //converter
                apiFacadeConverterTemplate = new ApiFacadeConverterTemplate();
                apiFacadeConverterTemplate.Session = new Dictionary<string, object>();
                
                apiFacadeConverterTemplate.Session["module"] = module;
                apiFacadeConverterTemplate.Session["entity"] = entity.EntityName;
                apiFacadeConverterTemplate.Session["screens"] = screensList;
                apiFacadeConverterTemplate.Session["facade"] = entity.Facade;

                apiFacadeConverterTemplate.Initialize();

                string pathConverter = pathEntityConverter;
                pathConverter += "/" + entity.EntityName + "Converter.cs";

                string pageContentConverter = apiFacadeConverterTemplate.TransformText();
                System.IO.File.WriteAllText(pathConverter.ToString(), pageContentConverter);

                // facade interface
                apiFacadeFacadeInterfaceTemplate = new ApiFacadeFacadeInterfaceTemplate();
                apiFacadeFacadeInterfaceTemplate.Session = new Dictionary<string, object>();

                apiFacadeFacadeInterfaceTemplate.Session["module"] = module;
                apiFacadeFacadeInterfaceTemplate.Session["entity"] = entity.EntityName;
                apiFacadeFacadeInterfaceTemplate.Session["screens"] = screensList;
                apiFacadeFacadeInterfaceTemplate.Session["facade"] = entity.Facade;

                apiFacadeFacadeInterfaceTemplate.Initialize();

                string pathFacadeInterface = pathEntityFacade;
                pathFacadeInterface += "/I" + entity.EntityName + "Facade.cs";

                string pageContentFacadeInterface = apiFacadeFacadeInterfaceTemplate.TransformText();
                System.IO.File.WriteAllText(pathFacadeInterface.ToString(), pageContentFacadeInterface);

                // facade
                apiFacadeFacadeTemplate = new ApiFacadeFacadeTemplate();
                apiFacadeFacadeTemplate.Session = new Dictionary<string, object>();

                apiFacadeFacadeTemplate.Session["module"] = module;
                apiFacadeFacadeTemplate.Session["entity"] = entity.EntityName;
                apiFacadeFacadeTemplate.Session["screens"] = screensList;
                apiFacadeFacadeTemplate.Session["facade"] = entity.Facade;

                apiFacadeFacadeTemplate.Initialize();

                string pathFacade = pathEntityFacade;
                pathFacade += "/" + entity.EntityName + "Facade.cs";

                string pageContentFacade = apiFacadeFacadeTemplate.TransformText();
                System.IO.File.WriteAllText(pathFacade.ToString(), pageContentFacade);


                // service interface
                apiFacadeServiceInterfaceTemplate = new ApiFacadeServiceInterfaceTemplate();
                apiFacadeServiceInterfaceTemplate.Session = new Dictionary<string, object>();

                apiFacadeServiceInterfaceTemplate.Session["module"] = module;
                apiFacadeServiceInterfaceTemplate.Session["entity"] = entity.EntityName;
                apiFacadeServiceInterfaceTemplate.Session["screens"] = screensList;
                apiFacadeServiceInterfaceTemplate.Session["facade"] = entity.Facade;

                apiFacadeServiceInterfaceTemplate.Initialize();

                string pathServiceInterface = pathEntityService;
                pathServiceInterface += "/I" + entity.EntityName + "Service.cs";

                string pageContentServiceInterface = apiFacadeServiceInterfaceTemplate.TransformText();
                System.IO.File.WriteAllText(pathServiceInterface.ToString(), pageContentServiceInterface);

                // service
                apiFacadeServiceTemplate = new ApiFacadeServiceTemplate();
                apiFacadeServiceTemplate.Session = new Dictionary<string, object>();

                apiFacadeServiceTemplate.Session["module"] = module;
                apiFacadeServiceTemplate.Session["entity"] = entity.EntityName;
                apiFacadeServiceTemplate.Session["screens"] = screensList;
                apiFacadeServiceTemplate.Session["facade"] = entity.Facade;

                apiFacadeServiceTemplate.Initialize();

                string pathService = pathEntityService;
                pathService += "/" + entity.EntityName + "Service.cs";

                string pageContentService = apiFacadeServiceTemplate.TransformText();
                System.IO.File.WriteAllText(pathService.ToString(), pageContentService);
            }
        }
    }
}
