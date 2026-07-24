import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges, inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs';

import { Course } from '../models/course.model';
import { CreditLabelPipe } from '../pipes/credit-label.pipe';
import { enrollInCourse, unenrollFromCourse } from '../store/enrollment/enrollment.actions';
import { selectEnrolledIds } from '../store/enrollment/enrollment.selectors';

@Component({
  selector: 'app-course-card',
  imports: [CommonModule, CreditLabelPipe],
  templateUrl: './course-card.component.html',
  styleUrl: './course-card.component.css'
})
export class CourseCardComponent implements OnChanges {
  @Input() course!: Course;
  @Output() enrollRequested = new EventEmitter<number>();
  @Output() courseSelected = new EventEmitter<number>();

  isExpanded = false;
  private readonly store = inject(Store);
  enrolledIds$ = this.store.select(selectEnrolledIds);

  ngOnChanges(changes: SimpleChanges): void {
    console.log('Course input changed', changes['course']?.previousValue, changes['course']?.currentValue);
  }

  toggleDetails(): void {
    this.isExpanded = !this.isExpanded;
  }

  onCardClick(): void {
    this.courseSelected.emit(this.course.id);
  }

  onEnrollClick(event: MouseEvent): void {
    event.stopPropagation();
    this.enrolledIds$.pipe(take(1)).subscribe((enrolledIds) => {
      if (enrolledIds?.includes(this.course.id)) {
        this.store.dispatch(unenrollFromCourse({ courseId: this.course.id }));
      } else {
        this.store.dispatch(enrollInCourse({ courseId: this.course.id }));
      }

      this.enrollRequested.emit(this.course.id);
    });
  }
}
