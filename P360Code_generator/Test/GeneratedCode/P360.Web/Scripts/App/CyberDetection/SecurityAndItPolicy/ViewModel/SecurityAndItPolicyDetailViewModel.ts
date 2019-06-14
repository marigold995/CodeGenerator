
import { BaseViewModel } from "App/Base/BaseViewModel";
import { Constants } from "App/Base/Constants";
import { DataProviderExecuteOptions } from "App/Base/Data/DataProviderExecuteOptions";
import { SecurityAndItPolicyDataProvider } from "App/CyberDetection/SecurityAndItPolicy/Data/SecurityAndItPolicyDataProvider";
import { SecurityAndItPolicy } from "App/CyberDetection/SecurityAndItPolicy/Model/SecurityAndItPolicy";
import { Security } from 'App/Base/Framework/Security';
import { Permissions } from 'App/Base/Permissions';
import { CompanyHelper } from 'App/Base/Helpers/CompanyHelper';
import { CompanyInfo } from "App/Base/Framework/CompanyInfo";

export class SecurityAndItPolicyDetailViewModel extends BaseViewModel {

    public securityAndItPolicy: SecurityAndItPolicy;

	constructor() {
        super();

        this.setViewTitle('SecurityAndItPolicy');
        this.setViewIconClass('fal fa-shiel-alt');
        this.entityName = 'SecurityAndItPolicy';

        this.securityAndItPolicy = null;

        super.init(this);
    }

    public loadData(): void {
        var promiseSecurityAndItPolicy = SecurityAndItPolicyDataProvider.getDetailAsync(new DataProviderExecuteOptions(this), this.dp.securityAndItPolicyId);
        promiseSecurityAndItPolicy
            .then((securityAndItPolicy: SecurityAndItPolicy) => {
                this.set('securityAndItPolicy', securityAndItPolicy);
            });
        
        Promise.all([promiseSecurityAndItPolicy])
            .then(() => this.trigger(Constants.afterLoadDataEventName));
    }

    public afterLoadData(): void {
        super.afterLoadData();
	}

	public refresh(): void {
        this.loadData();
    }
    
  

    public getEditPermission(): boolean {
        return Security.hasPermission(Permissions.updateSITPolicy)
            && !CompanyHelper.isRootCompany(this.dp.companyContext)
            && CompanyInfo.hasCyberDetectionContract;
    }

  
    public getAddPermission(): boolean {
        return Security.hasPermission(Permissions.createSITPolicy)
            && !CompanyHelper.isRootCompany(this.dp.companyContext)
            && CompanyInfo.hasCyberDetectionContract;
    }

  

    // Not used yet
    public getDeletePermission(): boolean {
        return false && Security.hasPermission(Permissions.deleteSITPolicy);
    }

}

