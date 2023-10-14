import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../Childs/dashboard/dashboard.component';

const routers:Routes =
[
  {path:'', component: DashboardComponent},
  {path:'dashboard', component: DashboardComponent},
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,RouterModule.forChild(routers)
  ]
})
export class AdminSectionModule {}
