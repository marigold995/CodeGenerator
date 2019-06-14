import { CyberDetectionBaseDataService } from 'App/CyberDetection/CyberDetectionBaseDataService';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { CyberDetectionInitializer } from 'App/CyberDetection/CyberDetectionInitializer';
import { SecurityAndItPolicy } from 'App/CyberDetection/SecurityAndItPolicy/Model/SecurityAndItPolicy';

export class SecurityAndItPolicyDataService extends CyberDetectionBaseDataService {

    public get entityName(): string {
        return 'securityAndItPolicys';
    }

    private static instance: SecurityAndItPolicyDataService = null;

    constructor(appPath: string) {
        super(appPath);
    }

    public static reset(): void {
        SecurityAndItPolicyDataService.instance = null;
    }

    public static getInstance(): SecurityAndItPolicyDataService {
        if (SecurityAndItPolicyDataService.instance === null) {
            SecurityAndItPolicyDataService.instance = new SecurityAndItPolicyDataService(CyberDetectionInitializer.appPath);
        }

        return SecurityAndItPolicyDataService.instance;
    }

    public getList(callOptions: DataProviderCallOptions): kendo.data.DataSource {
        //var url: string = '/api/SecurityAndItPolicy?companyContext=' + callOptions.companyContext;
        var url: string = `${this.baseUrlByCompany(callOptions.companyContext)}?aggregate=true`;

        return this.getClientPagingDataSource(url, callOptions);
    }
   
    public refresh(executeOptions: DataProviderExecuteOptions): JQueryPromise<any> {
        var url: string = '/api/SecurityAndItPolicy?companyContext=' + executeOptions.companyContext + '&refreshCache=true';

        return this.executeGet(url, executeOptions);
    }
  
    public getLookupList(callOptions: DataProviderCallOptions, isAggregated: boolean): kendo.data.DataSource {
        //var url: string = '/api/SecurityAndItPolicy?companyContext=' + callOptions.companyContext + '&isAggregated=' + isAggregated;
        var url: string = `${this.baseUrlByCompany(callOptions.companyContext)}?aggregate=${isAggregated}`;

        return this.getDataSource(url, callOptions);
    }
    
    public getDetail(executeOptions: DataProviderExecuteOptions, securityAndItPolicyId: string): void {
        /*var url: string = '/api/SecurityAndItPolicy?companyContext=' + executeOptions.companyContext
            + '&securityAndItPolicyId=' + securityAndItPolicyId;*/
        var url: string = `${this.baseUrlByCompany(executeOptions.companyContext)}/${securityAndItPolicyId}`;

        this.executeGet(url, executeOptions);
    }

  

    public create(executeOptions: DataProviderExecuteOptions, securityAndItPolicy: SecurityAndItPolicy): void {
        //var url: string = '/api/SecurityAndItPolicy';

        this.executeCreate(this.baseUrl, executeOptions, securityAndItPolicy);
    }


  
    public update(executeOptions: DataProviderExecuteOptions, securityAndItPolicy: SecurityAndItPolicy): void {
        //var url: string = '/api/SecurityAndItPolicy';

        this.executeUpdate(this.baseUrl, executeOptions, securityAndItPolicy);
    }


    public search(callOptions: DataProviderCallOptions): kendo.data.DataSource {
       var url: string = '/api/SecurityAndItPolicy?companyContext=' + callOptions.companyContext;

        return this.getSearchablePagingDataSource(url, callOptions);
    }


