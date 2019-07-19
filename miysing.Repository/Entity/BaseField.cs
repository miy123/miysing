using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miysing.Repository
{
    public class BaseField
    {
        public DateTime CreateDate { set; get; } = DateTime.Now;
        public DateTime UpdateDate { set; get; } = DateTime.Now;
    }
}
