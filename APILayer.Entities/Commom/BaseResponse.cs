using System;
using System.Collections.Generic;
using System.Text;

namespace APILayer.Entities.Commom
{
    public class BaseResponse
    {
        public string StatusCode { get; private set; }

        public string Body { get; private set; }

        public byte[] Data { get; private set; }
    }
}
