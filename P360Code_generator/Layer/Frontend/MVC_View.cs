using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Metadata;
using _360Generator.Templates.Frontend.MVC.View;

namespace _360Generator.Layer.Frontend
{
    class MVC_View: LayerBase
    {
        public MVC_CreateViewTemplate createViewTemplate{ get; set; }
        public MVC_DetailsViewTemplate detailsViewTemplate{ get; set; }
        public MVC_ListViewTemplate listViewTemplate{ get; set; }
        public MVC_UpdateViewTemplate updateViewTemplate{ get; set; }

        public MVC_View(Module viewModule) : base()
        {
            Module = viewModule;

            Extension = ExtensionEnum.cshtml;
            FolderPrefix = "P360.Web." + viewModule.ModuleName;
        }

        public void CreateMVCViewTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix);
                string pathLayer = CreateFolder(path0, "Views");
                string pathLayerEntity = CreateFolder(pathLayer, entity.EntityName);

                if (entity.Screens.Contains(Entity.screenEnum.Post))
                {                    
                    createViewTemplate = new MVC_CreateViewTemplate();
                    CreateFile(createViewTemplate, entity, pathLayer, "Create");
                }
                if (entity.Screens.Contains(Entity.screenEnum.Get))
                {
                    detailsViewTemplate = new MVC_DetailsViewTemplate();
                    CreateFile(detailsViewTemplate, entity, pathLayer, "Detail");
                }
                if (entity.Screens.Contains(Entity.screenEnum.GetAll))
                {
                    listViewTemplate = new MVC_ListViewTemplate();
                    CreateFile(listViewTemplate, entity, pathLayer, "List");
                }
                if (entity.Screens.Contains(Entity.screenEnum.Put))
                {
                    updateViewTemplate = new MVC_UpdateViewTemplate();
                    CreateFile(updateViewTemplate, entity, pathLayer, "Update");
                }
            }
        }
    }
}
