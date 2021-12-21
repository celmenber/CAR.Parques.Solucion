import { FormControl } from '@angular/forms';

export class SoloLetrasValidator {
    static soloLetras(formControl: FormControl){
        var expresion = /(^$)|(^[A-Z]+$)/i;
        var coincidencia = expresion.test(formControl.value);
        if(!coincidencia)
        {
            return { soloLetras: true };
        }
        return null;
    }
}