using miysing.Repositories.Interface;
using miysing.ViewModels;
using miysing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eip.Models.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        private List<Song> _songs;

        public SongRepository(MiySongDbContext context) : base(context)
        {
        }
    }
}
