using System;
using System.Collections.Generic;
using System.Text;

namespace APILayer.Entities.Commom
{
    public class BaseRequest
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string Order { get; set; }

        public string Sort { get; set; }

        public string Min { get; set; }

        public string Max { get; set; }
    }
}
