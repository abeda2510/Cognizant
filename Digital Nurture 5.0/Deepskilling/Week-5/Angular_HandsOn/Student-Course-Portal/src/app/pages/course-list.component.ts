import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';

import { CourseCardComponent } from '../components/course-card.component';
import { HighlightDirective } from '../directives/highlight.directive';
import { Course } from '../models/course.model';
import { loadCourses } from '../store/course/course.actions';
import { selectAllCourses, selectCoursesError, selectCoursesLoading } from '../store/course/course.selectors';

@Component({
  selector: 'app-course-list',
  imports: [CommonModule, CourseCardComponent, HighlightDirective],
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.css'
})
export class CourseListComponent implements OnInit {
  selectedCourseId: number | null = null;
  searchTerm = '';
  private readonly store = inject(Store);
  courses$ = this.store.select(selectAllCourses);
  loading$ = this.store.select(selectCoursesLoading);
  error$ = this.store.select(selectCoursesError);

  constructor(
    private readonly router: Router,
    private readonly route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.searchTerm = this.route.snapshot.queryParamMap.get('search') ?? '';
    this.store.dispatch(loadCourses());
  }

  onEnroll(courseId: number): void {
    console.log('Enrolling in course: ' + courseId);
    this.selectedCourseId = courseId;
  }

  onCourseSelected(courseId: number): void {
    void this.router.navigate(['courses', courseId]);
  }

  onSearchChange(term: string): void {
    this.searchTerm = term;
    void this.router.navigate(['courses'], { queryParams: term ? { search: term } : {} });
  }

  trackByCourseId(index: number, course: Course): number {
    return course.id;
  }
}
