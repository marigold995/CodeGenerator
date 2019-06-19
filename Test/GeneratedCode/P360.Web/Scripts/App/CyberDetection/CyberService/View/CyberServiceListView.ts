


import { BaseGridView } from 'App/Base/BaseGridView';
import { Constants } from 'App/Base/Constants';
import { CommandEvent } from 'App/Base/Controls/CommandEvent';
import { GridColumnOption } from 'App/Base/Controls/Grid/GridColumnOption';
import { GridOptions } from 'App/Base/Controls/Grid/GridOptions';
import { NavigateToEvent } from 'App/Base/Controls/NavigateToEvent';
import { ViewAction } from 'App/Base/Controls/SideNavbar/ViewAction';
import { DateHelper } from 'App/Base/Helpers/DateHelper';
import { Permissions } from 'App/Base/Permissions';
import { CyberService } from 'App/CyberDetection/CyberService/Model/CyberService';
import { CyberServiceListViewModel } from 'App/CyberDetection/CyberService/ViewModel/CyberServiceListViewModel';
import { CompanyHelper } from 'App/Base/Helpers/CompanyHelper';
import { Security } from 'App/Base/Framework/Security';
import { CompanyInfo } from "App/Base/Framework/CompanyInfo";

export class CyberServiceListView extends BaseGridView<CyberServiceListViewModel> {

    constructor() {
        super(new CyberServiceListViewModel());
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
        this.setDataSource(this.viewModel.cyberServiceDataSource);
    }

    protected onNavigateTo(e: NavigateToEvent<CyberService>): void {

    }

    protected onCommand(e: CommandEvent<CyberService>): void {

    }

    public static create(): CyberServiceListView {
        return new CyberServiceListView();
    }

}

