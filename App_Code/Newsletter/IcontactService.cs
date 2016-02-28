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
    /// IcontactService is a concrete product portion of a Factory Method 
    /// Pattern that implements the newsletter interface for vendor iContact.
    /// </summary>
    public class IcontactService : NewsletterServiceBase, INewsletterService
    {
        #region Property Constants

        private const Int16 ICONTACT_VENDOR_ID = 1;

        private const string CAMPAIGN_CLIENT_ID = "clientid";
        private const string CAMPAIGN_DOUBLE_OPT = "doubleopt";
        private const string CAMPAIGN_FORM_ID = "formid";
        private const string CAMPAIGN_LIST_ID = "listid";
        private const string CAMPAIGN_REAL_LIST_ID = "reallistid";
        private const string CAMPAIGN_SPECIAL_ID = "specialid";

        #endregion

        public IcontactService(Campaign newsletter)
        {
            BuildServiceConfiguration(newsletter);
        }

        private string buildPostData()
        {
            StringBuilder postData;

            //  Initialize.
            postData = new StringBuilder();

            //  Append this service properties key-value pairs to post data.
            postData.Append(VendorDefaultRedirectName + "="
                + VendorDefaultRedirectValue);
            postData.Append("&" + VendorErrorRedirectName + "=" +
                VendorErrorRedirectValue);

            //  Append contact info from submitted form.
            postData.Append("&" + FieldEmailPropertyName + "=" + Email);
            postData.Append("&" + FieldFirstNamePropertyName + "=" +
                FirstName);
            postData.Append("&" + FieldLastNamePropertyName + "=" +
                LastName);
            postData.Append("&" + FieldZipPropertyName + "=" + Zip);

            //  Resuming normal programing.
            postData.Append("&" + CAMPAIGN_LIST_ID + "=" + CampaignListID);

            //  SpecialID property key is unique for each newsletter because
            //  part of the key is derived from  the list id value.
            //  "specialid:"<ListID value>
            postData.Append("&" + CAMPAIGN_SPECIAL_ID + ":" + CampaignListID +
                "=" + CampaignSpecialID);

            postData.Append("&" + CAMPAIGN_CLIENT_ID + "=" + CampaignClientID);
            postData.Append("&" + CAMPAIGN_FORM_ID + "=" + CampaignFormID);
            postData.Append("&" + CAMPAIGN_REAL_LIST_ID + "=" +
                CampaignRealListID);
            postData.Append("&" + CAMPAIGN_DOUBLE_OPT + "=" + CampaignDoubleOpt);

            return postData.ToString();
        }

        public string ProcessResponse(HttpWebResponse rsp)
        {
            return ProcessResponseImpl(rsp);
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

        #region Properties

        public string CampaignClientID
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_CLIENT_ID);
            }
        }

        public string CampaignDoubleOpt
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_DOUBLE_OPT);
            }
        }

        public string CampaignFormID
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_FORM_ID);
            }
        }

        public string CampaignListID
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_LIST_ID);
            }
        }

        public string CampaignRealListID
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_REAL_LIST_ID);
            }
        }

        /// <summary>
        /// Gets SpecialID property value.  Note the property name starts with
        /// "specialid" appended with the value setting for property "listid".
        /// </summary>
        public string CampaignSpecialID
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_SPECIAL_ID + ":" + CampaignListID);
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

        public override string VendorContentType
        {
            get 
            {
                return GetPropertyValue(VENDOR_CONTENT_TYPE);
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

        #endregion
    }
}