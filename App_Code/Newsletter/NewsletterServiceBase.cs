using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Xml.Linq;

using DataStore;

namespace Newsletter
{
    /// <summary>
    /// IContactServiceBase is not part of the Factory Method Pattern, however,
    /// this class provides a functional based for all concreate newsletter 
    /// service product.
    /// </summary>
    public abstract class NewsletterServiceBase
    {
        #region constants

        protected const string CAMPAIGN_ID = "CampaignID";
        protected const string CAMPAIGN_NAME = "CampaignName";
        protected const string FIELD_COMPANY_NAME = "FieldCompanyName";
        protected const string FIELD_EMAIL_PROPERTY_NAME = "FieldEmail";
        protected const string FIELD_FNAME_PROPERTY_NAME = "FieldFirstName";
        protected const string FIELD_JOB_TITLE = "FieldJobTitle";
        protected const string FIELD_LNAME_PROPERTY_NAME = "FieldLastName";
        protected const string FIELD_ZIP_PROPERTY_NAME = "FieldZip";
        protected const string VENDOR_CONTENT_TYPE = "ContentType";
        protected const string VENDOR_DEFAULT_REDIRECT_NAME = "DefaultRedirectName";
        protected const string VENDOR_DEFAULT_REDIRECT_VALUE = "DefaultRedirectValue";
        protected const string VENDOR_ERROR_REDIRECT_NAME = "ErrorRedirectName";
        protected const string VENDOR_ERROR_REDIRECT_VALUE = "ErrorRedirectValue";
        protected const string VENDOR_METHOD_TYPE = "MethodType";
        protected const string VENDOR_SUBMIT_CALL = "SubmitCall";

        #endregion

        #region internals

        private Dictionary<string, string> _propertyList;
        private NewsletterEntities _ds;

        #endregion

        protected void BuildServiceConfiguration(Campaign newsletter)
        {
            List<CampaignProperty> campaignProperties;
            List<VendorProperty> vendorProperties;

            //  Initialize and add key properties with default values.
            _propertyList = new Dictionary<string, string>();
            _ds = new NewsletterEntities();

            //  Add key campaign information 
            _propertyList.Add(CAMPAIGN_ID, newsletter.CampaignID.ToString());
            _propertyList.Add(CAMPAIGN_NAME, newsletter.Name);

            //  Get the vendor property settings for passed in newsletter campaign.
            vendorProperties = (from vp in _ds.VendorProperties
                                where vp.VendorID == newsletter.VendorID
                                select vp).ToList();

            //  Iterate through vendor properties and add to internal property 
            //  dictonary.
            foreach (VendorProperty vp in vendorProperties)
            {
                _propertyList.Add(vp.PropertyName, vp.PropertyValue);
            }

            //  Get the property settings for passed in newsletter campaign.
            campaignProperties = (from cp in _ds.CampaignProperties
                                  where cp.CampaignID == newsletter.CampaignID
                                  select cp).ToList();

            //  Iterate through campaign properties and add to internal 
            //  property dictonary.
            foreach (CampaignProperty cp in campaignProperties)
            {
                _propertyList.Add(cp.PropertyName, cp.PropertyValue);
            }
        }

        private bool checkVendorResponse(string vendorJsonResponse)
        {
            bool status;
            DataContractJsonSerializer jsonSer;
            MemoryStream rspStream;
            VendorStatus vStatus;

            //  Initialize.
            jsonSer = new DataContractJsonSerializer(typeof(VendorStatus));
            rspStream = 
                new MemoryStream(Encoding.UTF8.GetBytes(vendorJsonResponse));
            vStatus = (VendorStatus) jsonSer.ReadObject(rspStream);

            //  Assume we will fail.
            status = false;

            if (vStatus.Status == VendorStatus.STATUS_SUCCESS)
            {
                status = true;
            }

            return status;
        }

        protected string GetPropertyValue(string key)
        {
            string valStr;

            //  Initialize.
            valStr = string.Empty;

            //  Attempt to lookup the key value.
            try
            {
                valStr = _propertyList[key];
            }
            catch
            {
                //  Key does not exist, just return an empty string.
                valStr = string.Empty;
            }

            return valStr;
        }

