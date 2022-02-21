import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Team } from '../models/team.model';

@Injectable({providedIn: 'root'})
export class TeamsService {

  private readonly baseUrl = environment.apiUrl + '/teams';

  constructor(private http: HttpClient) { }
  
  getTeamByYear$(year: number): Observable<Team> {
    const url = this.baseUrl + '/' + year;
    return this.http.get<Team>(url);
  }
}