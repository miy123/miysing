export class Song {
  id: number
  name: string
  descrption: string
  songRecord: SongRecord[]
  editable: boolean = false
}

export class SongRecord {
  id: number
  songId: number
  time: string
  listener: string
  songUrl: string
}
