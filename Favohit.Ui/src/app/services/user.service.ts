import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import SignIn from './payload/SignIn';
import User from 'app/model/user.mode';
import Register from './payload/register';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient) { }

  public authenticate(payload: SignIn): Observable<User> {
    return this.http.post<User>(
        `${environment.baseUrl}user/autheticate`, payload
    );
  }

  public register(payload: Register): Observable<User>{
    return this.http.post<User>(
        `${environment.baseUrl}user/register`, payload
    );
  }

  public addMusicToFavorite(userId, musicId): Observable<User>{
      return this.http.post<User>(
          `${environment.baseUrl}user/${userId}/favorite-music/${musicId}`, null
      );
  }

  public removeMusicToFavorite(userId, musicId): Observable<User>{
    return this.http.delete<User>(
        `${environment.baseUrl}user/${userId}/favorite-music/${musicId}`
    );
}
}
