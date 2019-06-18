
import { BaseViewModel } from 'App/Base/BaseViewModel';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { Constants } from 'App/Base/Constants';
import { RefreshDataEvent } from 'App/Base/Controls/RefreshDataEvent';
import { CyberDetectionProfileDataProvider } from 'App/CyberDetection/CyberDetectionProfile/Data/CyberDetectionProfileDataProvider';
import { CyberDetectionProfile } from 'App/CyberDetection/CyberDetectionProfile/Model/CyberDetectionProfile';
import { CompanyInfo } from 'App/Base/Framework/CompanyInfo';

export class CyberDetectionProfileListViewModel extends BaseViewModel {

    public cyberDetectionProfileDataSource: kendo.data.DataSource = this.getInitialDataSource();
    public hasCyberDetectionContract: boolean = false;

    constructor() {
        super();

        this.setViewTitle('CyberDetectionProfileList');
        this.setViewIconClass('fal fa-shield-alt');
        this.entityName = 'CyberDetectionProfile';

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

        CyberDetectionProfileDataProvider.refresh(executeOptions)
            .then((): void => {
                this.cyberDetectionProfileDataSource.read();
            });
    }

    public refreshData(e: RefreshDataEvent<CyberDetectionProfile>): void {
        var executeOptions: DataProviderExecuteOptions = new DataProviderExecuteOptions(this);

        if (e.target !== null) {
            executeOptions.companyContext = e.target.companyContext;
        }

        CyberDetectionProfileDataProvider.refresh(executeOptions)
            .then((): void => {
                this.initDataSource();
            });
    }


    public initDataSource(): void {
        let callOptions = new DataProviderCallOptions(this);

        this.set('cyberDetectionProfileDataSource', this.getDataSource(callOptions));

        this.cyberDetectionProfileDataSource.read();

        this.trigger(Constants.dataSourceChangedEventName);
    }

    protected getDataSource(callOptions: DataProviderCallOptions): kendo.data.DataSource {

        callOptions.change = (): void => {

            this.trigger(Constants.afterLoadDataEventName);
        };

        callOptions.companyContext = this.companyContext;

        return CyberDetectionProfileDataProvider.getList(callOptions);
    }
}

