﻿using _360Generator.Generator;
using _360Generator.Metadata;
using System;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var newModule = new Module("CyberDetection");

            Entity cyberDetectionProfile = new Entity("CyberDetectionProfile").AddScreenCreate().AddScreenDetails().AddScreenList().AddScreenUpdate().AddGBMFacade();
            Entity cyberService = new Entity("CyberService").AddScreenList().AddGBMFacade();
            Entity securityAndItPolicy = new Entity("SecurityAndItPolicy").AddScreenList().AddScreenDetails().AddScreenCreate().AddScreenUpdate().AddScreenDelete().AddGBMFacade();
            Entity zoneProfile = new Entity("ZoneProfile").AddScreenList().AddScreenDetails().AddScreenCreate().AddScreenUpdate().AddScreenDelete().AddGBMFacade();

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