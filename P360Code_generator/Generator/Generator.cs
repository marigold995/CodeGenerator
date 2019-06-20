using _360Generator.Metadata;
using _360Generator.Layer.Frontend;
using _360Generator.Layer.Backend;

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
            CreateBackend();
            CreateFrontend();
        }

        public void CreateBackend()
        {      
            var apiWebController = new ApiWebController(this.Module);
            apiWebController.CreateApiWebControllerTemplate();

            var apiRepository = new ApiRepository(this.Module);
            apiRepository.CreateApiRepositoryTemplate();

            var apiModelDTO = new ApiModelDTO(this.Module);
            apiModelDTO.CreateApiModelTemplate();

            var apiFacadeProxy = new ApiFacadeProxy(this.Module);
            apiFacadeProxy.CreateApiFacadeProxyTemplate();

            var apiFacade = new ApiFacade(this.Module);
            apiFacade.CreateApiFacadeTemplate();

            var domainModel = new DomainModel(this.Module);
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
