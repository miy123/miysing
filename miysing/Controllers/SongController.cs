using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using miysing.Repository;

namespace miysing.Controllers
{
    [Route("api/[controller]")]
    public class SongController : BaseController
    {
        private readonly ISongRepository _songRepository;

        public SongController(ISongRepository songRepository)
        {
            this._songRepository = songRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IEnumerable<Song> GetSongsList()
        {
            return this._songRepository.GetAllList();
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody]Song song)
        {
            return Json(this._songRepository.Add(song));
        }

        [HttpPut("[action]")]
        public IActionResult Update([FromBody]Song song)
        {
            return Json(this._songRepository.Update(song));
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            return Json(this._songRepository.Remove(this._songRepository.Get(id)));
        }
    }
}