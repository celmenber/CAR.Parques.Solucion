import { FormControl } from '@angular/forms';

export class espaciosBlancoValidator {
    static noEspacios(formControl: FormControl){
        if(formControl.value.indexOf(' ') >= 0){
            return { noEspacios: true };
        }
        return null;
    }
}