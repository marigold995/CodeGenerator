using System.Collections.Generic;
using _360Generator.Metadata;
using _360Generator.Templates.Backend.FacadeProxy;

namespace _360Generator.Layer.Backend
{
    class ApiFacadeProxy : BackendLayerBase
    {
        public ApiFacadeProxyTemplate apiFacadeProxyTemplate { get; set; }

        public ApiFacadeProxy(Module apiFacadeProxyModule): base()
        {
            Module = apiFacadeProxyModule; 
            FolderPrefix = "360.Api.FacadeProxy.";
        }            

        public void CreateApiFacadeProxyTemplate()
        {
            string path0 = CreateFolder(rootPath, FolderPrefix + Module.ModuleName);
            string pathGenerated = CreateFolder(path0, "generated");

            foreach (var entity in Module.Entities)
            {         
                string pathLayer = CreateFolder(pathGenerated, entity.EntityName);                
                apiFacadeProxyTemplate = new ApiFacadeProxyTemplate();
                CreateFile(apiFacadeProxyTemplate, entity, pathLayer);
            }
        }
    }
}
