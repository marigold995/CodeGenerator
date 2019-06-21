import { CyberDetectionBaseDataService } from 'App/CyberDetection/CyberDetectionBaseDataService';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { CyberDetectionInitializer } from 'App/CyberDetection/CyberDetectionInitializer';
import { CyberService } from 'App/CyberDetection/CyberService/Model/CyberService';

export class CyberServiceDataService extends CyberDetectionBaseDataService {

    public get entityName(): string {
        return 'cyberServices';
    }

    private static instance: CyberServiceDataService = null;

    constructor(appPath: string) {
        super(appPath);
    }

    public static reset(): void {
        CyberServiceDataService.instance = null;
    }

    public static getInstance(): CyberServiceDataService {
        if (CyberServiceDataService.instance === null) {
            CyberServiceDataService.instance = new CyberServiceDataService(CyberDetectionInitializer.appPath);
        }

        return CyberServiceDataService.instance;
    }

    public getList(callOptions: DataProviderCallOptions): kendo.data.DataSource {
        //var url: string = '/api/CyberService?companyContext=' + callOptions.companyContext;
        var url: string = `${this.baseUrlByCompany(callOptions.companyContext)}?aggregate=true`;

        return this.getClientPagingDataSource(url, callOptions);
    }
   
    public refresh(executeOptions: DataProviderExecuteOptions): JQueryPromise<any> {
        var url: string = '/api/CyberService?companyContext=' + executeOptions.companyContext + '&refreshCache=true';

        return this.executeGet(url, executeOptions);
    }





    public search(callOptions: DataProviderCallOptions): kendo.data.DataSource {
       var url: string = '/api/CyberService?companyContext=' + callOptions.companyContext;

        return this.getSearchablePagingDataSource(url, callOptions);
    }



