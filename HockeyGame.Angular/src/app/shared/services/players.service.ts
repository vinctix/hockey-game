import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Player } from '../models/player.model';

@Injectable({providedIn: 'root'})
export class PlayersService {

  private readonly baseUrl = environment.apiUrl + '/players';

  constructor(private http: HttpClient) { }
  
  createPlayer$(player: Player): Observable<Player> {
    return this.http.post<Player>(this.baseUrl, player);
  }

  setCaptain$(id: number): Observable<Player> {
    const url = this.baseUrl + '/' + id + '/captain';
    return this.http.put<Player>(url, {});
  }
}