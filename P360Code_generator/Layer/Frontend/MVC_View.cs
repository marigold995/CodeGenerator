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

        public MVC_View(Module viewModule)
        {
            Module = viewModule;

            LayerSuffixList = new List<string>();
            LayerPrefixList = new List<string>();

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
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("Create");
                    createViewTemplate = new MVC_CreateViewTemplate();
                    InitializeParameters(createViewTemplate, entity, pathLayerEntity);
                }
                if (entity.Screens.Contains(Entity.screenEnum.Get))
                {
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("Detail");
                    detailsViewTemplate = new MVC_DetailsViewTemplate();
                    InitializeParameters(detailsViewTemplate, entity, pathLayerEntity);

                }
                if (entity.Screens.Contains(Entity.screenEnum.GetAll))
                {
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("List");
                    listViewTemplate = new MVC_ListViewTemplate();
                    InitializeParameters(listViewTemplate, entity, pathLayerEntity);

                }
                if (entity.Screens.Contains(Entity.screenEnum.Put))
                {
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("Update");
                    updateViewTemplate = new MVC_UpdateViewTemplate();
                    InitializeParameters(updateViewTemplate, entity, pathLayerEntity);
                }
            }
        }
    }
}
