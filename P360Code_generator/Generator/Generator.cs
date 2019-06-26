using _360Generator.Metadata;
using _360Generator.Layer.Frontend;
using _360Generator.Layer.Backend;
using _360Generator.Exceptions;
using _360Generator.Layer;
using System;
using System.Collections.Generic;

namespace _360Generator.Generator
{
    public static class Generator
    {
        public static List<Module> Modules = new List<Module>();  

        public static void AddModule(Module module)
        {           
            Modules.Add(module);
        }

        public static void Generate(string basePath)
        {
            BaseLayer.SetBasePath(basePath);
            foreach (var module in Modules)
            {
                try
                {
                    CreateBackend(module);
                }
                catch (Exception e)
                {
                    throw new CreateBackendException("Create backend attempt failed! ", e.InnerException);
                }
                try
                {
                    CreateFrontend(module);
                }
                catch (Exception e)
                {
                    throw new CreateFrontendException("Create frontend attempt failed! ", e.InnerException);
                }
            }
        }

        public static void CreateBackend(Module module)
        {
            var apiWebController = new ApiWebController(module);
            apiWebController.CreateApiWebControllerTemplate();

            var apiRepository = new ApiRepository(module);
            apiRepository.CreateApiRepositoryTemplate();

            var apiModelDTO = new ApiModelDTO(module);
            apiModelDTO.CreateApiModelTemplate();

            var apiFacadeProxy = new ApiFacadeProxy(module);
            apiFacadeProxy.CreateApiFacadeProxyTemplate();

            var apiFacade = new ApiFacade(module);
            apiFacade.CreateApiFacadeTemplate();

            var domainModel = new DomainModel(module);
            domainModel.CreateDomainModelTemplate();
        }

        public static void CreateFrontend(Module module)
        {
            var portalData = new PortalData(module);
            portalData.CreatePortalDataTemplate();

            var portalInitializer = new PortalInitializer(module);
            portalInitializer.CreatePortalInitializerTemplate();

            var portalModel = new PortalModel(module);
            portalModel.CreatePortalModelTemplate();

            var portalValidator = new PortalValidator(module);
            portalValidator.CreatePortalValidatorTemplate();

            var portalView = new PortalView(module);
            portalView.CreatePortalViewTemplate();

            var portalViewModel = new PortalViewModel(module);
            portalViewModel.CreatePortalViewModelTemplate();

            var mvcController = new MVC_Controller(module);
            mvcController.CreateMVCControllerTemplate();

            var mvcView = new MVC_View(module);
            mvcView.CreateMVCViewTemplate();
        }
    }
}
