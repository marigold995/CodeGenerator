using _360Generator.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Domain;

namespace _360Generator.Domain
{
    abstract class RootDomain
    {
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



        //public void InitializeParameters(Module module, Object temp)
        //{
        //    Type templateType = temp.GetType();
        //    var typedObject = Convert.ChangeType(temp, templateType);
        //    temp = Activator.CreateInstance(templateType);
        //    int a = 10;
            
        //    //dynamic template = Convert.ChangeType(temp, templateType);     
            
        //   // var temp = new 
        //    //template.Session = new Dictionary<string, object>();
        //    ////string moduleName = this.Module.ModuleName;

        //    //var module = this.Module;
        //    //var screensList = entity.Screens;
        //    //apiWebControllerTemplate.Session["module"] = module;
        //    //apiWebControllerTemplate.Session["entity"] = entity.EntityName;
        //    //apiWebControllerTemplate.Session["screens"] = screensList;

        //    //apiWebControllerTemplate.Initialize();
        //}
    }
}
