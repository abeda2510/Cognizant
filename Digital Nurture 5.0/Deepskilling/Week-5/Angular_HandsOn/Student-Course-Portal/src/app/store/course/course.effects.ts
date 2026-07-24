import { Injectable, inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, retry, switchMap, tap } from 'rxjs';

import { CourseService } from '../../services/course.service';
import { loadCourses, loadCoursesFailure, loadCoursesSuccess } from './course.actions';

@Injectable()
export class CourseEffects {
  private readonly actions$ = inject(Actions);
  private readonly courseService = inject(CourseService);

  readonly loadCourses$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadCourses),
      switchMap(() =>
        this.courseService.getCourses$().pipe(
          retry(2),
          tap((courses) => console.log('Courses loaded:', courses.length)),
          map((courses) => loadCoursesSuccess({ courses })),
          catchError((error: Error) => of(loadCoursesFailure({ error: error.message || 'Failed to load courses. Please try again.' })))
        )
      )
    )
  );
}