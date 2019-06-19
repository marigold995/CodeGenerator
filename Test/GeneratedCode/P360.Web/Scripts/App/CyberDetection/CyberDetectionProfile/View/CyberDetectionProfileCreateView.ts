



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
import { CyberDetectionProfileCreateViewModel } from 'App/CyberDetection/CyberDetectionProfile/ViewModel/CyberDetectionProfileCreateViewModel';
import { Site } from 'App/Core/Site/Model/Site';
import { Permissions } from 'App/Base/Permissions';
import { Security } from 'App/Base/Framework/Security';
import * as _ from 'underscore';

export class CyberDetectionProfileCreateView<T extends CyberDetectionProfileCreateViewModel> extends BaseDetailView<T> {
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

	public beforeCreate(): void {
        // placeholder
    }

    public afterCreate(cyberDetectionProfileId: string): void {
        // placeholder
    }

    private onCreate(callback: (success: boolean) => void): void {
        this.beforeCreate();

        this.viewModel.create((success: boolean, cyberDetectionProfileId: string): void => {
            if (success) {
                this.onAfterCreate(cyberDetectionProfileId);
            } else {
                this.showErrorSummaryContainer();
            }
        });
    }

    private onAfterCreate(cyberDetectionProfileId: string): void {
        this.afterCreate(cyberDetectionProfileId);

        this.navigateToUrl(new NavigateParameters(this.afterCreateUrl(cyberDetectionProfileId === '' ? cyberDetectionProfileId : '')));
    }

    public static create(): CyberDetectionProfileCreateView<CyberDetectionProfileCreateViewModel> {
        return new CyberDetectionProfileCreateView(new CyberDetectionProfileCreateViewModel());
    }
}

