










import { EntityParameters } from 'App/Base/Framework/EntityParameters';
import { DefaultParameterText } from 'App/Base/Controls/Breadcrumbs/DefaultParameterText';

export class CyberServiceInitializer {
    public static initialize(): void {
        EntityParameters.setParameters('cyberService', new Array());
        
        DefaultParameterText['cyberServiceId'] = 'name';

        System.config({
            map: {
                CyberServiceListView: 'App/_360Generator.Metadata.Module/CyberService/View/cyberServiceListView',
                CyberServiceDetailView: 'App/_360Generator.Metadata.Module/CyberService/View/cyberServiceDetailView',
                CyberServiceCreateView: 'App/_360Generator.Metadata.Module/CyberService/View/cyberServiceCreateView',
                CyberServiceUpdateView: 'App/_360Generator.Metadata.Module/CyberService/View/cyberServiceUpdateView'
            }
        });
    }
}  

