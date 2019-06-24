




import { BaseViewModel } from "App/Base/BaseViewModel";
import { Constants } from "App/Base/Constants";
import { DataProviderExecuteOptions } from "App/Base/Data/DataProviderExecuteOptions";
import { ZoneProfileDataProvider } from "App/CyberDetection/ZoneProfile/Data/ZoneProfileDataProvider";
import { ZoneProfile } from "App/CyberDetection/ZoneProfile/Model/ZoneProfile";
import { Security } from 'App/Base/Framework/Security';
import { Permissions } from 'App/Base/Permissions';
import { CompanyHelper } from 'App/Base/Helpers/CompanyHelper';
import { CompanyInfo } from "App/Base/Framework/CompanyInfo";

export class ZoneProfileDetailViewModel extends BaseViewModel {

    public zoneProfile: ZoneProfile;

	constructor() {
        super();

        this.setViewTitle('ZoneProfile');
        this.setViewIconClass('fal fa-shiel-alt');
        this.entityName = 'ZoneProfile';

        this.zoneProfile = null;

        super.init(this);
    }

    public loadData(): void {
        var promiseZoneProfile = ZoneProfileDataProvider.getDetailAsync(new DataProviderExecuteOptions(this), this.dp.zoneProfileId);
        promiseZoneProfile
            .then((zoneProfile: ZoneProfile) => {
                this.set('zoneProfile', zoneProfile);
            });
        
        Promise.all([promiseZoneProfile])
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

