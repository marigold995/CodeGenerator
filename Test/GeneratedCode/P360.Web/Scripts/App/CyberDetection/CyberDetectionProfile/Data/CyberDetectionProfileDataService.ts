import { CyberDetectionBaseDataService } from 'App/CyberDetection/CyberDetectionBaseDataService';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { CyberDetectionInitializer } from 'App/CyberDetection/CyberDetectionInitializer';
import { CyberDetectionProfile } from 'App/CyberDetection/CyberDetectionProfile/Model/CyberDetectionProfile';

export class CyberDetectionProfileDataService extends CyberDetectionBaseDataService {

    public get entityName(): string {
        return 'cyberDetectionProfiles';
    }

    private static instance: CyberDetectionProfileDataService = null;

    constructor(appPath: string) {
        super(appPath);
    }

    public static reset(): void {
        CyberDetectionProfileDataService.instance = null;
    }

    public static getInstance(): CyberDetectionProfileDataService {
        if (CyberDetectionProfileDataService.instance === null) {
            CyberDetectionProfileDataService.instance = new CyberDetectionProfileDataService(CyberDetectionInitializer.appPath);
        }

        return CyberDetectionProfileDataService.instance;
    }

    public getList(callOptions: DataProviderCallOptions): kendo.data.DataSource {
        //var url: string = '/api/CyberDetectionProfile?companyContext=' + callOptions.companyContext;
        var url: string = `${this.baseUrlByCompany(callOptions.companyContext)}?aggregate=true`;

        return this.getClientPagingDataSource(url, callOptions);
    }
   
    public refresh(executeOptions: DataProviderExecuteOptions): JQueryPromise<any> {
        var url: string = '/api/CyberDetectionProfile?companyContext=' + executeOptions.companyContext + '&refreshCache=true';

        return this.executeGet(url, executeOptions);
    }
  
    public getLookupList(callOptions: DataProviderCallOptions, isAggregated: boolean): kendo.data.DataSource {
        //var url: string = '/api/CyberDetectionProfile?companyContext=' + callOptions.companyContext + '&isAggregated=' + isAggregated;
        var url: string = `${this.baseUrlByCompany(callOptions.companyContext)}?aggregate=${isAggregated}`;

        return this.getDataSource(url, callOptions);
    }
    
    public getDetail(executeOptions: DataProviderExecuteOptions, cyberDetectionProfileId: string): void {
        /*var url: string = '/api/CyberDetectionProfile?companyContext=' + executeOptions.companyContext
            + '&cyberDetectionProfileId=' + cyberDetectionProfileId;*/
        var url: string = `${this.baseUrlByCompany(executeOptions.companyContext)}/${cyberDetectionProfileId}`;

        this.executeGet(url, executeOptions);
    }

  

    public create(executeOptions: DataProviderExecuteOptions, cyberDetectionProfile: CyberDetectionProfile): void {
        //var url: string = '/api/CyberDetectionProfile';

        this.executeCreate(this.baseUrl, executeOptions, cyberDetectionProfile);
    }


  
    public update(executeOptions: DataProviderExecuteOptions, cyberDetectionProfile: CyberDetectionProfile): void {
        //var url: string = '/api/CyberDetectionProfile';

        this.executeUpdate(this.baseUrl, executeOptions, cyberDetectionProfile);
    }


    public search(callOptions: DataProviderCallOptions): kendo.data.DataSource {
       var url: string = '/api/CyberDetectionProfile?companyContext=' + callOptions.companyContext;

        return this.getSearchablePagingDataSource(url, callOptions);
    }



