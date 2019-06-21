




import { BaseViewModel } from 'App/Base/BaseViewModel';
import { Constants } from 'App/Base/Constants';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { ValidationResult } from 'App/Base/Model/ValidationResult';
import { SecurityAndItPolicyDataProvider } from 'App/CyberDetection/SecurityAndItPolicy/Data/SecurityAndItPolicyDataProvider';
import { SecurityAndItPolicy } from 'App/CyberDetection/SecurityAndItPolicy/Model/SecurityAndItPolicy';
import { DataSourceHelper } from 'App/Base/Helpers/DataSourceHelper';
import { CustomZoneType } from 'App/CyberDetection/CustomZoneType/Model/CustomZoneType';
import { SecurityAndItPolicyValidator } from 'App/CyberDetection/SecurityAndItPolicy/Validator/SecurityAndItPolicyValidator';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import * as _ from 'underscore';

export class SecurityAndItPolicyUpdateViewModel extends BaseViewModel {

    public securityAndItPolicy: SecurityAndItPolicy = null;

	constructor() {
        super();

        this.setViewTitle('SecurityAndItPolicy');
        this.setViewIconClass('fal fa-shiel-alt');

        this.entityName = 'SecurityAndItPolicy';

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

        this.initializeValidation();
    }

    public afterLoadData(): void {
        super.afterLoadData();

        this.loadRelatedEntitiesForSecurityAndItPolicy();
    }

    public loadRelatedEntitiesForSecurityAndItPolicy(): void {

	}

	 public initializeValidators(viewDom: JQuery): void {
        this.validator = new SecurityAndItPolicyValidator('updateSecurityAndItPolicyContentContainer', viewDom, this);
    }

    public update(callback: (success: boolean, securityAndItPolicyId: string) => void): void {
        var validationResult: ValidationResult = this.validator.validate();

        if (validationResult.isValid) {
            var executeOptions: DataProviderExecuteOptions = new DataProviderExecuteOptions(this);

            executeOptions.callback = (securityAndItPolicyId: string): void => {
                callback(true, securityAndItPolicyId);
            };

            executeOptions.setCloseLoader(false);

            this.securityAndItPolicy.sites = DataSourceHelper.getCollection<Site>(this.sitesDataSource);
            this.securityAndItPolicy.usedSoftwares = DataSourceHelper.getCollection<Software>(this.usedSoftwaresDataSource);
            this.securityAndItPolicy.blockedUrls = DataSourceHelper.getCollection<BlockedUrl>(this.blockedUrlsDataSource);
            this.securityAndItPolicy.directAccessAndVPNs = DataSourceHelper.getCollection<DirectAccessAndVPN>(this.directAccessAndVPNsDataSource);
            this.securityAndItPolicy.criticalBusinessApplications = DataSourceHelper.getCollection<Software>(this.criticalBusinessApplicationsDataSource);
            this.securityAndItPolicy.corporateThreats = DataSourceHelper.getCollection<CorporateThreat>(this.corporateThreatsDataSource);

            SecurityAndItPolicyDataProvider.update(executeOptions, this.securityAndItPolicy);
        } else {
            this.setErrorMessages(validationResult.errorMessages);
            callback(false, null);
        }
    }
}
