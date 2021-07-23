using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string message { get; set; }
        public int Code { get; set; }
    }
    public class ResponseLog
    {
        public string Message { get; set; }
        public string Result { get; set; }
    }
}
