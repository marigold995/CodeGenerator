




import { BaseViewModel } from 'App/Base/BaseViewModel';
import { Constants } from 'App/Base/Constants';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { ValidationResult } from 'App/Base/Model/ValidationResult';
import { ZoneProfileDataProvider } from 'App/CyberDetection/ZoneProfile/Data/ZoneProfileDataProvider';
import { ZoneProfile } from 'App/CyberDetection/ZoneProfile/Model/ZoneProfile';
import { DataSourceHelper } from 'App/Base/Helpers/DataSourceHelper';
import { CustomZoneType } from 'App/CyberDetection/CustomZoneType/Model/CustomZoneType';
import { ZoneProfileValidator } from 'App/CyberDetection/ZoneProfile/Validator/ZoneProfileValidator';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import * as _ from 'underscore';

export class ZoneProfileUpdateViewModel extends BaseViewModel {

    public zoneProfile: ZoneProfile = null;

	constructor() {
        super();

        this.setViewTitle('ZoneProfile');
        this.setViewIconClass('fal fa-shiel-alt');

        this.entityName = 'ZoneProfile';

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

        this.initializeValidation();
    }

    public afterLoadData(): void {
        super.afterLoadData();

        this.loadRelatedEntitiesForZoneProfile();
    }

    public loadRelatedEntitiesForZoneProfile(): void {

	}

	 public initializeValidators(viewDom: JQuery): void {
        this.validator = new ZoneProfileValidator('updateZoneProfileContentContainer', viewDom, this);
    }

    public update(callback: (success: boolean, zoneProfileId: string) => void): void {
        var validationResult: ValidationResult = this.validator.validate();

        if (validationResult.isValid) {
            var executeOptions: DataProviderExecuteOptions = new DataProviderExecuteOptions(this);

            executeOptions.callback = (zoneProfileId: string): void => {
                callback(true, zoneProfileId);
            };

            executeOptions.setCloseLoader(false);

            this.zoneProfile.sites = DataSourceHelper.getCollection<Site>(this.sitesDataSource);
            this.zoneProfile.usedSoftwares = DataSourceHelper.getCollection<Software>(this.usedSoftwaresDataSource);
            this.zoneProfile.blockedUrls = DataSourceHelper.getCollection<BlockedUrl>(this.blockedUrlsDataSource);
            this.zoneProfile.directAccessAndVPNs = DataSourceHelper.getCollection<DirectAccessAndVPN>(this.directAccessAndVPNsDataSource);
            this.zoneProfile.criticalBusinessApplications = DataSourceHelper.getCollection<Software>(this.criticalBusinessApplicationsDataSource);
            this.zoneProfile.corporateThreats = DataSourceHelper.getCollection<CorporateThreat>(this.corporateThreatsDataSource);

            ZoneProfileDataProvider.update(executeOptions, this.zoneProfile);
        } else {
            this.setErrorMessages(validationResult.errorMessages);
            callback(false, null);
        }
    }
}
