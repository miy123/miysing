using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miysing.Helper
{
    public class Result
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public string ExceptionString { get; set; }

        public object data { set; get; }

        public List<object> InnerResults { get; protected set; }

        public Result(bool _Success)
        {
            this.Success = _Success;
        }
    }

    public class Result<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public string ExceptionString { get; set; }

        public T data { set; get; }

        public List<object> InnerResults { get; protected set; }

        public Result(bool _Success)
        {
            this.Success = _Success;
        }
    }
}
