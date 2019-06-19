



import { EntityParameters } from 'App/Base/Framework/EntityParameters';
import { DefaultParameterText } from 'App/Base/Controls/Breadcrumbs/DefaultParameterText';

export class CyberDetectionProfileInitializer {
    public static initialize(): void {
        EntityParameters.setParameters('cyberDetectionProfile', new Array());
        
        DefaultParameterText['cyberDetectionProfileId'] = 'name';

        System.config({
            map: {
                CyberDetectionProfileListView: 'App/CyberDetection/CyberDetectionProfile/View/cyberDetectionProfileListView',
                CyberDetectionProfileDetailView: 'App/CyberDetection/CyberDetectionProfile/View/cyberDetectionProfileDetailView',
                CyberDetectionProfileCreateView: 'App/CyberDetection/CyberDetectionProfile/View/cyberDetectionProfileCreateView',
                CyberDetectionProfileUpdateView: 'App/CyberDetection/CyberDetectionProfile/View/cyberDetectionProfileUpdateView'
            }
        });
    }
}  

