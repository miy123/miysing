using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace miysing.Models
{
    public class Song: BaseField
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Descrption { set; get; }  
        public virtual ICollection<SongRecord> SongRecords { set; get; }

        public Song()
        {
            this.SongRecords = new List<SongRecord>();
        }
    }
}
