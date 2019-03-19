using miysing.Repositories;
using miysing.Repositories.Interface;

namespace miysing.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiySongDbContext _context;

        public ISongRepository Song { get; private set; }
        public ISongRecordRepository SongRecord { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public UnitOfWork(MiySongDbContext context)
        {
            _context = context;
            Song = new SongRepository(_context);
            SongRecord = new SongRecordRepository(_context);
        }
    }
}
