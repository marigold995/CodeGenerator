
import { BaseDataProvider } from 'App/Base/BaseDataProvider';
import { Constants } from 'App/Base/Constants';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { DateHelper } from "App/Base/Helpers/DateHelper";
import { ZoneProfileDataService } from 'App/CyberDetection/ZoneProfile/Data/ZoneProfileDataService';
import { ZoneProfile } from 'App/CyberDetection/ZoneProfile/Model/ZoneProfile';
import * as _ from 'underscore';
import { CyberDetectionConstants } from 'App/CyberDetection/CyberDetectionConstants';
import { UserInfo } from 'App/Base/Framework/UserInfo';

export class ZoneProfileDataProvider extends BaseDataProvider {
    public static getDataSource(zoneProfileList: Array<ZoneProfile>): kendo.data.DataSource {
        var dataSourceOptions: kendo.data.DataSourceOptions = {};

        dataSourceOptions.schema = {};

        dataSourceOptions.data = zoneProfileList;

        dataSourceOptions.pageSize = Constants.defaultPageSize;

        dataSourceOptions.schema.model = ZoneProfileDataProvider.getKendoModel();
        dataSourceOptions.schema.parse = (data: any): any => {
            return ZoneProfileDataProvider.preParseResponse(data);
        };

        var dataSource: kendo.data.DataSource = new kendo.data.DataSource(dataSourceOptions);

        return dataSource;
    }

    public static getList(callOptions: DataProviderCallOptions): kendo.data.DataSource {
        callOptions.dataModel = ZoneProfileDataProvider.getKendoModel();

        callOptions.preParseResponse = (data: any): any => {
            return ZoneProfileDataProvider.preParseResponse(data);
        };

        return ZoneProfileDataService.getInstance().getList(
            callOptions);
    }

    public static getLookupListExecuted(executeOptions: DataProviderExecuteOptions): void {
        ZoneProfileDataService.getInstance().getLookupListExecuted(
            executeOptions);
    }

    public static refresh(executeOptions: DataProviderExecuteOptions): JQueryPromise<any> {
        return ZoneProfileDataService.getInstance().refresh(executeOptions);
    }

    public static getLookupList(callOptions: DataProviderCallOptions, isAggregated: boolean): kendo.data.DataSource {
        callOptions.dataModel = ZoneProfileDataProvider.getKendoModel();

        callOptions.preParseResponse = (data: any): any => {
            return ZoneProfileDataProvider.preParseResponse(data);
        };

        return ZoneProfileDataService.getInstance().getLookupList(
            callOptions, isAggregated);
    }
  

    public static getDetailAsync(executeOptions: DataProviderExecuteOptions, zoneProfileId: string): Promise<ZoneProfile> {
        executeOptions.preParseExecute = (zoneProfile: ZoneProfile): ZoneProfile => {
            return ZoneProfileDataProvider.preParseExecute(zoneProfile);
        };

        var promise = new Promise<ZoneProfile>((resolve, reject) => {
            executeOptions.callback = (zoneProfile: ZoneProfile): void => {
                resolve(zoneProfile);
            }
        });

        ZoneProfileDataService.getInstance().getDetail(
            executeOptions,
            zoneProfileId);

        return promise;
    }


    public static getDetail(executeOptions: DataProviderExecuteOptions, zoneProfileId: string): void {
        executeOptions.preParseExecute = (zoneProfile: ZoneProfile): ZoneProfile => {
            return ZoneProfileDataProvider.preParseExecute(zoneProfile);
        };

        ZoneProfileDataService.getInstance().getDetail(
            executeOptions,
            zoneProfileId);
    }


  

    public static create(executeOptions: DataProviderExecuteOptions,
        zoneProfile: ZoneProfile): void {
        zoneProfile.companyContext = executeOptions.companyContext;

        ZoneProfileDataService.getInstance().create(
            executeOptions,
            zoneProfile);
    }


  

    public static update(executeOptions: DataProviderExecuteOptions,
        zoneProfile: ZoneProfile): void {
        zoneProfile.companyContext = executeOptions.companyContext;

        ZoneProfileDataService.getInstance().update(
            executeOptions,
            zoneProfile);
    }

    private static getKendoModel(): typeof kendo.data.Model {
        var fields: any = ZoneProfileDataProvider.getFields();

        var model: typeof kendo.data.Model = kendo.data.Model.define({
            fields: fields
        });

        return model;
    }

    private static getFields(): any {
        return {
            refreshedOn: { type: 'date' },
            zoneProfileId: { type: 'string' },
            name: { type: 'string' },
            description: { type: 'string' },
            companyContext: { type: 'string' },
            createdOn: { type: 'date' }
        };
    }

    private static preParseResponse(data: any): any {
        var zoneProfileList: Array<ZoneProfile> = data.result;

        if (data.result === void 0) {
            zoneProfileList = data;
        }

        _.each<ZoneProfile>(zoneProfileList, (zoneProfile: ZoneProfile): void => {
            ZoneProfileDataProvider.preParseExecute(zoneProfile);
        });

        return data;
    }

    protected static preParseExecute(zoneProfile: ZoneProfile): ZoneProfile {
        if (zoneProfile.zoneProfileId.length === 0) {
            zoneProfile.zoneProfileId = null;
        }

        zoneProfile.createdOn = DateHelper.fromUtcDateTime(BaseDataProvider.parseDate(zoneProfile.createdOn));

        switch (zoneProfile.package.packageCode) {
            case CyberDetectionConstants.profileEntryPackageCode:
                zoneProfile.package.packageDisplayName = CyberDetectionConstants.entryPackageName;
                break;
            case CyberDetectionConstants.profileBusinessPackageCode:
                zoneProfile.package.packageDisplayName = CyberDetectionConstants.businessPackageName;
                break;
            default:
                break;
        }

        zoneProfile.companyName = UserInfo.getCompanyName(zoneProfile.companyContext);

        return zoneProfile;
    }

    private static getKendoTreeListModel(): typeof kendo.data.TreeListModel {
        var fields: any = ZoneProfileDataProvider.getFields();

        var model: typeof kendo.data.TreeListModel = kendo.data.TreeListModel.define({
            id: 'zoneProfileId',
            fields: fields,
            expanded: true
        });

        return model;
    }
}

