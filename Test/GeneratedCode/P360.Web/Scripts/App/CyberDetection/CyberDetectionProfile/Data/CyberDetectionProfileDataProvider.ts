




import { BaseDataProvider } from 'App/Base/BaseDataProvider';
import { Constants } from 'App/Base/Constants';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { DateHelper } from "App/Base/Helpers/DateHelper";
import { CyberDetectionProfileDataService } from 'App/CyberDetection/CyberDetectionProfile/Data/CyberDetectionProfileDataService';
import { CyberDetectionProfile } from 'App/CyberDetection/CyberDetectionProfile/Model/CyberDetectionProfile';
import * as _ from 'underscore';
import { CyberDetectionConstants } from 'App/CyberDetection/CyberDetectionConstants';
import { UserInfo } from 'App/Base/Framework/UserInfo';

export class CyberDetectionProfileDataProvider extends BaseDataProvider {
    public static getDataSource(cyberDetectionProfileList: Array<CyberDetectionProfile>): kendo.data.DataSource {
        var dataSourceOptions: kendo.data.DataSourceOptions = {};

        dataSourceOptions.schema = {};

        dataSourceOptions.data = cyberDetectionProfileList;

        dataSourceOptions.pageSize = Constants.defaultPageSize;

        dataSourceOptions.schema.model = CyberDetectionProfileDataProvider.getKendoModel();
        dataSourceOptions.schema.parse = (data: any): any => {
            return CyberDetectionProfileDataProvider.preParseResponse(data);
        };

        var dataSource: kendo.data.DataSource = new kendo.data.DataSource(dataSourceOptions);

        return dataSource;
    }

    public static getList(callOptions: DataProviderCallOptions): kendo.data.DataSource {
        callOptions.dataModel = CyberDetectionProfileDataProvider.getKendoModel();

        callOptions.preParseResponse = (data: any): any => {
            return CyberDetectionProfileDataProvider.preParseResponse(data);
        };

        return CyberDetectionProfileDataService.getInstance().getList(
            callOptions);
    }

    public static getLookupListExecuted(executeOptions: DataProviderExecuteOptions): void {
        CyberDetectionProfileDataService.getInstance().getLookupListExecuted(
            executeOptions);
    }

    public static refresh(executeOptions: DataProviderExecuteOptions): JQueryPromise<any> {
        return CyberDetectionProfileDataService.getInstance().refresh(executeOptions);
    }

    public static getLookupList(callOptions: DataProviderCallOptions, isAggregated: boolean): kendo.data.DataSource {
        callOptions.dataModel = CyberDetectionProfileDataProvider.getKendoModel();

        callOptions.preParseResponse = (data: any): any => {
            return CyberDetectionProfileDataProvider.preParseResponse(data);
        };

        return CyberDetectionProfileDataService.getInstance().getLookupList(
            callOptions, isAggregated);
    }
  

    public static getDetailAsync(executeOptions: DataProviderExecuteOptions, cyberDetectionProfileId: string): Promise<CyberDetectionProfile> {
        executeOptions.preParseExecute = (cyberDetectionProfile: CyberDetectionProfile): CyberDetectionProfile => {
            return CyberDetectionProfileDataProvider.preParseExecute(cyberDetectionProfile);
        };

        var promise = new Promise<CyberDetectionProfile>((resolve, reject) => {
            executeOptions.callback = (cyberDetectionProfile: CyberDetectionProfile): void => {
                resolve(cyberDetectionProfile);
            }
        });

        CyberDetectionProfileDataService.getInstance().getDetail(
            executeOptions,
            cyberDetectionProfileId);

        return promise;
    }


    public static getDetail(executeOptions: DataProviderExecuteOptions, cyberDetectionProfileId: string): void {
        executeOptions.preParseExecute = (cyberDetectionProfile: CyberDetectionProfile): CyberDetectionProfile => {
            return CyberDetectionProfileDataProvider.preParseExecute(cyberDetectionProfile);
        };

        CyberDetectionProfileDataService.getInstance().getDetail(
            executeOptions,
            cyberDetectionProfileId);
    }


  

    public static create(executeOptions: DataProviderExecuteOptions,
        cyberDetectionProfile: CyberDetectionProfile): void {
        cyberDetectionProfile.companyContext = executeOptions.companyContext;

        CyberDetectionProfileDataService.getInstance().create(
            executeOptions,
            cyberDetectionProfile);
    }


  

    public static update(executeOptions: DataProviderExecuteOptions,
        cyberDetectionProfile: CyberDetectionProfile): void {
        cyberDetectionProfile.companyContext = executeOptions.companyContext;

        CyberDetectionProfileDataService.getInstance().update(
            executeOptions,
            cyberDetectionProfile);
    }

    private static getKendoModel(): typeof kendo.data.Model {
        var fields: any = CyberDetectionProfileDataProvider.getFields();

        var model: typeof kendo.data.Model = kendo.data.Model.define({
            fields: fields
        });

        return model;
    }

    private static getFields(): any {
        return {
            refreshedOn: { type: 'date' },
            cyberDetectionProfileId: { type: 'string' },
            name: { type: 'string' },
            description: { type: 'string' },
            companyContext: { type: 'string' },
            createdOn: { type: 'date' }
        };
    }

    private static preParseResponse(data: any): any {
        var cyberDetectionProfileList: Array<CyberDetectionProfile> = data.result;

        if (data.result === void 0) {
            cyberDetectionProfileList = data;
        }

        _.each<CyberDetectionProfile>(cyberDetectionProfileList, (cyberDetectionProfile: CyberDetectionProfile): void => {
            CyberDetectionProfileDataProvider.preParseExecute(cyberDetectionProfile);
        });

        return data;
    }

    protected static preParseExecute(cyberDetectionProfile: CyberDetectionProfile): CyberDetectionProfile {
        if (cyberDetectionProfile.cyberDetectionProfileId.length === 0) {
            cyberDetectionProfile.cyberDetectionProfileId = null;
        }

        cyberDetectionProfile.createdOn = DateHelper.fromUtcDateTime(BaseDataProvider.parseDate(cyberDetectionProfile.createdOn));

        switch (cyberDetectionProfile.package.packageCode) {
            case CyberDetectionConstants.profileEntryPackageCode:
                cyberDetectionProfile.package.packageDisplayName = CyberDetectionConstants.entryPackageName;
                break;
            case CyberDetectionConstants.profileBusinessPackageCode:
                cyberDetectionProfile.package.packageDisplayName = CyberDetectionConstants.businessPackageName;
                break;
            default:
                break;
        }

        cyberDetectionProfile.companyName = UserInfo.getCompanyName(cyberDetectionProfile.companyContext);

        return cyberDetectionProfile;
    }

    private static getKendoTreeListModel(): typeof kendo.data.TreeListModel {
        var fields: any = CyberDetectionProfileDataProvider.getFields();

        var model: typeof kendo.data.TreeListModel = kendo.data.TreeListModel.define({
            id: 'cyberDetectionProfileId',
            fields: fields,
            expanded: true
        });

        return model;
    }
}

