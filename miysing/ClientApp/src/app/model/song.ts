export class Song {
  id: number;
  name: string;
  descrption: string;
  songRecords: SongRecord[];
  editable: boolean;
}

export class SongRecord {
  id: number;
  songId: number;
  time: string;
  listener: string;
  songUrl: string;
  editable: boolean;
}
