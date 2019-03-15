using eip.Models.Repositories;
using miysing.Models;
using miysing.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miysing.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiySongDbContext _context;

        public ISongRepository Song { get; private set; }
        
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
        }
    }
}
