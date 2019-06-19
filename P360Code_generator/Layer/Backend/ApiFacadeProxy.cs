using System.Collections.Generic;
using _360Generator.Metadata;
using _360Generator.Templates.Backend.FacadeProxy;

namespace _360Generator.Layer.Backend
{
    class ApiFacadeProxy : LayerBase
    {
        public ApiFacadeProxyTemplate apiFacadeProxyTemplate { get; set; }

        public ApiFacadeProxy(Module apiFacadeProxyModule)
        {
            Module = apiFacadeProxyModule;

            LayerPrefixList = new List<string>();
            LayerSuffixList = new List<string>();

            Extension = ExtensionEnum.cs;
            FolderPrefix = "360.Api.FacadeProxy.";
        }            

        public void CreateApiFacadeProxyTemplate()
        {
            string path0 = CreateFolder(rootPath, FolderPrefix + Module.ModuleName);
            string pathGenerated = CreateFolder(path0, "generated");

            foreach (var entity in Module.Entities)
            {         
                string pathLayer = CreateFolder(pathGenerated, entity.EntityName);
                LayerPrefixList.Add("");
                LayerSuffixList.Add("");
                apiFacadeProxyTemplate = new ApiFacadeProxyTemplate();
                InitializeParameters(apiFacadeProxyTemplate, entity, pathLayer);               
            }
        }
    }
}
