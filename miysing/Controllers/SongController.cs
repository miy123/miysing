using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using miysing.Models;

namespace miysing.Controllers
{
    [Route("api/[controller]")]
    public class SongController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IEnumerable<Song> GetSongsList()
        {
            return Db.Song.GetAllList();
        }
    }
}