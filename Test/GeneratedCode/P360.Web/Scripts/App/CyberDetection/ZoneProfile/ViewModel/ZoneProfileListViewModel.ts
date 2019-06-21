



import { BaseViewModel } from 'App/Base/BaseViewModel';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { Constants } from 'App/Base/Constants';
import { RefreshDataEvent } from 'App/Base/Controls/RefreshDataEvent';
import { ZoneProfileDataProvider } from 'App/CyberDetection/ZoneProfile/Data/ZoneProfileDataProvider';
import { ZoneProfile } from 'App/CyberDetection/ZoneProfile/Model/ZoneProfile';
import { CompanyInfo } from 'App/Base/Framework/CompanyInfo';

export class ZoneProfileListViewModel extends BaseViewModel {

    public zoneProfileDataSource: kendo.data.DataSource = this.getInitialDataSource();
    public hasCyberDetectionContract: boolean = false;

    constructor() {
        super();

        this.setViewTitle('ZoneProfileList');
        this.setViewIconClass('fal fa-shield-alt');
        this.entityName = 'ZoneProfile';

        super.init(this);
    }

    public loadData(): void {
        if (this.isSearchView) {
            this.trigger(Constants.afterLoadDataEventName);
        } else {
            this.initDataSource();
        }
    }
	  public afterLoadData(): void {
        super.afterLoadData();
        this.set('hasCyberDetectionContract', CompanyInfo.hasCyberDetectionContract);
    }

    public reloadData(): void {
        var executeOptions: DataProviderExecuteOptions = new DataProviderExecuteOptions(this);

        ZoneProfileDataProvider.refresh(executeOptions)
            .then((): void => {
                this.zoneProfileDataSource.read();
            });
    }

    public refreshData(e: RefreshDataEvent<ZoneProfile>): void {
        var executeOptions: DataProviderExecuteOptions = new DataProviderExecuteOptions(this);

        if (e.target !== null) {
            executeOptions.companyContext = e.target.companyContext;
        }

        ZoneProfileDataProvider.refresh(executeOptions)
            .then((): void => {
                this.initDataSource();
            });
    }


    public initDataSource(): void {
        let callOptions = new DataProviderCallOptions(this);

        this.set('zoneProfileDataSource', this.getDataSource(callOptions));

        this.zoneProfileDataSource.read();

        this.trigger(Constants.dataSourceChangedEventName);
    }

    protected getDataSource(callOptions: DataProviderCallOptions): kendo.data.DataSource {

        callOptions.change = (): void => {

            this.trigger(Constants.afterLoadDataEventName);
        };

        callOptions.companyContext = this.companyContext;

        return ZoneProfileDataProvider.getList(callOptions);
    }
}

