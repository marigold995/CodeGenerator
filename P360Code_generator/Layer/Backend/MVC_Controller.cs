using System.Collections.Generic;
using _360Generator.Metadata;
using _360Generator.Templates.Backend.MVC.Controller;

namespace _360Generator.Layer.Backend
{
    class MVC_Controller: BackendLayerBase
    {
        public MVC_ControllerTemplate controllerTemplate { get; set; }

        public MVC_Controller(Module controllerModule) : base()
        {
            Module = controllerModule;
            FolderPrefix = "P360.Web." + controllerModule.ModuleName;
        }

        public void CreateMVCControllerTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix);
                string pathLayer = CreateFolder(path0, "Controllers");

                controllerTemplate = new MVC_ControllerTemplate();
                CreateFile(controllerTemplate, entity, pathLayer, "Controller");
            }
        }
    }
}
