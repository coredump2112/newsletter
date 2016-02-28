using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web;
using DataStore;

namespace Newsletter
{
    /// <summary>
    /// INewsletterService is the Product interface part of the Factory Method
    /// Pattern for creating service objects.
    /// </summary>
    public interface INewsletterService
    {
        string ProcessResponse(HttpWebResponse rsp);
        HttpWebResponse SubmitRequest(CustomerInfo customer);
    }
}