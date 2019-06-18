
import { BaseViewModel } from 'App/Base/BaseViewModel';
import { Constants } from 'App/Base/Constants';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { DataSourceHelper } from 'App/Base/Helpers/DataSourceHelper';
import { ValidationResult } from 'App/Base/Model/ValidationResult';
import { Site } from 'App/Core/Site/Model/Site';
import { ZoneProfileDataProvider } from 'App/CyberDetection/ZoneProfile/Data/ZoneProfileDataProvider';
import { ZoneProfile } from 'App/CyberDetection/ZoneProfile/Model/ZoneProfile';
import { ZoneProfileValidator } from 'App/CyberDetection/ZoneProfile/Validator/ZoneProfileValidator';
import * as _ from 'underscore';

export class SecurityAndITPolicyCreateViewModel extends BaseViewModel {
    public securityAndITPolicy: SecurityAndITPolicy = null;
	 constructor() {
        super();

        this.setViewTitle('SecurityAndITPolicy');
        this.setViewIconClass('fal fa-shiel-alt');

        this.entityName = 'SecurityAndITPolicy';

        super.init(this);
    }

    public loadData(): void {
        this.set('securityAndITPolicy', new SecurityAndITPolicy());

        this.initializeValidation();

        this.trigger(Constants.afterLoadDataEventName);
    }

    public afterLoadData(): void {
        super.afterLoadData();

        this.loadRelatedEntitiesForSecurityAndITPolicy();
    }

	 public loadRelatedEntitiesForSecurityAndITPolicy(): void {

	}

	public initializeValidators(viewDom: JQuery): void {
        this.validator = new SecurityAndITPolicyValidator('createSecurityAndITPolicyContentContainer', viewDom, this);
    }

    public create(callback: (success: boolean, securityAndITPolicyId: string) => void): void {

	}
}


