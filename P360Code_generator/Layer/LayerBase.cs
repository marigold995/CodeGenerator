using _360Generator.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Domain;
using _360Generator.Templates;


namespace _360Generator.Domain
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
        public List<string> LayerSuffixList { get; set; }        
        public List<string> LayerPrefixList { get; set; }
        public string FolderPrefix { get; set; }        

        protected Module Module { get; set; }
        //protected string path0 { get; set; }
        public string rootPath = "../../GeneratedCode";
        public string CreateFolder(string path, string folderName)
        {
            //string path = "../../GeneratedCode/" + folderName;
            path += "/" + folderName;

            try
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

            return path;
        }

        public void InitializeParameters(ITemplate template, Entity entity, string pathLayer)
        {          
            template.Session = new Dictionary<string, object>();
            var screensList = entity.Screens;
            template.Session["module"] = Module;
            template.Session["entity"] = entity.EntityName;
            template.Session["screens"] = screensList;
            template.Initialize();

            List<string> pathList = new List<string>();            
            pathList.Add(pathLayer + "/" + LayerPrefixList[LayerPrefixList.Count-1] + entity.EntityName + LayerSuffixList[LayerSuffixList.Count-1] + "." + Extension);
                       
            string pageContent = template.TransformText();
            System.IO.File.WriteAllText(pathList[pathList.Count-1].ToString(), pageContent);
        }

    }
}
