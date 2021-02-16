import { UserService } from './../../../../services/user.service';
import { PersistenceService } from './../../../../services/persistence.service';
import { MusicService } from './../../../../services/music.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Album from 'app/model/album.model';
import { forkJoin } from 'rxjs';
import Swal from 'sweetalert2';
import User from 'app/model/user.mode';
import FavoriteMusic from 'app/model/favorite-music.model';

@Component({
    selector: 'app-music-detail',
    templateUrl: './music-detail.component.html',
    styleUrls: ['./music-detail.component.scss'],
})
export class MusicDetailComponent implements OnInit {
    
    private albumId: string;
    album: Album;
    user: User;

    constructor(
        private service: MusicService, 
        private router: Router, 
        private route: ActivatedRoute,
        private persistence: PersistenceService,
        private userService: UserService) {}

    ngOnInit(): void {
        this.albumId = this.route.snapshot.paramMap.get('id');
        this.user = this.persistence.get('authenticate_user');	
        this.service.getAlbumDetail(this.albumId).subscribe(data => {
            this.album = data;
        });
    }

    getMusicDuration(value: number): string {
        const minutes: number = Math.floor(value / 60);
        return `${minutes.toString().padStart(2, "0")}: ${(value - minutes * 60).toString().padStart(2, "0")}`;
    }

    back(): void{
        this.router.navigate(['page', 'music']);
    }

    isFavoriteMusic(musicId) {
        return (this.user.favoriteMusics.findIndex((x) => x.musicId === musicId) !== -1);
    }

    toogleMusicFavorite(musicId){
        
        if (this.isFavoriteMusic(musicId) ===  false){
           this.userService.addMusicToFavorite(this.user.id, musicId).subscribe(data => {
                this.persistence.set('authenticate_user', data);
                this.user = data;
                Swal.fire(
                    'Sucesso!',
                    'Música adicionada aos favoritos',
                    'success'
                );
           });
        } else {
            this.userService.removeMusicToFavorite(this.user.id, musicId).subscribe(data => {
                this.persistence.set('authenticate_user', data);
                this.user = data;
                Swal.fire(
                    'Atenção!',
                    `Música removida dos favoritos`,
                    'warning'                    
                );
            });
        }
    }
}
