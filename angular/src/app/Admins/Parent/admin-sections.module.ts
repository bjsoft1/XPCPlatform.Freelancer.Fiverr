import { NgModule } from '@angular/core';
import { SharedModule } from './shared/shared.module';
import { AdminSectionsComponent } from './admin-sections.component';



@NgModule({
  declarations: [AdminSectionsComponent],
  imports: [SharedModule],
})
export class AdminSectionModule {}
