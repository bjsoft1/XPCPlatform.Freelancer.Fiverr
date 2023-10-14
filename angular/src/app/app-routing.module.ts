import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ROUT_URLS, environment } from 'src/environments/environment';

const routes: Routes = [
  {path:ROUT_URLS.HomePage,loadChildren:()=>import('./Authentications/Parent/authentication-section.module').then(m=>m.AuthenticationSectionModule)},
  {path:ROUT_URLS.AdminPage,loadChildren:()=>import('./Admins/Parent/admin-sections.module').then(m=>m.AdminSectionModule)},

  // {
  //   path: '',
  //   pathMatch: 'full',
  //   loadChildren: () => import('./Admins/Parent/admin-sections.module').then(m => m.AdminSectionModule),
  // },
  // {
  //   path: 'account',
  //   loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  // },
  // {
  //   path: 'identity',
  //   loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  // },
  // {
  //   path: 'tenant-management',
  //   loadChildren: () =>
  //     import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  // },
  // {
  //   path: 'setting-management',
  //   loadChildren: () =>
  //     import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
