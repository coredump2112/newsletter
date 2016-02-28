using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using DataStore;

namespace Newsletter
{
    /// <summary>
    /// NewsletterStorefrontBase class is the Creator abstract portion of the
    /// Factory Method Pattern.
    /// </summary>
    public abstract class NewsletterStorefrontBase
    {
        private List<INewsletterService> _svcCalls;

        protected void AddToCart(INewsletterService newsletterVendor)
        {
            _svcCalls.Add(newsletterVendor);
        }

        public abstract string Checkout();
        public abstract Campaign GetCampainInfo(short campaignID);
        public abstract Dictionary<string,string> GetNewsletterCatalog();

        protected void Initialize()
        {
            _svcCalls = new List<INewsletterService>();
        }

        protected string ProcessCheckout()
        {
            StringBuilder chkItemSummary;

            //  Initialize.
            chkItemSummary = new StringBuilder();

            //  Iterate through the selected newsletters and attempt call to
            //  newsletter's vendor and pass the customer information.
            foreach (INewsletterService newsLetterItem in _svcCalls)
            {
                HttpWebResponse vdrRsp;

                //  Submit customer information to vendor for this newsletter
                //  and capture vendor's response.
                vdrRsp = newsLetterItem.SubmitRequest(Customer);

                //  Summerize and capture vendor's response and add it to the
                //  overall summary response.
                chkItemSummary.Append(newsLetterItem.ProcessResponse(vdrRsp));
            }

            //  Return the overall summary response from all vendors.
            return chkItemSummary.ToString();
        }

        public abstract void Subscribe(Campaign newsletter);

        public abstract CustomerInfo Customer
        {
            get;
            set;
        }
    }
}