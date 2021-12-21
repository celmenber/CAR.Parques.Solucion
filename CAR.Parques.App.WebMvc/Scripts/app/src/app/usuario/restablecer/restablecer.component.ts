import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { restablecerObject } from 'src/app/models/usuario/usuarioOlvido';
import { UsuarioService } from 'src/app/servicios/usuario/usuario.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { espaciosBlancoValidator } from 'src/app/shared/validators/espaciosBlancoValidator';

@Component({
  selector: 'app-restablecer',
  templateUrl: './restablecer.component.html',
  styleUrls: ['./restablecer.component.scss']
})
export class RestablecerComponent implements OnInit {

  public token: string = '';
  restablecimiento: restablecerObject;
  cambioError = '';

  cambioContraseniaForm: FormGroup;
  constructor(private fb: FormBuilder, 
    private usuarioService: UsuarioService,
    private appBase: NotificacionComponent,
    private route: ActivatedRoute,
    private routerNav : Router) { }

  ngOnInit(): void {
    this.token = this.route.snapshot.params['token'];
    this.buildCambioForm();
  }

  buildCambioForm(): void {
    this.cambioContraseniaForm = this.fb.group({
      passwordUsuario: ['', Validators.compose([Validators.required, espaciosBlancoValidator.noEspacios])],
      passwordUsuarioConfirma: ['']
    },{validator: this.confirmarCoincidenciaContrasenia });
  }

  confirmarCoincidenciaContrasenia(group: FormGroup) {
    let passwordInput = group.get('passwordUsuario').value;
    let passwordConfirmationInput = group.controls['passwordUsuarioConfirma'];
    console.log(passwordInput === passwordConfirmationInput.value);
    if(passwordInput !== passwordConfirmationInput.value)
    {
      return passwordConfirmationInput.setErrors({notEquivalent: true});
    }
    return passwordConfirmationInput.setErrors(null);
}

  cambiarContrasenia(submittedForm: FormGroup){
    console.log(this.cambioContraseniaForm);
    if(this.cambioContraseniaForm.dirty && this.cambioContraseniaForm.valid) {
      this.restablecimiento = {
        Contrasenia : submittedForm.value.passwordUsuario,
        Token: this.token
      }
      this.usuarioService.restablecer(this.restablecimiento)
      .subscribe(
        Response => {
          console.log(Response);
          if(Response.Codigo === 200 && Response.Entidad.Codigo !== 0)
          {
            this.appBase.openSnackBar("Restablecimiento exitoso.","exito-notificacion");
            this.routerNav.navigate(['/login']);
          }
          else
          {
            this.appBase.openSnackBar(Response.Entidad.Descripcion,"error-notificacion"); 
            this.routerNav.navigate(['/login']);
          }
        }, error => {
          this.appBase.openSnackBar("Error al realizar el proceso de restablecimiento. Intente más tarde.", "error-notificacion");
          this.routerNav.navigate(['/login']);
        });
    }
    else if (!this.cambioContraseniaForm.dirty) {
      this.cambioContraseniaForm.reset();
    }
  }
}
