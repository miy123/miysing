using System.Linq;
using Microsoft.AspNetCore.Mvc;
using miysing.Repository;

namespace miysing.Controllers
{
    [Route("api/[controller]")]
    public class SongRecordController : BaseController
    {
        private readonly ISongRecordRepository _songRecordRepository;

        public SongRecordController(ISongRecordRepository songRecordRepository)
        {
            this._songRecordRepository = songRecordRepository;
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetSongRecordBySongId(int id)
        {
            return Json(this._songRecordRepository.GetAll().Where(x => x.SongId == id).ToList());
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody]SongRecord[] songRecords)
        {
            return Json(this._songRecordRepository.AddRange(songRecords));
        }

        [HttpPut("[action]")]
        public IActionResult Update([FromBody]SongRecord songRecord)
        {
            return Json(this._songRecordRepository.Update(songRecord));
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            return Json(this._songRecordRepository.Remove(this._songRecordRepository.Get(id)));
        }
    }
}