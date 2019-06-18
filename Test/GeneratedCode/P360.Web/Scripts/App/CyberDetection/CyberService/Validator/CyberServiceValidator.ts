










import { BaseValidator } from 'App/Base/BaseValidator';
import { ValidationResult } from 'App/Base/Model/ValidationResult';
import { Localization } from 'App/Base/Framework/Localization';

export class CyberServiceValidator extends BaseValidator {
    
    public setRules(rules: any): void {
        super.setRules(rules);
    }

    public setMessages(messages: any): void {
        super.setMessages(messages);
    }

    public pushValidators(validators: Array<kendo.ui.Validator>): void {
        super.pushValidators(validators);
    }

    public hideMessages(): void {
        super.hideMessages();
    }

    public validate(): ValidationResult {
        return super.validate();
    }
}

