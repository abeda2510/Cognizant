import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { Course } from '../models/course.model';

@Injectable({ providedIn: 'root' })
export class CourseService {
  private readonly apiUrl = 'http://localhost:3000/courses';
  private courses: Course[] = [
    { id: 1, name: 'Introduction to Angular', code: 'ANG101', credits: 3, gradeStatus: 'passed' },
    { id: 2, name: 'TypeScript Essentials', code: 'TS201', credits: 4, gradeStatus: 'pending' },
    { id: 3, name: 'RxJS Fundamentals', code: 'RX301', credits: 2, gradeStatus: 'failed' }
  ];

  getCourses(): Course[] {
    return [...this.courses];
  }

  getCourses$(): Observable<Course[]> {
    return this.http.get<Course[]>(this.apiUrl).pipe(
      map((courses) => courses.filter((course) => course.credits > 0)),
      catchError((error: Error) => {
        console.error(error);
        return throwError(() => new Error('Failed to load courses. Please try again.'));
      })
    );
  }

  getCourseById(id: number): Course | undefined {
    return this.courses.find((course) => course.id === id);
  }

  getCourseById$(id: number): Observable<Course | undefined> {
    return this.http.get<Course>(`${this.apiUrl}/${id}`).pipe(catchError(() => of(this.getCourseById(id))));
  }

  constructor(private readonly http: HttpClient) {}

  createCourse(course: Omit<Course, 'id'>): Observable<Course> {
    return this.http.post<Course>(this.apiUrl, course);
  }

  addCourse(course: Course): void {
    this.courses.push(course);
  }

  updateCourse(course: Course): Observable<Course> {
    return this.http.put<Course>(`${this.apiUrl}/${course.id}`, course);
  }

  updateCourseLocal(course: Course): void {
    const index = this.courses.findIndex((item) => item.id === course.id);
    if (index >= 0) {
      this.courses[index] = course;
    }
  }

  deleteCourse(courseId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${courseId}`);
  }

  deleteCourseLocal(courseId: number): void {
    this.courses = this.courses.filter((course) => course.id !== courseId);
  }
}
