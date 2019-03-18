import { Component , OnInit , Input } from '@angular/core';
import { Song } from '../../model/song';

@Component({
  selector: 'app-song-detail',
  templateUrl: './song-detail.component.html'
})
export class SongDetailComponent implements OnInit {
   @Input() song:Song ;

  constructor() {
  }

   ngOnInit() {
   }
}
