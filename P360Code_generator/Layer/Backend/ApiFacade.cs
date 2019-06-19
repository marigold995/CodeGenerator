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

        public ApiFacade(Module apiFacadeModule)
        {
            Module = apiFacadeModule;

            LayerSuffixList = new List<string>();
            LayerPrefixList = new List<string>();

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
                LayerPrefixList.Add("");
                LayerSuffixList.Add("Converter");
                apiFacadeConverterTemplate = new ApiFacadeConverterTemplate();
                InitializeParameters(apiFacadeConverterTemplate, entity, pathLayerConverter);

                string pathLayerFacade = CreateFolder(pathEntity, "Facade");
                LayerPrefixList.Add("");
                LayerSuffixList.Add("Facade");
                apiFacadeFacadeTemplate = new ApiFacadeFacadeTemplate();
                InitializeParameters(apiFacadeFacadeTemplate, entity, pathLayerFacade);
                LayerPrefixList.Add("I");
                LayerSuffixList.Add("Facade");
                apiFacadeFacadeInterfaceTemplate = new ApiFacadeFacadeInterfaceTemplate();
                InitializeParameters(apiFacadeFacadeInterfaceTemplate, entity, pathLayerFacade);

                string pathLayerService = CreateFolder(pathEntity, "Service");
                LayerPrefixList.Add("");
                LayerSuffixList.Add("Service");
                apiFacadeServiceTemplate = new ApiFacadeServiceTemplate();
                InitializeParameters(apiFacadeServiceTemplate, entity, pathLayerService);
                LayerPrefixList.Add("I");
                LayerSuffixList.Add("Service");
                apiFacadeServiceInterfaceTemplate = new ApiFacadeServiceInterfaceTemplate();
                InitializeParameters(apiFacadeServiceInterfaceTemplate, entity, pathLayerService);
            }
        }        
    }
}
