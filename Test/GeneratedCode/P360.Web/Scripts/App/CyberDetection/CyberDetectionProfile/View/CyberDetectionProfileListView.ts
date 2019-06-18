

import { BaseGridView } from 'App/Base/BaseGridView';
import { Constants } from 'App/Base/Constants';
import { CommandEvent } from 'App/Base/Controls/CommandEvent';
import { GridColumnOption } from 'App/Base/Controls/Grid/GridColumnOption';
import { GridOptions } from 'App/Base/Controls/Grid/GridOptions';
import { NavigateToEvent } from 'App/Base/Controls/NavigateToEvent';
import { ViewAction } from 'App/Base/Controls/SideNavbar/ViewAction';
import { DateHelper } from 'App/Base/Helpers/DateHelper';
import { Permissions } from 'App/Base/Permissions';
import { CyberDetectionProfile } from 'App/CyberDetection/CyberDetectionProfile/Model/CyberDetectionProfile';
import { CyberDetectionProfileListViewModel } from 'App/CyberDetection/CyberDetectionProfile/ViewModel/CyberDetectionProfileListViewModel';
import { CompanyHelper } from 'App/Base/Helpers/CompanyHelper';
import { Security } from 'App/Base/Framework/Security';
import { CompanyInfo } from "App/Base/Framework/CompanyInfo";

export class CyberDetectionProfileListView extends BaseGridView<CyberDetectionProfileListViewModel> {

    constructor() {
        super(new CyberDetectionProfileListViewModel());
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
        this.setDataSource(this.viewModel.cyberDetectionProfileDataSource);
    }

    protected onNavigateTo(e: NavigateToEvent<CyberDetectionProfile>): void {

    }

    protected onCommand(e: CommandEvent<CyberDetectionProfile>): void {

    }

    public static create(): CyberDetectionProfileListView {
        return new CyberDetectionProfileListView();
    }

}

