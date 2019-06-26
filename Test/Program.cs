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
            var moduleCyberDetection = new Module("CyberDetection");            

            Entity cyberDetectionProfile = new Entity("CyberDetectionProfile").AddScreenCreate()
                                                                              .AddScreenDetails()
                                                                              .AddScreenList()
                                                                              .AddScreenUpdate()
                                                                              .AddGBMFacade(); 

            Entity cyberService = new Entity("CyberService").AddScreenList()
                                                            .AddGBMFacade();
            
            Entity securityAndItPolicy = new Entity("SecurityAndItPolicy").AddScreenList()
                                                                          .AddScreenDetails()
                                                                          .AddScreenCreate()
                                                                          .AddScreenUpdate()
                                                                          .AddScreenDelete()
                                                                          .AddGBMFacade(); 

            Entity zoneProfile = new Entity("ZoneProfile").AddScreenList()
                                                          .AddScreenDetails()
                                                          .AddScreenCreate()
                                                          .AddScreenUpdate()
                                                          .AddScreenDelete()
                                                          .AddGBMFacade();

            moduleCyberDetection.AddEntity(cyberDetectionProfile)
                     .AddEntity(cyberService)
                     .AddEntity(securityAndItPolicy)
                     .AddEntity(zoneProfile);
            
            //var moduleInmarsat = new Module("Inmarsat");

            //Entity idpSubscription = new Entity("IdpSubscription").AddScreenCreate()
            //                                                       .AddScreenDetails()
            //                                                       .AddScreenList()
            //                                                       .AddScreenUpdate()
            //                                                       .AddABMFacade();

            //Entity gateway = new Entity("Gateway").AddScreenList().AddABMFacade();
            //moduleInmarsat.AddEntity(idpSubscription).AddEntity(gateway);

            Generator.AddModule(moduleCyberDetection);
            //Generator.AddModule(moduleInmarsat);
            Generator.Generate("..\\..\\GeneratedCode");            

            Console.ReadKey();
        }
    }
}
