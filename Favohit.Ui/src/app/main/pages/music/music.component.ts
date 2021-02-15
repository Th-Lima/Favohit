import { Router } from '@angular/router';
import { MusicService } from './../../../services/music.service';
import { Component, OnInit } from '@angular/core';
import Album from 'app/model/album.model';

@Component({
    selector: 'app-music',
    templateUrl: './music.component.html',
    styleUrls: ['./music.component.scss'],
})
export class MusicComponent implements OnInit {      
    albuns: Album[];

    constructor(private service: MusicService, private router: Router) {}
    
    ngOnInit(): void{
        this.service.getAlbuns().subscribe((data) => {
            this.albuns = data;
        });
    }

    detail(album: Album){
        this.router.navigate(['page', 'music', album.id]);
    }
}
