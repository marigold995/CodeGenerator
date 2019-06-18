










import { EntityParameters } from 'App/Base/Framework/EntityParameters';
import { DefaultParameterText } from 'App/Base/Controls/Breadcrumbs/DefaultParameterText';

export class SecurityAndItPolicyInitializer {
    public static initialize(): void {
        EntityParameters.setParameters('securityAndItPolicy', new Array());
        
        DefaultParameterText['securityAndItPolicyId'] = 'name';

        System.config({
            map: {
                SecurityAndItPolicyListView: 'App/_360Generator.Metadata.Module/SecurityAndItPolicy/View/securityAndItPolicyListView',
                SecurityAndItPolicyDetailView: 'App/_360Generator.Metadata.Module/SecurityAndItPolicy/View/securityAndItPolicyDetailView',
                SecurityAndItPolicyCreateView: 'App/_360Generator.Metadata.Module/SecurityAndItPolicy/View/securityAndItPolicyCreateView',
                SecurityAndItPolicyUpdateView: 'App/_360Generator.Metadata.Module/SecurityAndItPolicy/View/securityAndItPolicyUpdateView'
            }
        });
    }
}  

