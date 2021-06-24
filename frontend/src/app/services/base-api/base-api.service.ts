import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { ApiOptions } from './api-options.model';

@Injectable({
  providedIn: 'root'
})
export class BaseApiService {

  constructor(private httpClient: HttpClient) { }

  private getFullUrl(options: ApiOptions): string {
    return options == null ? '' :
      `${environment.apiurl}/${options.endpoint ?? ''}/${options.action ?? ''}`;
  }

  private getHttpOptions(options: ApiOptions): any {
    return {
      responseType: options.responseType
    };
  }

  public get<T>(options: ApiOptions): Observable<T> {
    return this.httpClient.get<T>(this.getFullUrl(options), this.getHttpOptions(options))
      .pipe(map((resp => <T><any>resp)));
  }

  public post<T>(body: any, options: ApiOptions): Observable<T> {
    return this.httpClient.post<T>(this.getFullUrl(options), body, this.getHttpOptions(options))
      .pipe(
        map((resp => <T><any>resp))
      );
  }

  public put<T>(body: any, options: ApiOptions): Observable<T> {
    return this.httpClient.put<T>(this.getFullUrl(options), body, this.getHttpOptions(options))
      .pipe(map((resp => <T><any>resp)));
  }

  public delete(options: ApiOptions): Observable<boolean> {
    return this.httpClient.delete(this.getFullUrl(options), this.getHttpOptions(options))
      .pipe(map((_ => true)));
  }
}
