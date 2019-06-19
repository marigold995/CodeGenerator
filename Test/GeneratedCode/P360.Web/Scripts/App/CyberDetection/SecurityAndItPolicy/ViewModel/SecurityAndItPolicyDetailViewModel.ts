




import { BaseViewModel } from 'App/Base/BaseViewModel';
import { Constants } from 'App/Base/Constants';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { DataSourceHelper } from 'App/Base/Helpers/DataSourceHelper';
import { ValidationResult } from 'App/Base/Model/ValidationResult';
import { Site } from 'App/Core/Site/Model/Site';
import { SecurityAndItPolicyDataProvider } from 'App/CyberDetection/SecurityAndItPolicy/Data/SecurityAndItPolicyDataProvider';
import { SecurityAndItPolicy } from 'App/CyberDetection/SecurityAndItPolicy/Model/SecurityAndItPolicy';
import { SecurityAndItPolicyValidator } from 'App/CyberDetection/SecurityAndItPolicy/Validator/SecurityAndItPolicyValidator';
import * as _ from 'underscore';

export class SecurityAndItPolicyCreateViewModel extends BaseViewModel {
    public securityAndItPolicy: SecurityAndItPolicy = null;
	 constructor() {
        super();

        this.setViewTitle('SecurityAndItPolicy');
        this.setViewIconClass('fal fa-shiel-alt');

        this.entityName = 'SecurityAndItPolicy';

        super.init(this);
    }

    public loadData(): void {
        this.set('securityAndItPolicy', new SecurityAndItPolicy());

        this.initializeValidation();

        this.trigger(Constants.afterLoadDataEventName);
    }

    public afterLoadData(): void {
        super.afterLoadData();

        this.loadRelatedEntitiesForSecurityAndItPolicy();
    }

	 public loadRelatedEntitiesForSecurityAndItPolicy(): void {

	}

	public initializeValidators(viewDom: JQuery): void {
        this.validator = new SecurityAndItPolicyValidator('createSecurityAndItPolicyContentContainer', viewDom, this);
    }

    public create(callback: (success: boolean, securityAndItPolicyId: string) => void): void {

	}
}






import { BaseViewModel } from 'App/Base/BaseViewModel';
import { Constants } from 'App/Base/Constants';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { DataSourceHelper } from 'App/Base/Helpers/DataSourceHelper';
import { ValidationResult } from 'App/Base/Model/ValidationResult';
import { Site } from 'App/Core/Site/Model/Site';
import { SecurityAndItPolicyDataProvider } from 'App/CyberDetection/SecurityAndItPolicy/Data/SecurityAndItPolicyDataProvider';
import { SecurityAndItPolicy } from 'App/CyberDetection/SecurityAndItPolicy/Model/SecurityAndItPolicy';
import { SecurityAndItPolicyValidator } from 'App/CyberDetection/SecurityAndItPolicy/Validator/SecurityAndItPolicyValidator';
import * as _ from 'underscore';

export class SecurityAndItPolicyCreateViewModel extends BaseViewModel {
    public securityAndItPolicy: SecurityAndItPolicy = null;
	 constructor() {
        super();

        this.setViewTitle('SecurityAndItPolicy');
        this.setViewIconClass('fal fa-shiel-alt');

        this.entityName = 'SecurityAndItPolicy';

        super.init(this);
    }

    public loadData(): void {
        this.set('securityAndItPolicy', new SecurityAndItPolicy());

        this.initializeValidation();

        this.trigger(Constants.afterLoadDataEventName);
    }

    public afterLoadData(): void {
        super.afterLoadData();

        this.loadRelatedEntitiesForSecurityAndItPolicy();
    }

	 public loadRelatedEntitiesForSecurityAndItPolicy(): void {

	}

	public initializeValidators(viewDom: JQuery): void {
        this.validator = new SecurityAndItPolicyValidator('createSecurityAndItPolicyContentContainer', viewDom, this);
    }

    public create(callback: (success: boolean, securityAndItPolicyId: string) => void): void {

	}
}

