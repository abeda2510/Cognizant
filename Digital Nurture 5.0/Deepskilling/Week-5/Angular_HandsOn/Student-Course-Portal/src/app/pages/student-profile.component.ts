import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Store } from '@ngrx/store';

import { NotificationComponent } from '../components/notification.component';
import { EnrollmentService } from '../services/enrollment.service';
import { selectEnrolledIds } from '../store/enrollment/enrollment.selectors';

@Component({
  selector: 'app-student-profile',
  imports: [CommonModule, NotificationComponent],
  templateUrl: './student-profile.component.html',
  styleUrl: './student-profile.component.css'
})
export class StudentProfileComponent {
  private readonly store = inject(Store);
  enrolledIds$ = this.store.select(selectEnrolledIds);

  constructor(public readonly enrollmentService: EnrollmentService) {}
}
