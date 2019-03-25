import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { Song, SongRecord } from '../../model/song';
import { Result } from '../../model/Result';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-song-detail',
  templateUrl: './song-detail.component.html'
})
export class SongDetailComponent implements OnInit {
  @Input() song: Song;

  createRaw: SongRecord[] = [];
  http: HttpClient;

  addRaw(): void {
    const newRecord = new SongRecord();
    newRecord.songId = this.song.id;
    this.createRaw.push(newRecord);
  }
  removeRaw(raw: SongRecord): void {
    let index = this.createRaw.indexOf(raw);
    this.createRaw.splice(index, 1);
  }
  saveRaw(): void {
    this.createRaw = this.createRaw.filter(x => x.time && x.listener);
    this.http.post<Result>('/api/SongRecord/Create', this.createRaw).subscribe(result => {
      alert(result.message);
      if (result.success) {
        this.createRaw = [];
        this.getRecord();
      }
    }, error => console.error(error));
  }

  getRecord(): void {
    this.http.get<SongRecord[]>('/api/SongRecord/GetSongRecordBySongId/' + this.song.id).subscribe(result => {
      this.song.songRecords = result;
    }, error => console.error(error));
  }
  update(songRecord: SongRecord): void {
    if (songRecord.time && songRecord.listener) {
      this.http.put<Result>('/api/SongRecord/Update', songRecord).subscribe(result => {
        alert(result.message);
        songRecord.editable = !result.success;
        if (result.success) this.getRecord();
      }, error => console.error(error));
    } else alert('請輸入必填項.');
  }
  delete(songRecord: SongRecord): void {
    if (confirm('是否刪除？')) {
      this.http.delete<Result>('/api/SongRecord/Delete/' + songRecord.id).subscribe(result => {
        alert(result.message);
        if (result.success) this.getRecord();
      }, error => console.error(error));
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes.song && (changes.song.previousValue && changes.song.currentValue && changes.song.currentValue.id != changes.song.previousValue.id)) {
      this.createRaw = [];
    }
  }

  constructor(http: HttpClient) {
    this.http = http;
  }

  ngOnInit() {
  }
}
