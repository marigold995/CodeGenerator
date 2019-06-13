
import { EntityParameters } from 'App/Base/Framework/EntityParameters';
import { DefaultParameterText } from 'App/Base/Controls/Breadcrumbs/DefaultParameterText';

export class CyberDetectionProfileInitializer {
    public static initialize(): void {
        EntityParameters.setParameters('cyberDetectionProfile', new Array());
        
        DefaultParameterText['cyberDetectionProfileId'] = 'name';

        System.config({
            map: {
                CyberDetectionProfileListView: 'App/_360Generator.Metadata.Module/CyberDetectionProfile/View/cyberDetectionProfileListView',
                CyberDetectionProfileDetailView: 'App/_360Generator.Metadata.Module/CyberDetectionProfile/View/cyberDetectionProfileDetailView',
                CyberDetectionProfileCreateView: 'App/_360Generator.Metadata.Module/CyberDetectionProfile/View/cyberDetectionProfileCreateView',
                CyberDetectionProfileUpdateView: 'App/_360Generator.Metadata.Module/CyberDetectionProfile/View/cyberDetectionProfileUpdateView'
            }
        });
    }
}  

