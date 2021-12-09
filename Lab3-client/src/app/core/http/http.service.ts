import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
//import { NzNotificationService } from 'ng-zorro-antd';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class HttpService {

    constructor(private httpClient: HttpClient) {
    }

    public doGet<T>(url: string): Observable<T> {
        return this.httpClient.get<T>(url).pipe(catchError(errorResponse => {
            return new Observable<never>();
        }));
    }

    public doPost<T>(url: string, object: any): Observable<T> {
        return this.httpClient.post<T>(url, object).pipe(catchError(errorResponse => {
            return new Observable<never>();
        }));
    }

    public doPut<T>(url: string, object: any): Observable<T> {
        return this.httpClient.put<T>(url, object).pipe(catchError(errorResponse => {
            return new Observable<never>();
        }));
    }

    public doDelete<T>(url: string): Observable<T> {
        return this.httpClient.delete<T>(url).pipe(catchError(errorResponse => {
            return new Observable<never>();
        }));
    }
}