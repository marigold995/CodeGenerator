using _360Generator.Metadata;
using _360Generator.Layer.Frontend;
using _360Generator.Layer.Backend;
using _360Generator.Exceptions;

namespace _360Generator.Generator
{
    public class Generator
    {
        public Module Module { get; set; }

        public Generator(Module newModule)
        {
            this.Module = newModule;
        }

        public void Generate()
        {
            try { 
                CreateBackend();            
            }
            catch
            {
                throw new CreateBackendException("Create backend attempt failed! ");
            }
            try
            {               
                CreateFrontend();
            }
            catch
            {
                throw new CreateFrontendException("Create frontend attempt failed! ");
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
