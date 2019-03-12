import { Component , OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Song } from '../model/song';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html'
})
export class SongComponent implements OnInit {
     songs:Song[] ;
     selectedSong:Song ;
     http:HttpClient;

     searchParameter:Song = {
       name:'',
       descrption: ''
     };

     get displaySongs():Song[] {
       let result = this.songs;
       if(this.searchParameter.name) result = result.filter(x=>x.name.includes(this.searchParameter.name));
       if(this.searchParameter.descrption) result = result.filter(x=>x.descrption.includes(this.searchParameter.descrption));
       return result;
     }

     onSelect(song: Song): void {
      this.selectedSong = song;
      console.log(this.selectedSong);
     }

     constructor(http: HttpClient) {
      http.get<Song[]>('/api/Song/GetSongsList').subscribe(result => {
       this.songs = result;
      }, error => console.error(error));
     }

     ngOnInit() {
     }
}
