
import { BaseDataProvider } from 'App/Base/BaseDataProvider';
import { Constants } from 'App/Base/Constants';
import { DataProviderCallOptions } from 'App/Base/Data/DataProviderCallOptions';
import { DataProviderExecuteOptions } from 'App/Base/Data/DataProviderExecuteOptions';
import { DateHelper } from "App/Base/Helpers/DateHelper";
import { SecurityAndItPolicyDataService } from 'App/CyberDetection/SecurityAndItPolicy/Data/SecurityAndItPolicyDataService';
import { SecurityAndItPolicy } from 'App/CyberDetection/SecurityAndItPolicy/Model/SecurityAndItPolicy';
import * as _ from 'underscore';
import { CyberDetectionConstants } from 'App/CyberDetection/CyberDetectionConstants';
import { UserInfo } from 'App/Base/Framework/UserInfo';

export class SecurityAndItPolicyDataProvider extends BaseDataProvider {
    public static getDataSource(securityAndItPolicyList: Array<SecurityAndItPolicy>): kendo.data.DataSource {
        var dataSourceOptions: kendo.data.DataSourceOptions = {};

        dataSourceOptions.schema = {};

        dataSourceOptions.data = securityAndItPolicyList;

        dataSourceOptions.pageSize = Constants.defaultPageSize;

        dataSourceOptions.schema.model = SecurityAndItPolicyDataProvider.getKendoModel();
        dataSourceOptions.schema.parse = (data: any): any => {
            return SecurityAndItPolicyDataProvider.preParseResponse(data);
        };

        var dataSource: kendo.data.DataSource = new kendo.data.DataSource(dataSourceOptions);

        return dataSource;
    }

    public static getList(callOptions: DataProviderCallOptions): kendo.data.DataSource {
        callOptions.dataModel = SecurityAndItPolicyDataProvider.getKendoModel();

        callOptions.preParseResponse = (data: any): any => {
            return SecurityAndItPolicyDataProvider.preParseResponse(data);
        };

        return SecurityAndItPolicyDataService.getInstance().getList(
            callOptions);
    }

    public static getLookupListExecuted(executeOptions: DataProviderExecuteOptions): void {
        SecurityAndItPolicyDataService.getInstance().getLookupListExecuted(
            executeOptions);
    }

    public static refresh(executeOptions: DataProviderExecuteOptions): JQueryPromise<any> {
        return SecurityAndItPolicyDataService.getInstance().refresh(executeOptions);
    }

    public static getLookupList(callOptions: DataProviderCallOptions, isAggregated: boolean): kendo.data.DataSource {
        callOptions.dataModel = SecurityAndItPolicyDataProvider.getKendoModel();

        callOptions.preParseResponse = (data: any): any => {
            return SecurityAndItPolicyDataProvider.preParseResponse(data);
        };

        return SecurityAndItPolicyDataService.getInstance().getLookupList(
            callOptions, isAggregated);
    }
  

    public static getDetailAsync(executeOptions: DataProviderExecuteOptions, securityAndItPolicyId: string): Promise<SecurityAndItPolicy> {
        executeOptions.preParseExecute = (securityAndItPolicy: SecurityAndItPolicy): SecurityAndItPolicy => {
            return SecurityAndItPolicyDataProvider.preParseExecute(securityAndItPolicy);
        };

        var promise = new Promise<SecurityAndItPolicy>((resolve, reject) => {
            executeOptions.callback = (securityAndItPolicy: SecurityAndItPolicy): void => {
                resolve(securityAndItPolicy);
            }
        });

        SecurityAndItPolicyDataService.getInstance().getDetail(
            executeOptions,
            securityAndItPolicyId);

        return promise;
    }


    public static getDetail(executeOptions: DataProviderExecuteOptions, securityAndItPolicyId: string): void {
        executeOptions.preParseExecute = (securityAndItPolicy: SecurityAndItPolicy): SecurityAndItPolicy => {
            return SecurityAndItPolicyDataProvider.preParseExecute(securityAndItPolicy);
        };

        SecurityAndItPolicyDataService.getInstance().getDetail(
            executeOptions,
            securityAndItPolicyId);
    }


  

    public static create(executeOptions: DataProviderExecuteOptions,
        securityAndItPolicy: SecurityAndItPolicy): void {
        securityAndItPolicy.companyContext = executeOptions.companyContext;

        SecurityAndItPolicyDataService.getInstance().create(
            executeOptions,
            securityAndItPolicy);
    }


  

    public static update(executeOptions: DataProviderExecuteOptions,
        securityAndItPolicy: SecurityAndItPolicy): void {
        securityAndItPolicy.companyContext = executeOptions.companyContext;

        SecurityAndItPolicyDataService.getInstance().update(
            executeOptions,
            securityAndItPolicy);
    }

    private static getKendoModel(): typeof kendo.data.Model {
        var fields: any = SecurityAndItPolicyDataProvider.getFields();

        var model: typeof kendo.data.Model = kendo.data.Model.define({
            fields: fields
        });

        return model;
    }

    private static getFields(): any {
        return {
            refreshedOn: { type: 'date' },
            securityAndItPolicyId: { type: 'string' },
            name: { type: 'string' },
            description: { type: 'string' },
            companyContext: { type: 'string' },
            createdOn: { type: 'date' }
        };
    }

    private static preParseResponse(data: any): any {
        var securityAndItPolicyList: Array<SecurityAndItPolicy> = data.result;

        if (data.result === void 0) {
            securityAndItPolicyList = data;
        }

        _.each<SecurityAndItPolicy>(securityAndItPolicyList, (securityAndItPolicy: SecurityAndItPolicy): void => {
            SecurityAndItPolicyDataProvider.preParseExecute(securityAndItPolicy);
        });

        return data;
    }

    protected static preParseExecute(securityAndItPolicy: SecurityAndItPolicy): SecurityAndItPolicy {
        if (securityAndItPolicy.securityAndItPolicyId.length === 0) {
            securityAndItPolicy.securityAndItPolicyId = null;
        }

        securityAndItPolicy.createdOn = DateHelper.fromUtcDateTime(BaseDataProvider.parseDate(securityAndItPolicy.createdOn));

        switch (securityAndItPolicy.package.packageCode) {
            case CyberDetectionConstants.profileEntryPackageCode:
                securityAndItPolicy.package.packageDisplayName = CyberDetectionConstants.entryPackageName;
                break;
            case CyberDetectionConstants.profileBusinessPackageCode:
                securityAndItPolicy.package.packageDisplayName = CyberDetectionConstants.businessPackageName;
                break;
            default:
                break;
        }

        securityAndItPolicy.companyName = UserInfo.getCompanyName(securityAndItPolicy.companyContext);

        return securityAndItPolicy;
    }

    private static getKendoTreeListModel(): typeof kendo.data.TreeListModel {
        var fields: any = SecurityAndItPolicyDataProvider.getFields();

        var model: typeof kendo.data.TreeListModel = kendo.data.TreeListModel.define({
            id: 'securityAndItPolicyId',
            fields: fields,
            expanded: true
        });

        return model;
    }
}

