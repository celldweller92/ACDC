using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACDC.Models.Response
{
    public class Response<T>
    {
        public T data { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }
}
