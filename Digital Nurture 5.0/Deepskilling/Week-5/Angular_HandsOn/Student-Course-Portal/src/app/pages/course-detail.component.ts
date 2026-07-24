import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../services/course.service';

@Component({
  selector: 'app-course-detail',
  imports: [CommonModule],
  templateUrl: './course-detail.component.html',
  styleUrl: './course-detail.component.css'
})
export class CourseDetailComponent {
  course: ReturnType<CourseService['getCourseById']> | undefined;

  constructor(private readonly route: ActivatedRoute, private readonly courseService: CourseService) {}

  ngOnInit(): void {
    this.course = this.courseService.getCourseById(Number(this.route.snapshot.paramMap.get('id')));
  }
}
