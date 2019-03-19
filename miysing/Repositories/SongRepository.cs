﻿using miysing.Repositories.Interface;
using miysing.Models;
using System.Collections.Generic;
using System.Linq;

namespace miysing.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        private List<Song> _songs;

        public SongRepository(MiySongDbContext context) : base(context)
        {
        }

        public new IEnumerable<Song> GetAllList()
        {
            return this.Context.Songs.Select(x => new Song
            {
                CreateDate = x.CreateDate,
                Descrption = x.Descrption,
                Id = x.Id,
                Name = x.Name,
                UpdateDate = x.UpdateDate,
                SongRecords = x.SongRecords
            }).ToList();
        }
    }
}
