using _360Generator.Exceptions;
using _360Generator.Metadata;
using _360Generator.Templates;
using System;
using System.Collections.Generic;
using System.IO;

namespace _360Generator.Layer
{
    public abstract class LayerBase
    {
        public enum ExtensionEnum
        {
            cs,
            ts,
            cshtml
        }

        public ExtensionEnum Extension { get; set; }
        public string LayerSuffix { get; set; }
        public string LayerPrefix { get; set; }
        public string FolderPrefix { get; set; }

        protected Module Module { get; set; }

        public static string RootPath { get; set; }

        protected LayerBase()
        {
            LayerSuffix = "";
            LayerPrefix = "";
        }

        public static void SetBasePath(string path)
        {
            RootPath = path;
        }

        public string CreateFolder(string path, string folderName)
        {
            path = Path.Combine(path, folderName);

            try
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                throw new CreateFolderException("Create folder attempt failed. ", e.InnerException);
            }
            return path;
        }

        public void CreateFile(ITemplate template, Entity entity, string path, string suffix = "", string prefix = "")
        {
            LayerPrefix = prefix;
            LayerSuffix = suffix;
            InitializeParameters(template, entity, path);
        }

        public void InitializeParameters(ITemplate template, Entity entity, string pathLayer)
        {
            template.Session = new Dictionary<string, object>();
            var screensList = entity.Screens;
            template.Session["module"] = Module;
            template.Session["entity"] = entity.EntityName;
            template.Session["screens"] = screensList;
            template.Initialize();
            string layerName = LayerPrefix + entity.EntityName + LayerSuffix;
            string fullPath = GetFullPath(pathLayer, layerName, Extension.ToString());
            TransformAndWrite(fullPath, template);
        }

        private string GetFullPath(string pathLayer, string layerName, string extension)
        {
            pathLayer = Path.Combine(pathLayer, layerName);
            pathLayer = Path.ChangeExtension(pathLayer, extension);
            return pathLayer;
        }

        private void TransformAndWrite(string path, ITemplate template)
        {
            string pageContent = template.TransformText();
            System.IO.File.WriteAllText(path, pageContent);
        }
    }
}