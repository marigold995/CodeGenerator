using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Frontend
{
    public abstract class FrontendBaseLayer : BaseLayer
    {
        public FrontendBaseLayer() : base()
        {
            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";
        }

        public string CreateFrontendFolders(string moduleName, string entityName, string categoryName)
        {
            string path0 = CreateFolder(rootPath, FolderPrefix);
            string pathDomain = CreateFolder(path0, "Scripts");
            string pathApp = CreateFolder(pathDomain, "App");
            string pathModule = CreateFolder(pathApp, moduleName);
            string pathEntity = CreateFolder(pathModule, entityName);
            string pathFinal = CreateFolder(pathEntity, categoryName);
            return pathFinal;
        }
    }
}
