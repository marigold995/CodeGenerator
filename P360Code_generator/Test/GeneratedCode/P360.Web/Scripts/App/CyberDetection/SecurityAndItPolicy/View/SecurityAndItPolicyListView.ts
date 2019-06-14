

import { BaseGridView } from 'App/Base/BaseGridView';
import { Constants } from 'App/Base/Constants';
import { CommandEvent } from 'App/Base/Controls/CommandEvent';
import { GridColumnOption } from 'App/Base/Controls/Grid/GridColumnOption';
import { GridOptions } from 'App/Base/Controls/Grid/GridOptions';
import { NavigateToEvent } from 'App/Base/Controls/NavigateToEvent';
import { ViewAction } from 'App/Base/Controls/SideNavbar/ViewAction';
import { DateHelper } from 'App/Base/Helpers/DateHelper';
import { Permissions } from 'App/Base/Permissions';
import { SecurityAndItPolicy } from 'App/CyberDetection/SecurityAndItPolicy/Model/SecurityAndItPolicy';
import { SecurityAndItPolicyListViewModel } from 'App/CyberDetection/SecurityAndItPolicy/ViewModel/SecurityAndItPolicyListViewModel';
import { CompanyHelper } from 'App/Base/Helpers/CompanyHelper';
import { Security } from 'App/Base/Framework/Security';
import { CompanyInfo } from "App/Base/Framework/CompanyInfo";

export class SecurityAndItPolicyListView extends BaseGridView<SecurityAndItPolicyListViewModel> {

    constructor() {
        super(new SecurityAndItPolicyListViewModel());
	}

	public init(e: kendo.ViewEvent): void {
        super.init(e);

        this.viewModel.bind(Constants.dataSourceChangedEventName, (): void => this.onGridDataSourceChanged());
    }

    public show(): void {
        super.show();
        
        this.viewModel.loadData();
    }

    public afterLoadData(): void {
        super.afterLoadData();
        this.showCompanyColumn(true);
    }

    protected initControls(): void {
        super.initControls();

        this.initGrid(this.gridOptions);
    }

    public loadViewActions(viewActions: Array<ViewAction>): void {
        super.loadViewActions(viewActions);
    }

    protected canShowNewButton(canShowNewButton: boolean): boolean {
        return canShowNewButton
            && !CompanyHelper.isRootCompany(this.viewModel.dp.companyContext)
            && CompanyInfo.hasCyberDetectionContract;
    }

    protected canNavigateTo(canNavigateTo: boolean): boolean {
        return true;
    }

    public onGridDataSourceChanged(): void {
        this.setDataSource(this.viewModel.securityAndItPolicyDataSource);
    }

    protected onNavigateTo(e: NavigateToEvent<SecurityAndItPolicy>): void {

    }

    protected onCommand(e: CommandEvent<SecurityAndItPolicy>): void {

    }

    public static create(): SecurityAndItPolicyListView {
        return new SecurityAndItPolicyListView();
    }

}

