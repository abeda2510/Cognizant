import { createFeatureSelector, createSelector } from '@ngrx/store';

import { enrollmentFeatureKey, EnrollmentState } from './enrollment.reducer';

export const selectEnrollmentState = createFeatureSelector<EnrollmentState>(enrollmentFeatureKey);
export const selectEnrolledIds = createSelector(selectEnrollmentState, (state) => state.enrolledCourseIds);
