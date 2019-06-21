using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Metadata;
using _360Generator.Generator;
using _360Generator.Layer;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {           
            var newModule = new Module("CyberDetection");            

            Entity cyberDetectionProfile = new Entity("CyberDetectionProfile").AddScreenCreate().AddScreenDetails().AddScreenList().AddScreenUpdate().AddGBMFacade(); 
            Entity cyberService = new Entity("CyberService").AddScreenList().AddGBMFacade(); 
            Entity securityAndItPolicy = new Entity("SecurityAndItPolicy").AddScreenList().AddScreenDetails().AddScreenCreate().AddScreenUpdate().AddGBMFacade(); 
            Entity zoneProfile = new Entity("ZoneProfile").AddScreenList().AddScreenDetails().AddScreenCreate().AddScreenUpdate().AddGBMFacade();            

            newModule.AddEntity(cyberDetectionProfile);
            newModule.AddEntity(cyberService);
            newModule.AddEntity(securityAndItPolicy);
            newModule.AddEntity(zoneProfile);
           
            var generator = new Generator(newModule);
            generator.Generate("..\\..\\GeneratedCode");            

            Console.ReadKey();
        }
    }
}
