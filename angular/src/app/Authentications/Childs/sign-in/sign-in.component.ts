import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ROUT_URLS } from 'src/environments/environment';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent {
constructor(private router: Router)
{
this.adminURL = ROUT_URLS.AdminPage;
this.forgotPasswordURL = ROUT_URLS.ForgotPassword;
}

adminURL:string;
forgotPasswordURL:string;
  ForgotPasswordClick()
  {
    console.log('Forgot Passwor');
    this.router.navigate(['/forgot-password']);
  }
}
