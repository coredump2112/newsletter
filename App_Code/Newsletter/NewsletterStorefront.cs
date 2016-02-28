using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web;
using DataStore;

namespace Newsletter
{
    /// <summary>
    /// NewsletterService class is the Concrete Creator portion of the Factory 
    /// Method Pattern.
    /// </summary>
    public class NewsletterStorefront : NewsletterStorefrontBase
    {
        private NewsletterEntities _ds;

        public NewsletterStorefront()
        {
            _ds = new NewsletterEntities();
            Initialize();
            Customer = new CustomerInfo();
        }

        public NewsletterStorefront(CustomerInfo customer)
        {
            _ds = new NewsletterEntities();
            Initialize();
            Customer = customer;
        }

        public override string Checkout()
        {
            string chkOutSummary;

            //  Initialize.
            chkOutSummary = "Newsletter subscription summary:<br /><ul>";

            //  Prorcess each item in the cart by registering with newsletter
            //  vendor and capture status for each item.
            chkOutSummary += ProcessCheckout();

            //  Close out the summary statement.
            chkOutSummary += "</ul>";

            return chkOutSummary;
        }

        public override Campaign GetCampainInfo(short campaignID)
        {
            Campaign cmpRec;

            //  Attempt to get the campaign information.
            cmpRec = (from c in _ds.Campaigns
                      where c.CampaignID == campaignID
                      select c).SingleOrDefault() ?? new Campaign
                      {
                          CampaignID = 0
                      };

            return cmpRec;
        }

        public override Dictionary<string, string> GetNewsletterCatalog()
        {
            Dictionary<string, string> registeredCampaigns;

            //  Get all registered news campaigns in order by name.
            registeredCampaigns = (Dictionary<string, string>)
                (from c in _ds.Campaigns
                 where c.isActive == true
                 orderby c.Name
                 select c).ToDictionary(c => c.Name, c => c.CampaignID.ToString());

            return registeredCampaigns;
        }

        public override void Subscribe(Campaign newsletter)
        {
            //  Determine the vendor for the subscribed newsletter.
            switch (newsletter.VendorID)
            {
                case 1:     //  iContact
                    
                    //  Build out iContact service object and add it to the
                    //  subscription list.
                    IcontactService iContact;
                    iContact = new IcontactService(newsletter);
                    AddToCart(iContact);
                    break;
                case 2:     //  MyNewsletterBuilder

                    MyNewsletterBuilder mnb;
                    mnb = new MyNewsletterBuilder(newsletter);
                    AddToCart(mnb);
                    break;
                default:    //  Unknown - No-op.
                    break;
            }
        }

        public override CustomerInfo Customer
        {
            get;
            set;
        }
    }
}