using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newsletter
{
    /// <summary>
    /// Summary description for CustomerInfo
    /// </summary>
    public class CustomerInfo
    {
        public CustomerInfo()
        {
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Zip = string.Empty;
        }

        public string Email
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Zip
        {
            get;
            set;
        }
    }
}