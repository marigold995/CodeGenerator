using _360Generator.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Domain
{
    class RootDomain
    {
        public string CreateFolder(string folderName)
        {
            string path = "../../GeneratedCode/" + folderName;

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
    }
}
