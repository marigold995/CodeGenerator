




import { BaseViewModel } from 'App/Base/BaseViewModel';
import { Constants } from 'App/Base/Constants';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { DataSourceHelper } from 'App/Base/Helpers/DataSourceHelper';
import { ValidationResult } from 'App/Base/Model/ValidationResult';
import { Site } from 'App/Core/Site/Model/Site';
import { CyberDetectionProfileDataProvider } from 'App/CyberDetection/CyberDetectionProfile/Data/CyberDetectionProfileDataProvider';
import { CyberDetectionProfile } from 'App/CyberDetection/CyberDetectionProfile/Model/CyberDetectionProfile';
import { CyberDetectionProfileValidator } from 'App/CyberDetection/CyberDetectionProfile/Validator/CyberDetectionProfileValidator';
import * as _ from 'underscore';

export class CyberDetectionProfileCreateViewModel extends BaseViewModel {
    public cyberDetectionProfile: CyberDetectionProfile = null;
	 constructor() {
        super();

        this.setViewTitle('CyberDetectionProfile');
        this.setViewIconClass('fal fa-shiel-alt');

        this.entityName = 'CyberDetectionProfile';

        super.init(this);
    }

    public loadData(): void {
        this.set('cyberDetectionProfile', new CyberDetectionProfile());

        this.initializeValidation();

        this.trigger(Constants.afterLoadDataEventName);
    }

    public afterLoadData(): void {
        super.afterLoadData();

        this.loadRelatedEntitiesForCyberDetectionProfile();
    }

	 public loadRelatedEntitiesForCyberDetectionProfile(): void {

	}

	public initializeValidators(viewDom: JQuery): void {
        this.validator = new CyberDetectionProfileValidator('createCyberDetectionProfileContentContainer', viewDom, this);
    }

    public create(callback: (success: boolean, cyberDetectionProfileId: string) => void): void {

	}
}

