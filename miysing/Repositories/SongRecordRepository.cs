using miysing.Models;
using miysing.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miysing.Repositories
{
    public class SongRecordRepository: Repository<SongRecord>, ISongRecordRepository
    {
        public SongRecordRepository(MiySongDbContext context) : base(context)
        {
        }
    }
}
