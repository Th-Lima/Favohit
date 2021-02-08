import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import Music from 'app/model/music.model.ts';
import Album from 'app/model/album.model';

@Injectable({
  providedIn: 'root'
})

export class MusicService {

  constructor(private http: HttpClient) { }

  public getAlbuns(): Observable<Album[]>{
    return this.http.get<Album[]>(`${environment.baseUrl}album`);
  }

  public getAlbumDetail(id): Observable<Album>{
      return this.http.get<Album>(
          `${environment.baseUrl}album/${id}`
      );
  }

  public getAllMusicsByAlbumId(albumId): Observable<Music[]>{
    return this.http.get<Music[]>(
        `${environment.baseUrl}album/${albumId}/music`
    );
  }

}
