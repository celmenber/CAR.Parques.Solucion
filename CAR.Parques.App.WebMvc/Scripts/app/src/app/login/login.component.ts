import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { RegistroComponent } from '../usuario/registro/registro.component';
import { NotificacionComponent } from '../shared/notificacion/notificacion.component';
import { OlvidoContraseniaComponent } from '../usuario/olvido-contrasenia/olvido-contrasenia.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginError = '';
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private router : Router, private authService: AuthService, public dialog: MatDialog, private appBase: NotificacionComponent) { }

  ngOnInit(): void {
    this.authService.logout();
    this.buildLoginForm();
  }

  buildLoginForm(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(2),Validators.maxLength(50)]]
    });
  }

  login(submittedForm: FormGroup){
    this.authService.login(submittedForm.value.email, submittedForm.value.password)
    .subscribe(
      authResponse => {
      this.router.navigate(['/home']);
    }, error => {
      this.appBase.openSnackBar("Usuario y/o contraseña incorrectos.", "error-notificacion");
    });
  }

  abrirRegistroDialog(): void {
    let dialogRef = this.dialog.open(RegistroComponent, {
      panelClass: "new-modal-dialog"
    });
  }

  abrirOlvidoContraseniaDialog(): void {
    let dialogRef = this.dialog.open(OlvidoContraseniaComponent, {
      panelClass: "new-modal-dialog"
    });
  }
}
