import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Song, SongRecord } from '../model/song';
import { Result } from '../model/Result';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html'
})
export class SongComponent implements OnInit {
  songs: Song[];
  selectedSong: Song;
  http: HttpClient;
  createForm: FormGroup;

  newSong: Song = new Song();
  displaySongs: Song[];
  searchParameter: string = '';

  get filterSongs(): Song[] {
    let result = this.songs;
    if (this.searchParameter) result = result.filter(x => x.name.includes(this.searchParameter) || x.descrption.includes(this.searchParameter) || x.songRecords.some(y => y.listener.includes(this.searchParameter)));
    return result;
  }

  submitForm(form: Song): void {
    console.log('Form Data: ');
    console.log(form.descrption);
    console.log(form.name);
  }
  //crud
  getData(): void {
    this.http.get<Song[]>('/api/Song/GetSongsList').subscribe(result => {
      this.songs = result;
    }, error => console.error(error));
  }
  create(): void {
    this.http.post<Result>('/api/Song/Create', this.newSong).subscribe(result => {
      alert(result.message);
      this.newSong = new Song();
      this.getData();
      document.getElementById('closeModal').click();
    }, error => console.error(error));
  }
  save(song: Song): void {
    this.http.put<Result>('/api/Song/Update', song).subscribe(result => {
      alert(result.message);
      song.editable = !result.success;
    }, error => console.error(error));
  }
  delete(song: Song): void {
    if (confirm('是否刪除？')) {
      this.http.delete<Result>('/api/Song/Delete/' + song.id).subscribe(result => {
        alert(result.message);
        this.getData();
      }, error => console.error(error));
    }
  }
  
  onSelect(song: Song): void {
    this.selectedSong = song;
  }

  putDisplaySongs(data: Song[]) {
    this.displaySongs = data;
    this.selectedSong = null;
  }

  constructor(http: HttpClient) {
    this.http = http;
    this.getData();
  }

  ngOnInit() {
    this.createForm = new FormGroup({
      'name': new FormControl(this.newSong.name, [
        Validators.required,
        Validators.minLength(4)
      ]),
      'descrption': new FormControl(this.newSong.descrption, Validators.required)
    });
  }
}
