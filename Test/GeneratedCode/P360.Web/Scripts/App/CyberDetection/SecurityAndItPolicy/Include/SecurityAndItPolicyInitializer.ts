import { EntityParameters } from 'App/Base/Framework/EntityParameters';
import { DefaultParameterText } from 'App/Base/Controls/Breadcrumbs/DefaultParameterText';

export class SecurityAndItPolicyInitializer {
    public static initialize(): void {
        EntityParameters.setParameters('securityAndItPolicy', new Array());
        
        DefaultParameterText['securityAndItPolicyId'] = 'name';

        System.config({
            map: {
                SecurityAndItPolicyListView: 'App/CyberDetection/SecurityAndItPolicy/View/securityAndItPolicyListView',
                SecurityAndItPolicyDetailView: 'App/CyberDetection/SecurityAndItPolicy/View/securityAndItPolicyDetailView',
                SecurityAndItPolicyCreateView: 'App/CyberDetection/SecurityAndItPolicy/View/securityAndItPolicyCreateView',
                SecurityAndItPolicyUpdateView: 'App/CyberDetection/SecurityAndItPolicy/View/securityAndItPolicyUpdateView'
            }
        });
    }
}  

