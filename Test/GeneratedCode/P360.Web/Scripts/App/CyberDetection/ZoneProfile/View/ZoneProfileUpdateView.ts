import { BaseDetailView } from 'App/Base/BaseDetailView';
import { CommandButton } from 'App/Base/Controls/CommandButton';
import { CommandEvent } from 'App/Base/Controls/CommandEvent';
import { GridColumnOption } from "App/Base/Controls/Grid/GridColumnOption";
import { GridControl } from "App/Base/Controls/Grid/GridControl";
import { GridOptions } from "App/Base/Controls/Grid/GridOptions";
import { ViewAction } from 'App/Base/Controls/SideNavbar/ViewAction';
import { TemplateDialogOptions } from 'App/Base/Dialog/TemplateDialogOptions';
import { NavigateParameters } from 'App/Base/Framework/NavigateParameters';
import { UserInfo } from 'App/Base/Framework/UserInfo';
import { TemplateBody } from 'App/Base/Model/TemplateBody';
import { ZoneProfileValidator } from 'App/CyberDetection/ZoneProfile/Validator/ZoneProfileValidator';
import {ZoneProfileUpdateViewModel } from 'App/CyberDetection/ZoneProfile/ViewModel/ZoneProfileUpdateViewModel';
import { Permissions } from 'App/Base/Permissions';
import { Security } from 'App/Base/Framework/Security';

export class ZoneProfileUpdateView<T extends ZoneProfileUpdateViewModel> extends BaseDetailView<T> {
	constructor(viewModel: T) {
        super(viewModel);
	}

	public init(e: kendo.ViewEvent): void {
        super.init(e);
    }

    public show(): void {
        super.show();

        this.viewModel.loadData();
    }

    public hide(): void {
        super.hide();
	}
	
    protected initControls(): void {
        super.initControls();
	}

	public afterLoadData(): void {
        super.afterLoadData();
	}

	public beforeUpdate(): void {
        // placeholder
    }

    public afterUpdate(zoneProfileId: string): void {
        // placeholder
    }

    private onUpdate(callback: (success: boolean) => void): void {
        this.beforeUpdate();

        this.viewModel.update((success: boolean, zoneProfileId: string): void => {
            if (success) {
                this.onAfterUpdate(zoneProfileId);
            } else {
                this.showErrorSummaryContainer();
            }
        });
    }

    private onAfterUpdate(zoneProfileId: string): void {
        this.afterUpdate(zoneProfileId);

        this.navigateToUrl(new NavigateParameters(this.afterEditUrl(zoneProfileId === '' ? zoneProfileId : '')));
    }

    public static create(): ZoneProfileUpdateView<ZoneProfileUpdateViewModel> {
        return new ZoneProfileUpdateView(new ZoneProfileUpdateViewModel());
    }
}
