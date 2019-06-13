﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Metadata;
using _360Generator.Templates;
using _360Generator.Templates.Backend.Repository;

namespace _360Generator.Domain
{
    class ApiRepository : RootDomain
    {
        private Module Module;
        public ApiInterfaceRepositoryTemplate apiInterfaceRepositoryTemplate { get; set; }
        public ApiRepositoryTemplate apiRepositoryTemplate { get; set; }

        public ApiRepository(Module repositoryModule)
        {
            this.Module = repositoryModule;
        }

        public void CreateApiInterfaceRepositoryTemplate()
        {
            string pathDomain = CreateFolder(rootPath, "360.Api.Repository." + Module.ModuleName);

            foreach (var entity in Module.Entities)
            {
                apiInterfaceRepositoryTemplate = new ApiInterfaceRepositoryTemplate();               
                apiInterfaceRepositoryTemplate.Session = new Dictionary<string, object>();

                var module = this.Module;
                var screensList = entity.Screens;
                apiInterfaceRepositoryTemplate.Session["module"] = module;
                apiInterfaceRepositoryTemplate.Session["entity"] = entity.EntityName;
                apiInterfaceRepositoryTemplate.Session["screens"] = screensList;

                apiInterfaceRepositoryTemplate.Initialize();

                string path = pathDomain;
                path += "/I" + entity.EntityName + "Repository.cs";

                string pageContent = apiInterfaceRepositoryTemplate.TransformText();
                System.IO.File.WriteAllText(path.ToString(), pageContent);
            }
            this.CreateApiRepositoryTemplate();
        }

        public void CreateApiRepositoryTemplate()
        {
            string pathDomain = CreateFolder(rootPath, "360.Api.Repository." + Module.ModuleName);
            foreach (var entity in Module.Entities)
            {
                apiRepositoryTemplate = new ApiRepositoryTemplate();
                apiRepositoryTemplate.Session = new Dictionary<string, object>();

                var module = this.Module;
                var screensList = entity.Screens;
                apiRepositoryTemplate.Session["module"] = module;
                apiRepositoryTemplate.Session["entity"] = entity.EntityName;
                apiRepositoryTemplate.Session["screens"] = screensList;

                apiRepositoryTemplate.Initialize();

                string path = pathDomain;
                path += "/" + entity.EntityName + "Repository.cs";

                string pageContent = apiRepositoryTemplate.TransformText();
                System.IO.File.WriteAllText(path.ToString(), pageContent);
            }
        }
    }
}