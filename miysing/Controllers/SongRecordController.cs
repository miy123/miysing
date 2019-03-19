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
        [HttpPost("[action]")]
        public IActionResult Create([FromBody]SongRecord[] songRecords)
        {
            return Json(Db.SongRecord.AddRange(songRecords));
        }
    }
}