import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class CustomInterceptor implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return this.handleAccess(req, next);
    }

    private handleAccess(request: HttpRequest<any>, next: HttpHandler) {
        const token = sessionStorage.getItem('tokenInfo');
        let changedRequest = request;
        const headerSettings: { [name: string]: string | string[]; } = {};
        for (const key of request.headers.keys()) {
            headerSettings[key] = request.headers.getAll(key);
        }
        if (token) {
            headerSettings['Authorization'] = 'Bearer ' + token;
        }
        //headerSettings['Content-Type'] = 'application/json';
        const newHeader = new HttpHeaders(headerSettings);
        changedRequest = request.clone({
            headers: newHeader
        });
        return next.handle(changedRequest);
    }
}