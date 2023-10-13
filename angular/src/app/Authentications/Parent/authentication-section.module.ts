import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from '../Childs/sign-in/sign-in.component';
import { ForgotPasswordComponent } from '../Childs/forgot-password/forgot-password.component';

const routes:Routes=
[
{path:'',component:SignInComponent},
{path:'forgot-password',component:ForgotPasswordComponent},
]

@NgModule({
  declarations: [SignInComponent, ForgotPasswordComponent],
  imports: [
    CommonModule, RouterModule.forChild(routes)
  ]
})
export class AuthenticationSectionModule { }
