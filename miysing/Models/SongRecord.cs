using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace miysing.Models
{
    public class SongRecord : BaseField
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [ForeignKey("Song")]
        public int SongId { set; get; }
        public DateTime Time { set; get; }
        public string Listener { set; get; }
        public string SongUrl { set; get; }

        public virtual Song Song { set; get; }
    }
}
