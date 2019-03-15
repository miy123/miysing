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

        [HttpPost("[action]")]
        public IActionResult Create([FromBody]Song song)
        {
            return Json(Db.Song.Add(song));
        }

        [HttpPut("[action]")]
        public IActionResult Update([FromBody]Song song)
        {
            return Json(Db.Song.Update(song));
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            return Json(Db.Song.Remove(Db.Song.Get(id)));
        }
    }
}