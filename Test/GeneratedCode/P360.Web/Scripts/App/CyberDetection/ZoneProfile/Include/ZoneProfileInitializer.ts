



import { EntityParameters } from 'App/Base/Framework/EntityParameters';
import { DefaultParameterText } from 'App/Base/Controls/Breadcrumbs/DefaultParameterText';

export class ZoneProfileInitializer {
    public static initialize(): void {
        EntityParameters.setParameters('zoneProfile', new Array());
        
        DefaultParameterText['zoneProfileId'] = 'name';

        System.config({
            map: {
                ZoneProfileListView: 'App/CyberDetection/ZoneProfile/View/zoneProfileListView',
                ZoneProfileDetailView: 'App/CyberDetection/ZoneProfile/View/zoneProfileDetailView',
                ZoneProfileCreateView: 'App/CyberDetection/ZoneProfile/View/zoneProfileCreateView',
                ZoneProfileUpdateView: 'App/CyberDetection/ZoneProfile/View/zoneProfileUpdateView'
            }
        });
    }
}  

