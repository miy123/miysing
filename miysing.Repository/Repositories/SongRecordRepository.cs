using System;

namespace miysing.Repository
{
    public class SongRecordRepository : Repository<SongRecord>, ISongRecordRepository
    {
        public SongRecordRepository(MiySongDbContext context) : base(context)
        {
            this.DbChangeHandle += (object sender, EventArgs e) =>
            {

            };
        }
    }
}
