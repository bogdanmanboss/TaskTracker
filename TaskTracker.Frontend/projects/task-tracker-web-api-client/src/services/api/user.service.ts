import { Injectable } from '@angular/core';
import { TaskTrackerApiModule } from '../../lib/task-tracker-web-api-client.module';
import { ApiService } from '../api.service';


@Injectable({
  providedIn: 'root'
})
export class UserService {

    constructor(private apiService: ApiService) { }

    async getMany(externalId: string): Promise<TaskTrackerApiModule.User[]> {
        return this.apiService.getClient().userGetMany()
      }
}