﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Metadata;
using _360Generator.Templates;
using _360Generator.Templates.Backend.ModelDTO;

namespace _360Generator.Domain
{
    class ApiModelDTO : LayerBase
    {
        public ApiModelDTOTemplate apiModelDTOTemplate { get; set; }

        public ApiModelDTO(Module apiModelModule)
        {
            Module = apiModelModule;

            LayerPrefixList = new List<string>();
            LayerSuffixList = new List<string>();

            Extension = ExtensionEnum.cs;
            FolderPrefix = "360.Api.Model.";
        }

        public void CreateApiModelTemplate()
        {
            string path0 = CreateFolder(rootPath, FolderPrefix + Module.ModuleName);
            string pathLayer = path0;

            LayerPrefixList.Add("");
            LayerSuffixList.Add("DTO");

            foreach (var entity in Module.Entities)
            {
                apiModelDTOTemplate = new ApiModelDTOTemplate();
                InitializeParameters(apiModelDTOTemplate, entity, pathLayer);
            }

        }
    }
}
