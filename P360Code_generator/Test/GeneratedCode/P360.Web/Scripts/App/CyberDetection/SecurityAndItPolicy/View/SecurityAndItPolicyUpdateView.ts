
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
import { SecurityAndItPolicyValidator } from 'App/CyberDetection/SecurityAndItPolicy/Validator/SecurityAndItPolicyValidator';
import {SecurityAndItPolicyUpdateViewModel } from 'App/CyberDetection/SecurityAndItPolicy/ViewModel/SecurityAndItPolicyUpdateViewModel';
import { Permissions } from 'App/Base/Permissions';
import { Security } from 'App/Base/Framework/Security';

export class SecurityAndItPolicyUpdateView<T extends SecurityAndItPolicyUpdateViewModel> extends BaseDetailView<T> {
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

    public afterUpdate(securityAndItPolicyId: string): void {
        // placeholder
    }

    private onUpdate(callback: (success: boolean) => void): void {
        this.beforeUpdate();

        this.viewModel.update((success: boolean, securityAndItPolicyId: string): void => {
            if (success) {
                this.onAfterUpdate(securityAndItPolicyId);
            } else {
                this.showErrorSummaryContainer();
            }
        });
    }

    private onAfterUpdate(securityAndItPolicyId: string): void {
        this.afterUpdate(securityAndItPolicyId);

        this.navigateToUrl(new NavigateParameters(this.afterEditUrl(securityAndItPolicyId === '' ? securityAndItPolicyId : '')));
    }

    public static create(): SecurityAndItPolicyUpdateView<SecurityAndItPolicyUpdateViewModel> {
        return new SecurityAndItPolicyUpdateView(new SecurityAndItPolicyUpdateViewModel());
    }
}
