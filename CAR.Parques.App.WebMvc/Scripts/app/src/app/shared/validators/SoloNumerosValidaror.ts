import { FormControl } from '@angular/forms';

export class SoloNumerosValidator {
    static soloNumeros(formControl: FormControl){
        var expresion = /^([0-9])*$/;
        var coincidencia = expresion.test(formControl.value);
        if(!coincidencia)
        {
            return { soloNumeros: true };
        }
        return null;
    }
}