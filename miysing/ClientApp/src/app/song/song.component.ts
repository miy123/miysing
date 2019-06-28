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
  ngOnInit(): void {
  }
  songs: Song[];
  selectedSong: Song;
  createForm: FormGroup;

  displaySongs: Song[];
  searchParameter: string = '';

  get filterSongs(): Song[] {
    let result = this.songs;
    if (this.searchParameter) result = result.filter(x => x.name.includes(this.searchParameter) || (x.descrption ? x.descrption.includes(this.searchParameter) : false) || x.songRecords.some(y => y.listener.includes(this.searchParameter)));
    return result;
  }

  onSubmit(): void {
    console.log(this.createForm);
    if (this.createForm.valid === true) this.create(this.createForm.value);
  }
  //crud
  getData(): void {
    this.http.get<Song[]>('/api/Song/GetSongsList').subscribe(result => {
      this.songs = result;
    }, error => console.error(error));
  }
  create(form): void {
    this.http.post<Result>('/api/Song/Create', form).subscribe(result => {
      alert(result.message);
      this.getData();
      this.close();
    }, error => console.error(error));
  }
  save(song: Song): void {
    if (song.name && song.descrption) {
      this.http.put<Result>('/api/Song/Update', song).subscribe(result => {
        alert(result.message);
        song.editable = !result.success;
      }, error => console.error(error));
    } else alert('請輸入必填項.');
  }
  delete(song: Song): void {
    if (confirm('是否刪除？')) {
      this.http.delete<Result>('/api/Song/Delete/' + song.id).subscribe(result => {
        alert(result.message);
        this.getData();
      }, error => console.error(error));
    }
  }
  close() {
    document.getElementById('closeModal').click();
    this.createForm.reset();
  }
  onSelect(song: Song): void {
    this.selectedSong = song;
  }
  putDisplaySongs(data: Song[]) {
    this.displaySongs = data;
    this.selectedSong = null;
  }
  buildForm() {
    this.createForm = this.fb.group({
      name: new FormControl('', [
        Validators.required,
        //Validators.minLength(4)
      ]),
      descrption: new FormControl('', Validators.required)
    });
  }

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.buildForm();
    this.getData();
  }
}
