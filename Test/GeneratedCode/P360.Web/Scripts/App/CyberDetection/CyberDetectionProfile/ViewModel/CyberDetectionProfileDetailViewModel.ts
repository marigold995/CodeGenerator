




import { BaseViewModel } from "App/Base/BaseViewModel";
import { Constants } from "App/Base/Constants";
import { DataProviderExecuteOptions } from "App/Base/Data/DataProviderExecuteOptions";
import { CyberDetectionProfileDataProvider } from "App/CyberDetection/CyberDetectionProfile/Data/CyberDetectionProfileDataProvider";
import { CyberDetectionProfile } from "App/CyberDetection/CyberDetectionProfile/Model/CyberDetectionProfile";
import { Security } from 'App/Base/Framework/Security';
import { Permissions } from 'App/Base/Permissions';
import { CompanyHelper } from 'App/Base/Helpers/CompanyHelper';
import { CompanyInfo } from "App/Base/Framework/CompanyInfo";

export class CyberDetectionProfileDetailViewModel extends BaseViewModel {

    public cyberDetectionProfile: CyberDetectionProfile;

	constructor() {
        super();

        this.setViewTitle('CyberDetectionProfile');
        this.setViewIconClass('fal fa-shiel-alt');
        this.entityName = 'CyberDetectionProfile';

        this.cyberDetectionProfile = null;

        super.init(this);
    }

    public loadData(): void {
        var promiseCyberDetectionProfile = CyberDetectionProfileDataProvider.getDetailAsync(new DataProviderExecuteOptions(this), this.dp.cyberDetectionProfileId);
        promiseCyberDetectionProfile
            .then((cyberDetectionProfile: CyberDetectionProfile) => {
                this.set('cyberDetectionProfile', cyberDetectionProfile);
            });
        
        Promise.all([promiseCyberDetectionProfile])
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


}

