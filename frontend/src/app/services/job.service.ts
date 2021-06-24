import { BaseApiService } from './base-api/base-api.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiOptions } from './base-api/api-options.model';
import { JobModel } from '../models/job.model';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private baseApiService: BaseApiService) { }

  private createApiOptions(action?: String): ApiOptions {
    return <ApiOptions>
      {
        endpoint: 'jobs',
        action: action
      };
  }

  readAll(): Observable<Array<JobModel>> {
    return this.baseApiService.get<Array<JobModel>>(this.createApiOptions());
  }

  readById(id: string): Observable<JobModel> {
    return this.baseApiService.get<JobModel>(this.createApiOptions(id));
  }

  create(model: JobModel): Observable<JobModel> {
    return this.baseApiService.post<JobModel>(model, this.createApiOptions());
  }

  update(model: JobModel): Observable<JobModel> {
    return this.baseApiService.put<JobModel>(model, this.createApiOptions(model.id));
  }

  delete(id: string): Observable<boolean> {
    return this.baseApiService.delete(this.createApiOptions(id));
  }
}
