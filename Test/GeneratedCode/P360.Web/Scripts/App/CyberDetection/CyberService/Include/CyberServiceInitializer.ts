import { EntityParameters } from 'App/Base/Framework/EntityParameters';
import { DefaultParameterText } from 'App/Base/Controls/Breadcrumbs/DefaultParameterText';

export class CyberServiceInitializer {
    public static initialize(): void {
        EntityParameters.setParameters('cyberService', new Array());
        
        DefaultParameterText['cyberServiceId'] = 'name';

        System.config({
            map: {
                CyberServiceListView: 'App/CyberDetection/CyberService/View/cyberServiceListView',
                CyberServiceDetailView: 'App/CyberDetection/CyberService/View/cyberServiceDetailView',
                CyberServiceCreateView: 'App/CyberDetection/CyberService/View/cyberServiceCreateView',
                CyberServiceUpdateView: 'App/CyberDetection/CyberService/View/cyberServiceUpdateView'
            }
        });
    }
}  

