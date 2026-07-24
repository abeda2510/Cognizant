import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req.clone({ setHeaders: { Authorization: 'Bearer mock-token-12345' } }));
};
