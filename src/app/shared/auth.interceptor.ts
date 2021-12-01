import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService:AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    console.log("Intercepting here...");
    let token = sessionStorage.getItem('jwtToken');
    //console.log(token)
    if(sessionStorage.getItem('username') && sessionStorage.getItem('jwtToken')){
      request=request.clone(
        {
          setHeaders:{
            Authorization:`Bearer ${token}`
          }
        })
    }
    return next.handle(request);
  }
}