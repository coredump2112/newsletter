using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Web;

using DataStore;

namespace Newsletter
{
    /// <summary>
    /// Summary description for MyNewsletterBuilder
    /// </summary>
    public class MyNewsletterBuilder : NewsletterServiceBase, INewsletterService
    {
        #region PropertyConstants

        private const string CAMPAIGN_CATEGORIES = "mnb_cats[]";
        private const string CAMPAIGN_CATEGORY_OVERRIDE = "mnb_cat_override";
        private const string CAMPAIGN_NLID = "mnb_nlid";
        private const string CAMPAIGN_NOTIFY = "mnb_notify";
        private const string CAMPAIGN_UID = "mnb_uid";

        #endregion

        public MyNewsletterBuilder(Campaign newsletter)
        {
            BuildServiceConfiguration(newsletter);
        }

        private string buildPostData()
        {
            StringBuilder postData;

            //  Initialize.
            postData = new StringBuilder();

            //  Append this servers properties key-value pairs to post data.
            postData.Append(VendorDefaultRedirectName + "=" +
                VendorDefaultRedirectValue);
            postData.Append("&" + VendorErrorRedirectName + "=" +
                VendorErrorRedirectValue);
            
            //  Append campaign configuration poperties key-value pairs to post
            //  data.
            postData.Append("&" + CAMPAIGN_UID + "=" + CampaignUid);
            postData.Append("&" + CAMPAIGN_CATEGORY_OVERRIDE + "=" + 
                CampaignCatOverride);
            postData.Append("&" + CAMPAIGN_NOTIFY + "=" + CampaignNotify);
            postData.Append("&" + CAMPAIGN_NLID + "=" + CampaignNlid);

            //  Append contact info from submitted form.
            postData.Append("&" + FieldCompanyuName + "=" + string.Empty);
            postData.Append("&" + FieldEmailPropertyName + "=" +
                Email);
            postData.Append("&" + FieldFirstNamePropertyName + "=" +
                FirstName);
            postData.Append("&" + FieldJobTitle + "=" + string.Empty);
            postData.Append("&" + FieldLastNamePropertyName + "=" +
                LastName);
            postData.Append("&" + FieldZipPropertyName + "=" + Zip);

            //  Add the final item, the newsletter category id.
            postData.Append("&" + CAMPAIGN_CATEGORIES + "=" + CampaignCats);

            return postData.ToString();
        }

        public string ProcessResponse(HttpWebResponse rsp)
        {
            return base.ProcessResponseImpl(rsp);
        }

        public HttpWebResponse SubmitRequest(CustomerInfo customer)
        {
            string postData;

            //  Prep customer inform for submission.
            UpdateCustomer(customer);

            //  Build out post data from content info.
            postData = buildPostData();

            //  Passed specific data to transmit to iContact.
            return TransmitRequest(VendorSubmitCall, VendorMethodType,
                VendorContentType, postData);
        }

        public string CampaignCatOverride
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_CATEGORY_OVERRIDE);
            }
        }

        public string CampaignCats
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_CATEGORIES);
            }
        }

        public string CampaignNlid
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_NLID);
            }
        }

        public string CampaignNotify
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_NOTIFY);
            }
        }

        public string CampaignUid
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_UID);
            }
        }

        public override string Email
        {
            get;
            set;
        }

        public override string FirstName
        {
            get;
            set;
        }

        public override string LastName
        {
            get;
            set;
        }

        public override string VendorContentType
        {
            get 
            {
                return GetPropertyValue(VENDOR_CONTENT_TYPE);
            }
        }

        public override string VendorDefaultRedirectName
        {
            get 
            { 
                return GetPropertyValue(VENDOR_DEFAULT_REDIRECT_NAME); 
            }
        }

        public override string VendorDefaultRedirectValue
        {
            get
            {
                return GetPropertyValue(VENDOR_DEFAULT_REDIRECT_VALUE);
            }
        }

        public override string VendorErrorRedirectName
        {
            get 
            { 
                return GetPropertyValue(VENDOR_ERROR_REDIRECT_NAME); 
            }
        }

        public override string VendorErrorRedirectValue
        {
            get
            {
                return GetPropertyValue(VENDOR_ERROR_REDIRECT_VALUE);
            }
        }

        public override string VendorMethodType
        {
            get 
            {
                return GetPropertyValue(VENDOR_METHOD_TYPE);
            }
        }

        public override string VendorSubmitCall
        {
            get
            {
                return GetPropertyValue(VENDOR_SUBMIT_CALL);
            }
        }

        public override string Zip
        {
            get;
            set;
        }
    }
}