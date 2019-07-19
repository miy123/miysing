namespace miysing.Repository
{
    public class SongRecordRepository : Repository<SongRecord>, ISongRecordRepository
    {
        public SongRecordRepository(MiySongDbContext context) : base(context)
        {
        }
    }
}
