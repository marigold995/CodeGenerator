
import { BaseDetailView } from "App/Base/BaseDetailView";
import { PopUpOptions } from 'App/Base/Dialog/PopUpOptions';
import { ViewAction } from "App/Base/Controls/SideNavbar/ViewAction";
import { ZoneProfileDetailViewModel } from "App/CyberDetection/ZoneProfile/ViewModel/ZoneProfileDetailViewModel";
import { GridOptions } from "App/Base/Controls/Grid/GridOptions";
import { GridColumnOption } from "App/Base/Controls/Grid/GridColumnOption";
import { GridControl } from "App/Base/Controls/Grid/GridControl";

export class ZoneProfileDetailView<T extends ZoneProfileDetailViewModel> extends BaseDetailView<T>{

    constructor(viewModel: T) {
        super(viewModel);
    }

    public init(e: kendo.ViewEvent): void {
        super.init(e);
    }

    protected initControls(): void {
        super.initControls();
    }

    public show(): void {
        super.show();
        this.viewModel.loadData();
    }

    public hide(): void {
        super.hide();
    }

    public afterLoadData(): void {
        super.afterLoadData();
    }

    public loadViewActions(viewActions: Array<ViewAction>): void {
        super.loadViewActions(viewActions);
    }

    protected onNavigateHandler(e: JQueryEventObject): void {
        super.onNavigateHandler(e);
    }

    protected onCreate(callback: (success: boolean) => void): void {
        callback(true);
    }


    protected onEdit(callback: (success: boolean) => void): void {
        callback(true);
    }


    protected onDelete(callback: (success: boolean) => void): void {
        var displayName: string = this.viewModel.zoneProfile.zoneProfileId;
        var title: string = 'ConfirmDelete';
        var message: string = 'ConfirmDeleteMessage';

        var popUpOptions: PopUpOptions = new PopUpOptions(title, message, displayName)
            .setOkButtonName('Delete');

        this.showPopUpDialog(popUpOptions,
            (responseOk: boolean): void => {
                if (responseOk) {
                    this.onDeleteConfirm(callback);
                }
            });
    }
    protected onDeleteConfirm(callback: (success: boolean) => void): void {
        // placeholder
    }

    public static create(): ZoneProfileDetailView<ZoneProfileDetailViewModel> {
        return new ZoneProfileDetailView(new ZoneProfileDetailViewModel());
    }

