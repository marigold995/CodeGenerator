using _360Generator.Metadata;
using _360Generator.Layer.Frontend;
using _360Generator.Layer.Backend;
using _360Generator.Exceptions;
using _360Generator.Layer;
using System;

namespace _360Generator.Generator
{
    public class Generator
    {
        public Module Module { get; set; }

        public Generator(Module newModule)
        {
            Module = newModule;
        }

        public void Generate(string basePath)
        {
            LayerBase.SetBasePath(basePath);
            try { 
                CreateBackend();            
            }
            catch(Exception e)
            {
                throw new CreateBackendException("Create backend attempt failed! ", e.InnerException);
            }
            try
            {               
                CreateFrontend();
            }
            catch(Exception e)
            {
                throw new CreateFrontendException("Create frontend attempt failed! ", e.InnerException);
            }
        }

        public void CreateBackend()
        {
            var apiWebController = new ApiWebController(Module);
            apiWebController.CreateApiWebControllerTemplate();

            var apiRepository = new ApiRepository(Module);
            apiRepository.CreateApiRepositoryTemplate();

            var apiModelDTO = new ApiModelDTO(Module);
            apiModelDTO.CreateApiModelTemplate();

            var apiFacadeProxy = new ApiFacadeProxy(Module);
            apiFacadeProxy.CreateApiFacadeProxyTemplate();

            var apiFacade = new ApiFacade(Module);
            apiFacade.CreateApiFacadeTemplate();

            var domainModel = new DomainModel(Module);
            domainModel.CreateDomainModelTemplate();
        }

        public void CreateFrontend()
        {
            var portalData = new PortalData(Module);
            portalData.CreatePortalDataTemplate();

            var portalInitializer = new PortalInitializer(Module);
            portalInitializer.CreatePortalInitializerTemplate();

            var portalModel = new PortalModel(Module);
            portalModel.CreatePortalModelTemplate();

            var portalValidator = new PortalValidator(Module);
            portalValidator.CreatePortalValidatorTemplate();

            var portalView = new PortalView(Module);
            portalView.CreatePortalViewTemplate();

            var portalViewModel = new PortalViewModel(Module);
            portalViewModel.CreatePortalViewModelTemplate();

            var mvcController = new MVC_Controller(Module);
            mvcController.CreateMVCControllerTemplate();

            var mvcView = new MVC_View(Module);
            mvcView.CreateMVCViewTemplate();
        }

    }
}
