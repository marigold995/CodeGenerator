using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Frontend
{
    class PortalModel: FrontendBaseLayer
    {
        public PortalModelTemplate portalModelTemplate { get; set; }

        public PortalModel(Module portalModelModule) : base()
        {
            Module = portalModelModule;
        }

        public void CreatePortalModelTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string frontendPath = CreateFrontendFolders(Module.ModuleName, entity.EntityName, "Model");

                portalModelTemplate = new PortalModelTemplate();
                CreateFile(portalModelTemplate, entity, frontendPath);
            }
        }
    }
}
