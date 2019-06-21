




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

export class ZoneProfileCreateViewModel extends BaseViewModel {
    public zoneProfile: ZoneProfile = null;
	 constructor() {
        super();

        this.setViewTitle('ZoneProfile');
        this.setViewIconClass('fal fa-shiel-alt');

        this.entityName = 'ZoneProfile';

        super.init(this);
    }

    public loadData(): void {
        this.set('zoneProfile', new ZoneProfile());

        this.initializeValidation();

        this.trigger(Constants.afterLoadDataEventName);
    }

    public afterLoadData(): void {
        super.afterLoadData();

        this.loadRelatedEntitiesForZoneProfile();
    }

	 public loadRelatedEntitiesForZoneProfile(): void {

	}

	public initializeValidators(viewDom: JQuery): void {
        this.validator = new ZoneProfileValidator('createZoneProfileContentContainer', viewDom, this);
    }

    public create(callback: (success: boolean, zoneProfileId: string) => void): void {

	}
}

