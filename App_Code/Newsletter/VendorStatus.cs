using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newsletter
{
    public class VendorStatus
    {
        public const string STATUS_FAIL = "fail";
        public const string STATUS_SUCCESS = "success";

        public string Status
        {
            get;
            set;
        }
    }
}