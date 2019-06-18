
import { BaseViewModel } from 'App/Base/BaseViewModel';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { Constants } from 'App/Base/Constants';
import { RefreshDataEvent } from 'App/Base/Controls/RefreshDataEvent';
import { CyberServiceDataProvider } from 'App/CyberDetection/CyberService/Data/CyberServiceDataProvider';
import { CyberService } from 'App/CyberDetection/CyberService/Model/CyberService';
import { CompanyInfo } from 'App/Base/Framework/CompanyInfo';

export class CyberServiceListViewModel extends BaseViewModel {

    public cyberServiceDataSource: kendo.data.DataSource = this.getInitialDataSource();
    public hasCyberDetectionContract: boolean = false;

    constructor() {
        super();

        this.setViewTitle('CyberServiceList');
        this.setViewIconClass('fal fa-shield-alt');
        this.entityName = 'CyberService';

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

        CyberServiceDataProvider.refresh(executeOptions)
            .then((): void => {
                this.cyberServiceDataSource.read();
            });
    }

    public refreshData(e: RefreshDataEvent<CyberService>): void {
        var executeOptions: DataProviderExecuteOptions = new DataProviderExecuteOptions(this);

        if (e.target !== null) {
            executeOptions.companyContext = e.target.companyContext;
        }

        CyberServiceDataProvider.refresh(executeOptions)
            .then((): void => {
                this.initDataSource();
            });
    }


    public initDataSource(): void {
        let callOptions = new DataProviderCallOptions(this);

        this.set('cyberServiceDataSource', this.getDataSource(callOptions));

        this.cyberServiceDataSource.read();

        this.trigger(Constants.dataSourceChangedEventName);
    }

    protected getDataSource(callOptions: DataProviderCallOptions): kendo.data.DataSource {

        callOptions.change = (): void => {

            this.trigger(Constants.afterLoadDataEventName);
        };

        callOptions.companyContext = this.companyContext;

        return CyberServiceDataProvider.getList(callOptions);
    }
}

