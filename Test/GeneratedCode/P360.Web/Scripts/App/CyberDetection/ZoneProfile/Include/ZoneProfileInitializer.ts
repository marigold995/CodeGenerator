










import { EntityParameters } from 'App/Base/Framework/EntityParameters';
import { DefaultParameterText } from 'App/Base/Controls/Breadcrumbs/DefaultParameterText';

export class ZoneProfileInitializer {
    public static initialize(): void {
        EntityParameters.setParameters('zoneProfile', new Array());
        
        DefaultParameterText['zoneProfileId'] = 'name';

        System.config({
            map: {
                ZoneProfileListView: 'App/_360Generator.Metadata.Module/ZoneProfile/View/zoneProfileListView',
                ZoneProfileDetailView: 'App/_360Generator.Metadata.Module/ZoneProfile/View/zoneProfileDetailView',
                ZoneProfileCreateView: 'App/_360Generator.Metadata.Module/ZoneProfile/View/zoneProfileCreateView',
                ZoneProfileUpdateView: 'App/_360Generator.Metadata.Module/ZoneProfile/View/zoneProfileUpdateView'
            }
        });
    }
}  

