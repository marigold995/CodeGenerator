



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
import { CyberDetectionProfileValidator } from 'App/CyberDetection/CyberDetectionProfile/Validator/CyberDetectionProfileValidator';
import {CyberDetectionProfileUpdateViewModel } from 'App/CyberDetection/CyberDetectionProfile/ViewModel/CyberDetectionProfileUpdateViewModel';
import { Permissions } from 'App/Base/Permissions';
import { Security } from 'App/Base/Framework/Security';

export class CyberDetectionProfileUpdateView<T extends CyberDetectionProfileUpdateViewModel> extends BaseDetailView<T> {
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

    public afterUpdate(cyberDetectionProfileId: string): void {
        // placeholder
    }

    private onUpdate(callback: (success: boolean) => void): void {
        this.beforeUpdate();

        this.viewModel.update((success: boolean, cyberDetectionProfileId: string): void => {
            if (success) {
                this.onAfterUpdate(cyberDetectionProfileId);
            } else {
                this.showErrorSummaryContainer();
            }
        });
    }

    private onAfterUpdate(cyberDetectionProfileId: string): void {
        this.afterUpdate(cyberDetectionProfileId);

        this.navigateToUrl(new NavigateParameters(this.afterEditUrl(cyberDetectionProfileId === '' ? cyberDetectionProfileId : '')));
    }

    public static create(): CyberDetectionProfileUpdateView<CyberDetectionProfileUpdateViewModel> {
        return new CyberDetectionProfileUpdateView(new CyberDetectionProfileUpdateViewModel());
    }
}
