using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using miysing.Models;

namespace miysing.Controllers
{
    [Route("api/[controller]")]
    public class SongRecordController : BaseController
    {
        [HttpGet("[action]/{id}")]
        public IActionResult GetSongRecordBySongId(int id)
        {
            return Json(Db.SongRecord.GetAll().Where(x => x.SongId == id).ToList());
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody]SongRecord[] songRecords)
        {
            return Json(Db.SongRecord.AddRange(songRecords));
        }

        [HttpPut("[action]")]
        public IActionResult Update([FromBody]SongRecord songRecord)
        {
            return Json(Db.SongRecord.Update(songRecord));
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            return Json(Db.SongRecord.Remove(Db.SongRecord.Get(id)));
        }
    }
}