import { BaseDataProvider } from 'App/Base/BaseDataProvider';
import { Constants } from 'App/Base/Constants';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { DateHelper } from "App/Base/Helpers/DateHelper";
import { CyberServiceDataService } from 'App/CyberDetection/CyberService/Data/CyberServiceDataService';
import { CyberService } from 'App/CyberDetection/CyberService/Model/CyberService';
import * as _ from 'underscore';
import { CyberDetectionConstants } from 'App/CyberDetection/CyberDetectionConstants';
import { UserInfo } from 'App/Base/Framework/UserInfo';

export class CyberServiceDataProvider extends BaseDataProvider {
    public static getDataSource(cyberServiceList: Array<CyberService>): kendo.data.DataSource {
        var dataSourceOptions: kendo.data.DataSourceOptions = {};

        dataSourceOptions.schema = {};

        dataSourceOptions.data = cyberServiceList;

        dataSourceOptions.pageSize = Constants.defaultPageSize;

        dataSourceOptions.schema.model = CyberServiceDataProvider.getKendoModel();
        dataSourceOptions.schema.parse = (data: any): any => {
            return CyberServiceDataProvider.preParseResponse(data);
        };

        var dataSource: kendo.data.DataSource = new kendo.data.DataSource(dataSourceOptions);

        return dataSource;
    }

    public static getList(callOptions: DataProviderCallOptions): kendo.data.DataSource {
        callOptions.dataModel = CyberServiceDataProvider.getKendoModel();

        callOptions.preParseResponse = (data: any): any => {
            return CyberServiceDataProvider.preParseResponse(data);
        };

        return CyberServiceDataService.getInstance().getList(
            callOptions);
    }

    public static getLookupListExecuted(executeOptions: DataProviderExecuteOptions): void {
        CyberServiceDataService.getInstance().getLookupListExecuted(
            executeOptions);
    }

    public static refresh(executeOptions: DataProviderExecuteOptions): JQueryPromise<any> {
        return CyberServiceDataService.getInstance().refresh(executeOptions);
    }

    public static getLookupList(callOptions: DataProviderCallOptions, isAggregated: boolean): kendo.data.DataSource {
        callOptions.dataModel = CyberServiceDataProvider.getKendoModel();

        callOptions.preParseResponse = (data: any): any => {
            return CyberServiceDataProvider.preParseResponse(data);
        };

        return CyberServiceDataService.getInstance().getLookupList(
            callOptions, isAggregated);
    }





    private static getKendoModel(): typeof kendo.data.Model {
        var fields: any = CyberServiceDataProvider.getFields();

        var model: typeof kendo.data.Model = kendo.data.Model.define({
            fields: fields
        });

        return model;
    }

    private static getFields(): any {
        return {
            refreshedOn: { type: 'date' },
            cyberServiceId: { type: 'string' },
            name: { type: 'string' },
            description: { type: 'string' },
            companyContext: { type: 'string' },
            createdOn: { type: 'date' }
        };
    }

    private static preParseResponse(data: any): any {
        var cyberServiceList: Array<CyberService> = data.result;

        if (data.result === void 0) {
            cyberServiceList = data;
        }

        _.each<CyberService>(cyberServiceList, (cyberService: CyberService): void => {
            CyberServiceDataProvider.preParseExecute(cyberService);
        });

        return data;
    }

    protected static preParseExecute(cyberService: CyberService): CyberService {
        if (cyberService.cyberServiceId.length === 0) {
            cyberService.cyberServiceId = null;
        }

        cyberService.createdOn = DateHelper.fromUtcDateTime(BaseDataProvider.parseDate(cyberService.createdOn));

        switch (cyberService.package.packageCode) {
            case CyberDetectionConstants.profileEntryPackageCode:
                cyberService.package.packageDisplayName = CyberDetectionConstants.entryPackageName;
                break;
            case CyberDetectionConstants.profileBusinessPackageCode:
                cyberService.package.packageDisplayName = CyberDetectionConstants.businessPackageName;
                break;
            default:
                break;
        }

        cyberService.companyName = UserInfo.getCompanyName(cyberService.companyContext);

        return cyberService;
    }

    private static getKendoTreeListModel(): typeof kendo.data.TreeListModel {
        var fields: any = CyberServiceDataProvider.getFields();

        var model: typeof kendo.data.TreeListModel = kendo.data.TreeListModel.define({
            id: 'cyberServiceId',
            fields: fields,
            expanded: true
        });

        return model;
    }
}

