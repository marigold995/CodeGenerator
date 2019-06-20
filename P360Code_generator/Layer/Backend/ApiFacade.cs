using System.Collections.Generic;
using _360Generator.Metadata;
using _360Generator.Templates.Backend.Facade;

namespace _360Generator.Layer.Backend
{
    class ApiFacade : LayerBase
    {
        public ApiFacadeConverterTemplate apiFacadeConverterTemplate { get; set; }
        public ApiFacadeServiceTemplate apiFacadeServiceTemplate { get; set; }
        public ApiFacadeFacadeTemplate apiFacadeFacadeTemplate { get; set; }
        public ApiFacadeFacadeInterfaceTemplate apiFacadeFacadeInterfaceTemplate { get; set; }
        public ApiFacadeServiceInterfaceTemplate apiFacadeServiceInterfaceTemplate { get; set; }

        public ApiFacade(Module apiFacadeModule) : base()
        {
            Module = apiFacadeModule;

            Extension = ExtensionEnum.cs;
            FolderPrefix = "360.Api.Facade.";
        }

        public void CreateApiFacadeTemplate()
        {            
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix + entity.Facade + "." + Module.ModuleName);
                string pathGenerated = CreateFolder(path0, "generated");
                string pathEntity = CreateFolder(pathGenerated, entity.EntityName);

                string pathLayerConverter = CreateFolder(pathEntity, "Converter");
                apiFacadeConverterTemplate = new ApiFacadeConverterTemplate();               
                CreateFile(apiFacadeConverterTemplate, entity, pathLayerConverter, "Converter");         

                string pathLayerFacade = CreateFolder(pathEntity, "Facade");                
                apiFacadeFacadeTemplate = new ApiFacadeFacadeTemplate();
                CreateFile(apiFacadeFacadeTemplate, entity, pathLayerFacade, "Facade");
                apiFacadeFacadeInterfaceTemplate = new ApiFacadeFacadeInterfaceTemplate();
                CreateFile(apiFacadeFacadeInterfaceTemplate, entity, pathLayerFacade, "Facade", "I");

                string pathLayerService = CreateFolder(pathEntity, "Service");               
                apiFacadeServiceTemplate = new ApiFacadeServiceTemplate();
                CreateFile(apiFacadeServiceTemplate, entity, pathLayerService, "Service");
                apiFacadeServiceInterfaceTemplate = new ApiFacadeServiceInterfaceTemplate();
                CreateFile(apiFacadeServiceTemplate, entity, pathLayerService, "Service", "I");
            }
        }        
    }
}
