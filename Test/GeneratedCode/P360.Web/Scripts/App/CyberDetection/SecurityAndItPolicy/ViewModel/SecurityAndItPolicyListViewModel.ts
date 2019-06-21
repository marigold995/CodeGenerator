



import { BaseViewModel } from 'App/Base/BaseViewModel';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { Constants } from 'App/Base/Constants';
import { RefreshDataEvent } from 'App/Base/Controls/RefreshDataEvent';
import { SecurityAndItPolicyDataProvider } from 'App/CyberDetection/SecurityAndItPolicy/Data/SecurityAndItPolicyDataProvider';
import { SecurityAndItPolicy } from 'App/CyberDetection/SecurityAndItPolicy/Model/SecurityAndItPolicy';
import { CompanyInfo } from 'App/Base/Framework/CompanyInfo';

export class SecurityAndItPolicyListViewModel extends BaseViewModel {

    public securityAndItPolicyDataSource: kendo.data.DataSource = this.getInitialDataSource();
    public hasCyberDetectionContract: boolean = false;

    constructor() {
        super();

        this.setViewTitle('SecurityAndItPolicyList');
        this.setViewIconClass('fal fa-shield-alt');
        this.entityName = 'SecurityAndItPolicy';

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

        SecurityAndItPolicyDataProvider.refresh(executeOptions)
            .then((): void => {
                this.securityAndItPolicyDataSource.read();
            });
    }

    public refreshData(e: RefreshDataEvent<SecurityAndItPolicy>): void {
        var executeOptions: DataProviderExecuteOptions = new DataProviderExecuteOptions(this);

        if (e.target !== null) {
            executeOptions.companyContext = e.target.companyContext;
        }

        SecurityAndItPolicyDataProvider.refresh(executeOptions)
            .then((): void => {
                this.initDataSource();
            });
    }


    public initDataSource(): void {
        let callOptions = new DataProviderCallOptions(this);

        this.set('securityAndItPolicyDataSource', this.getDataSource(callOptions));

        this.securityAndItPolicyDataSource.read();

        this.trigger(Constants.dataSourceChangedEventName);
    }

    protected getDataSource(callOptions: DataProviderCallOptions): kendo.data.DataSource {

        callOptions.change = (): void => {

            this.trigger(Constants.afterLoadDataEventName);
        };

        callOptions.companyContext = this.companyContext;

        return SecurityAndItPolicyDataProvider.getList(callOptions);
    }
}

