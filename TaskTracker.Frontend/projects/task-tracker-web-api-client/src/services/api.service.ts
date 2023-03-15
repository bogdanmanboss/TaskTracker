import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../environments/environment'
import { TaskTrackerApiModule } from '../lib/task-tracker-web-api-client.module';
import { IConfig } from '../lib/authorized-api-base';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(
    private router: Router
  ) { }

  getClient(): TaskTrackerApiModule.TaskTrackerApiClient {
    return new TaskTrackerApiModule.TaskTrackerApiClient(
      <IConfig>{
        router: this.router
      },
      environment.apiUrl
    );
  }
}
