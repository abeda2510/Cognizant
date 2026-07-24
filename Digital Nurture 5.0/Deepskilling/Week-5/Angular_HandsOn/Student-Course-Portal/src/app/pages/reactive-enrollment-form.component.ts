import { CommonModule } from '@angular/common';
import {
  AbstractControl,
  AsyncValidatorFn,
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators
} from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { delay, map, of } from 'rxjs';

@Component({
  selector: 'app-reactive-enrollment-form',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reactive-enrollment-form.component.html',
  styleUrl: './reactive-enrollment-form.component.css'
})
export class ReactiveEnrollmentFormComponent implements OnInit {
  enrollForm!: FormGroup;

  constructor(private readonly fb: FormBuilder) {}

  ngOnInit(): void {
    this.enrollForm = this.fb.group({
      studentName: ['', [Validators.required, Validators.minLength(3)]],
      studentEmail: this.fb.control('', [Validators.required, Validators.email], [this.simulateEmailCheck()]),
      courseId: ['', [Validators.required, this.noCourseCode]],
      preferredSemester: ['Odd', Validators.required],
      agreeToTerms: [false, Validators.requiredTrue],
      additionalCourses: this.fb.array([])
    });
  }

  get isDirty(): boolean {
    return this.enrollForm?.dirty ?? false;
  }

  noCourseCode(control: AbstractControl): ValidationErrors | null {
    const value = String(control.value ?? '');
    return value.startsWith('XX') ? { noCourseCode: true } : null;
  }

  simulateEmailCheck(): AsyncValidatorFn {
    return (control: AbstractControl) => {
      const value = String(control.value ?? '');
      return of(value).pipe(
        delay(800),
        map((email) => (email.includes('test@') ? { emailTaken: true } : null))
      );
    };
  }

  get additionalCourses(): FormArray {
    return this.enrollForm.get('additionalCourses') as FormArray<FormControl<string>>;
  }

  addCourse(): void {
    this.additionalCourses.push(new FormControl('', Validators.required));
  }

  removeCourse(index: number): void {
    this.additionalCourses.removeAt(index);
  }

  onSubmit(): void {
    console.log(this.enrollForm.value);
    console.log(this.enrollForm.getRawValue());
  }
}
