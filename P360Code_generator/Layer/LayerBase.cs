using _360Generator.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using _360Generator.Templates;
using _360Generator.Exceptions;


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

        public static string rootPath { get; set; }

        public LayerBase()
        {
            LayerSuffix = "";
            LayerPrefix = "";
        }

        public static void SetBasePath(string path)
        {
            rootPath = path;
        }

        public string CreateFolder(string path, string folderName)
        {
            path = Path.Combine(path,folderName);

            try
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            catch
            {
                throw new CreateFolderException("Create folder attempt failed. ");
            }
            return path;
        }

        public void CreateFile(ITemplate template, Entity entity, string path,  string suffix = "", string prefix = "")
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

            string path = Path.Combine(pathLayer, layerName);
            string fullPath = Path.ChangeExtension(path, Extension.ToString());
            
                //pathList.Add(pathLayer + "/" + LayerPrefix + entity.EntityName + LayerSuffix + "." + Extension);
                       
            string pageContent = template.TransformText();
            System.IO.File.WriteAllText(fullPath, pageContent);
        }
    }
}
