import { CyberDetectionBaseDataService } from 'App/CyberDetection/CyberDetectionBaseDataService';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { CyberDetectionInitializer } from 'App/CyberDetection/CyberDetectionInitializer';
import { ZoneProfile } from 'App/CyberDetection/ZoneProfile/Model/ZoneProfile';

export class ZoneProfileDataService extends CyberDetectionBaseDataService {

    public get entityName(): string {
        return 'zoneProfiles';
    }

    private static instance: ZoneProfileDataService = null;

    constructor(appPath: string) {
        super(appPath);
    }

    public static reset(): void {
        ZoneProfileDataService.instance = null;
    }

    public static getInstance(): ZoneProfileDataService {
        if (ZoneProfileDataService.instance === null) {
            ZoneProfileDataService.instance = new ZoneProfileDataService(CyberDetectionInitializer.appPath);
        }

        return ZoneProfileDataService.instance;
    }

    public getList(callOptions: DataProviderCallOptions): kendo.data.DataSource {
        //var url: string = '/api/ZoneProfile?companyContext=' + callOptions.companyContext;
        var url: string = `${this.baseUrlByCompany(callOptions.companyContext)}?aggregate=true`;

        return this.getClientPagingDataSource(url, callOptions);
    }
   
    public refresh(executeOptions: DataProviderExecuteOptions): JQueryPromise<any> {
        var url: string = '/api/ZoneProfile?companyContext=' + executeOptions.companyContext + '&refreshCache=true';

        return this.executeGet(url, executeOptions);
    }
  
    public getLookupList(callOptions: DataProviderCallOptions, isAggregated: boolean): kendo.data.DataSource {
        //var url: string = '/api/ZoneProfile?companyContext=' + callOptions.companyContext + '&isAggregated=' + isAggregated;
        var url: string = `${this.baseUrlByCompany(callOptions.companyContext)}?aggregate=${isAggregated}`;

        return this.getDataSource(url, callOptions);
    }
    
    public getDetail(executeOptions: DataProviderExecuteOptions, zoneProfileId: string): void {
        /*var url: string = '/api/ZoneProfile?companyContext=' + executeOptions.companyContext
            + '&zoneProfileId=' + zoneProfileId;*/
        var url: string = `${this.baseUrlByCompany(executeOptions.companyContext)}/${zoneProfileId}`;

        this.executeGet(url, executeOptions);
    }

  

    public create(executeOptions: DataProviderExecuteOptions, zoneProfile: ZoneProfile): void {
        //var url: string = '/api/ZoneProfile';

        this.executeCreate(this.baseUrl, executeOptions, zoneProfile);
    }


  
    public update(executeOptions: DataProviderExecuteOptions, zoneProfile: ZoneProfile): void {
        //var url: string = '/api/ZoneProfile';

        this.executeUpdate(this.baseUrl, executeOptions, zoneProfile);
    }


    public search(callOptions: DataProviderCallOptions): kendo.data.DataSource {
       var url: string = '/api/ZoneProfile?companyContext=' + callOptions.companyContext;

        return this.getSearchablePagingDataSource(url, callOptions);
    }

  

	public deleteItem(executeOptions: DataProviderExecuteOptions, securityAndITPolicyId: string): void {
        var url: string = '/api/SecurityAndITPolicy?companyContext=' + executeOptions.companyContext + '&securityAndITPolicyId=' + securityAndITPolicyId;

        this.executeDelete(url, executeOptions);
    }
}


