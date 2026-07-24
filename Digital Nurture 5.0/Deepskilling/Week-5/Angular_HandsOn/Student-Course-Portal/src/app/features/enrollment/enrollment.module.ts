import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EnrollmentFormComponent } from '../../pages/enrollment-form.component';
import { ReactiveEnrollmentFormComponent } from '../../pages/reactive-enrollment-form.component';
import { EnrollmentRoutingModule } from './enrollment-routing.module';

@NgModule({
  imports: [CommonModule, EnrollmentRoutingModule, EnrollmentFormComponent, ReactiveEnrollmentFormComponent]
})
export class EnrollmentModule {}
