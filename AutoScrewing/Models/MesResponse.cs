using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Models
{
    public class MesResponse
    {
        public int code { get; set; }
        public string? message { get; set; }
        public object? data { get; set; }

        public MesResponse()
        {

        }
        public MesResponse(int code, string? message)
        {
            this.code = code;
            this.message = message;
            this.data = null;
        }
    }
}
