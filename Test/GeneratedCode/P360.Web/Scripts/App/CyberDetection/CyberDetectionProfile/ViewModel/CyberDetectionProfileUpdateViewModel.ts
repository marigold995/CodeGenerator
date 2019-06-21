




import { BaseViewModel } from 'App/Base/BaseViewModel';
import { Constants } from 'App/Base/Constants';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { ValidationResult } from 'App/Base/Model/ValidationResult';
import { CyberDetectionProfileDataProvider } from 'App/CyberDetection/CyberDetectionProfile/Data/CyberDetectionProfileDataProvider';
import { CyberDetectionProfile } from 'App/CyberDetection/CyberDetectionProfile/Model/CyberDetectionProfile';
import { DataSourceHelper } from 'App/Base/Helpers/DataSourceHelper';
import { CustomZoneType } from 'App/CyberDetection/CustomZoneType/Model/CustomZoneType';
import { CyberDetectionProfileValidator } from 'App/CyberDetection/CyberDetectionProfile/Validator/CyberDetectionProfileValidator';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import * as _ from 'underscore';

export class CyberDetectionProfileUpdateViewModel extends BaseViewModel {

    public cyberDetectionProfile: CyberDetectionProfile = null;

	constructor() {
        super();

        this.setViewTitle('CyberDetectionProfile');
        this.setViewIconClass('fal fa-shiel-alt');

        this.entityName = 'CyberDetectionProfile';

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

        this.initializeValidation();
    }

    public afterLoadData(): void {
        super.afterLoadData();

        this.loadRelatedEntitiesForCyberDetectionProfile();
    }

    public loadRelatedEntitiesForCyberDetectionProfile(): void {

	}

	 public initializeValidators(viewDom: JQuery): void {
        this.validator = new CyberDetectionProfileValidator('updateCyberDetectionProfileContentContainer', viewDom, this);
    }

    public update(callback: (success: boolean, cyberDetectionProfileId: string) => void): void {
        var validationResult: ValidationResult = this.validator.validate();

        if (validationResult.isValid) {
            var executeOptions: DataProviderExecuteOptions = new DataProviderExecuteOptions(this);

            executeOptions.callback = (cyberDetectionProfileId: string): void => {
                callback(true, cyberDetectionProfileId);
            };

            executeOptions.setCloseLoader(false);

            this.cyberDetectionProfile.sites = DataSourceHelper.getCollection<Site>(this.sitesDataSource);
            this.cyberDetectionProfile.usedSoftwares = DataSourceHelper.getCollection<Software>(this.usedSoftwaresDataSource);
            this.cyberDetectionProfile.blockedUrls = DataSourceHelper.getCollection<BlockedUrl>(this.blockedUrlsDataSource);
            this.cyberDetectionProfile.directAccessAndVPNs = DataSourceHelper.getCollection<DirectAccessAndVPN>(this.directAccessAndVPNsDataSource);
            this.cyberDetectionProfile.criticalBusinessApplications = DataSourceHelper.getCollection<Software>(this.criticalBusinessApplicationsDataSource);
            this.cyberDetectionProfile.corporateThreats = DataSourceHelper.getCollection<CorporateThreat>(this.corporateThreatsDataSource);

            CyberDetectionProfileDataProvider.update(executeOptions, this.cyberDetectionProfile);
        } else {
            this.setErrorMessages(validationResult.errorMessages);
            callback(false, null);
        }
    }
}
