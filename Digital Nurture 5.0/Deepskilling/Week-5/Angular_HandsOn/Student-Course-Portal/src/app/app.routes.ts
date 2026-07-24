import { Routes } from '@angular/router';

import { authGuard } from './guards/auth.guard';
import { CourseDetailComponent } from './pages/course-detail.component';
import { CourseListComponent } from './pages/course-list.component';
import { HomeComponent } from './pages/home.component';
import { NotFoundComponent } from './pages/not-found.component';
import { StudentProfileComponent } from './pages/student-profile.component';

export const routes: Routes = [
	{ path: '', component: HomeComponent },
	{ path: 'courses', component: CourseListComponent },
	{ path: 'courses/:id', component: CourseDetailComponent },
	{ path: 'profile', canActivate: [authGuard], component: StudentProfileComponent },
	{ path: 'enroll', loadChildren: () => import('./features/enrollment/enrollment.module').then((m) => m.EnrollmentModule) },
	{ path: '**', component: NotFoundComponent }
];
