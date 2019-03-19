import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { Song, SongRecord } from '../../model/song';
import { Result } from '../../model/Result';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-song-detail',
  templateUrl: './song-detail.component.html'
})
export class SongDetailComponent implements OnInit {
   @Input() song:Song ;

  createRaw: SongRecord[] = [];
  http: HttpClient;

  addRaw() {
    const newRecord = new SongRecord();
    newRecord.songId = this.song.id;
    this.createRaw.push(newRecord);
  }
  removeRaw(raw: SongRecord) {
    let index = this.createRaw.indexOf(raw);
    this.createRaw.splice(index,1);
  }
  saveRaw() {
    this.http.post<Result>('/api/SongRecord/Create', this.createRaw).subscribe(result => {
      alert(result.message);
      if (result.success) this.createRaw = [];
    }, error => console.error(error));
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes.song && (changes.song.previousValue && changes.song.currentValue.id != changes.song.previousValue.id)) {
      this.createRaw = [];
    }
  }

  constructor(http: HttpClient) {
    this.http = http;
  }

   ngOnInit() {
   }
}