        protected string ProcessResponseImpl(HttpWebResponse rsp)
        {
            Encoding enc;
            StreamReader rspStream;
            string rspString;
            StringBuilder submtRsp;

            //  Initialize.
            enc = null;
            rspStream = null;
            submtRsp = new StringBuilder();

            //  Start the response for this newsletter submission.
            submtRsp.Append("<li>");
            submtRsp.Append(CampaignName);
            submtRsp.Append(": [");

            //  Check iContact web service response.
            if (rsp.StatusCode == HttpStatusCode.OK)
            {
                //  iContact has received the request, start process application response.
                enc = Encoding.GetEncoding("utf-8");
                rspStream = new StreamReader(rsp.GetResponseStream(), enc);
                rspString = rspStream.ReadToEnd();

                //  Check if iContact sucessfully processed the request.
                if (checkVendorResponse(rspString))
                {
                    //  Everything went okay.
                    submtRsp.Append("Subscription successful.");
                }
                else
                {
                    //  iContact had a problem processing the request.
                    submtRsp.Append("Subscription failed.");
                }
            }
            else
            {
                //  Something went wrong with the web submission to iContact.
                submtRsp.Append("Connection to vendor failed.");
            }

            //  Close the list item tag before returning to caller.
            submtRsp.Append("]</li>");

            return submtRsp.ToString();
        }

        protected HttpWebResponse TransmitRequest(string SubmitURL,
            string MethodType, string ContentType, string ContentData)
        {
            ASCIIEncoding encoder;
            byte[] encodeSubmission;
            HttpWebRequest req;
            HttpWebResponse rsp;

            rsp = null;

            //  Prep connection to vendor's signup process.
            req = (HttpWebRequest)WebRequest.Create(SubmitURL);
            //rsp = (HttpWebResponse)req.GetResponse();
            encoder = new ASCIIEncoding();
            encodeSubmission = encoder.GetBytes(ContentData);
            req.Method = MethodType;
            req.ContentType = ContentType;
            req.ContentLength = encodeSubmission.Length;

            //  Invoke submission of content to vendor.
            using (Stream s = req.GetRequestStream())
            {
                s.Write(encodeSubmission, 0, encodeSubmission.Length);
                s.Close();
            }

            //  Attempt to capture vendor's response.
            try
            {
                rsp = req.GetResponse() as HttpWebResponse;
            }
            catch
            {
                rsp = null;
            }

            return rsp;
        }

        protected void UpdateCustomer(CustomerInfo customer)
        {
            Email = customer.Email;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Zip = customer.Zip;
        }

        #region Properties

        public string CampaignID
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_ID);
            }
        }

        public string CampaignName
        {
            get
            {
                return GetPropertyValue(CAMPAIGN_NAME);
            }
        }

        public abstract string Email
        {
            get;
            set;
        }

        protected string FieldCompanyuName
        {
            get
            {
                return GetPropertyValue(FIELD_COMPANY_NAME);
            }
        }

        protected string FieldEmailPropertyName
        {
            get
            {
                return GetPropertyValue(FIELD_EMAIL_PROPERTY_NAME);
            }
        }

        protected string FieldFirstNamePropertyName
        {
            get
            {
                return GetPropertyValue(FIELD_FNAME_PROPERTY_NAME);
            }
        }

        protected string FieldJobTitle
        {
            get
            {
                return GetPropertyValue(FIELD_JOB_TITLE);
            }
        }

        protected string FieldLastNamePropertyName
        {
            get
            {
                return GetPropertyValue(FIELD_LNAME_PROPERTY_NAME);
            }
        }

        protected string FieldZipPropertyName
        {
            get
            {
                return GetPropertyValue(FIELD_ZIP_PROPERTY_NAME);
            }
        }

        public abstract string FirstName
        {
            get;
            set;
        }

        public abstract string LastName
        {
            get;
            set;
        }

        public abstract string VendorContentType
        {
            get;
        }

        public abstract string VendorDefaultRedirectName
        {
            get;
        }

        public abstract string VendorDefaultRedirectValue
        {
            get;
        }

        public abstract string VendorErrorRedirectName
        {
            get;
        }

        public abstract string VendorErrorRedirectValue
        {
            get;
        }

        public abstract string VendorMethodType
        {
            get;
        }

        public abstract string VendorSubmitCall
        {
            get;
        }

        public abstract string Zip
        {
            get;
            set;
        }

        #endregion
    }
}