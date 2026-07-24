import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-enrollment-form',
  imports: [CommonModule, FormsModule],
  templateUrl: './enrollment-form.component.html',
  styleUrl: './enrollment-form.component.css'
})
export class EnrollmentFormComponent {
  submitted = false;
  isDirty = false;
  model = {
    studentName: '',
    studentEmail: '',
    courseId: '',
    preferredSemester: 'Odd',
    agreeToTerms: false
  };

  onSubmit(form: NgForm): void {
    this.submitted = true;
    this.isDirty = !!form.dirty;
    console.log(this.model);
    console.log(form.value, form.valid);
  }

  resetForm(form: NgForm): void {
    form.resetForm({ preferredSemester: 'Odd' });
    this.submitted = false;
    this.isDirty = false;
  }
}
