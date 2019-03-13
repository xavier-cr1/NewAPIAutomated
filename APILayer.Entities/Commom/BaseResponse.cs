using System;
using System.Collections.Generic;
using System.Text;

namespace APILayer.Entities.Commom
{
    public class BaseResponse
    {
        public string StatusCode { get; set; }

        public string Body { get; set; }

        public byte[] Data { get; set; }
    }
}
