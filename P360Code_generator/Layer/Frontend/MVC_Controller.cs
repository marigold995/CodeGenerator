﻿using _360Generator.Metadata;
using _360Generator.Templates.Frontend.MVC.Controller;

namespace _360Generator.Layer.Frontend
{
    internal class MVC_Controller : LayerBase
    {
        public MVC_ControllerTemplate controllerTemplate { get; set; }

        public MVC_Controller(Module controllerModule)
        {
            Module = controllerModule;

            Extension = ExtensionEnum.cs;
            FolderPrefix = "P360.Web." + controllerModule.ModuleName;
        }

        public void CreateMVCControllerTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(RootPath, FolderPrefix);
                string pathLayer = CreateFolder(path0, "Controllers");

                controllerTemplate = new MVC_ControllerTemplate();
                CreateFile(controllerTemplate, entity, pathLayer, "Controller");
            }
        }
    }
}