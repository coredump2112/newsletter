using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Utility
{
    /// <summary>
    /// Encapsulates email generation based on an XHTML template file. 
    /// Span elements with an 'id' attribute are replaced with current application values stored in ReplacementValue collection.
    /// Img elements are updated to allow image content to be attached to email as MIME components.
    /// </summary>
    public class EmailFromTemplate
    {
        private String templatePath; // typically, just the name of the XHTML file (img elements are evaluated relative to the location of the ASPX page that is instantiating the object)
        private MailAddressCollection toAddresses = new MailAddressCollection(); // To
        private MailAddressCollection ccAddresses = new MailAddressCollection(); // CC
        private MailAddressCollection bccAddresses = new MailAddressCollection(); // BCC
        private String subject; // the subject of the email
        private Dictionary<String, String> replacementValue = new Dictionary<String, String>(); // the set of replacement values, keyed by the target ID (provided by developer using the AddReplacementValue method)
        private Dictionary<String, String> replacementImage = new Dictionary<String, String>(); // the set of img src url's that will be attached to the resulting email (created automatically during the SendMessage method execution)

        /// <summary>
        /// </summary>
        /// <param name="TemplatePath">Name of template file. Ideally, located in the same folder as the page that instantiated EmailFromTemplate.</param>
        /// <param name="Subject">Subject header of email</param>
        /// <param name="ToAddress">A single "To" Address (additional addresses can be added to the TO collection)</param>
        public EmailFromTemplate(String TemplatePath, String Subject, MailAddress ToAddress)
        {
            templatePath = TemplatePath;
            toAddresses.Add(ToAddress);
            subject = Subject;
        }

        /*
        /// <summary>
        /// Adds replacement values that will be substituted for the <span id="..." /> elements
        /// </summary>
        /// <param name="ID">ID of the span element that will be replaced.</param>
        /// <param name="Value">Text that will fill the span element</param>
        public void AddReplacementValue(String ID, String Value)
        {
            replacementValue.Add(ID, Value);
        }
        */

        /// <summary>
        /// Collection of replacement values. 
        /// Each key/value pair will be applied to the template to fill in spans where id=key.
        /// </summary>
        public Dictionary<String, String> ReplacementValue
        {
            get
            {
                return replacementValue;
            }
            set
            {
                replacementValue = value;
            }
        }

        /// <summary>
        /// Collection of TO addresses
        /// </summary>
        public MailAddressCollection TO
        {
            get
            {
                return toAddresses;
            }
            set
            {
                toAddresses = value;
            }
        }

        /// <summary>
        /// Collection of CC addresses
        /// </summary>
        public MailAddressCollection CC
        {
            get
            {
                return ccAddresses;
            }
            set
            {
                ccAddresses = value;
            }
        }

        /// <summary>
        /// Collection of BCC addresses
        /// </summary>
        public MailAddressCollection BCC
        {
            get
            {
                return bccAddresses;
            }
            set
            {
                bccAddresses = value;
            }
        }

        /// <summary>
        /// Generates and sends the email based on the current class properties.
        /// </summary>
        public void SendMessage()
        {
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.XmlResolver = null;
            readerSettings.ProhibitDtd = false;
            XmlReader reader = XmlReader.Create(new StreamReader(HttpContext.Current.Server.MapPath(templatePath)), readerSettings);

            XmlNamespaceManager resolver = new XmlNamespaceManager(reader.NameTable);
            XDocument emailResponseDocument = XDocument.Load(reader);
            MailMessage message = new MailMessage(new MailAddress("noreply@glendaleca.gov"), toAddresses[0]);
            SmtpClient SMTP = new SmtpClient(); // delivery method defined in web.config

            reader.Close();

            // templates assumed to have xhtml namespace
            // in order to use XPATH methods, an explicate prefix to the namespace must be defined here
            // the typical prefix is "xhtml" but any prefix could be used
            resolver.AddNamespace("xhtml", "http://www.w3.org/1999/xhtml");

            // iterate replacementValue collection (populated by developer calls to AddReplacementValue method)
            // locate <span> elements with coresponding id attribtute and replace innerText of span with value
            foreach (String key in replacementValue.Keys)
            {
                XElement thisElement = emailResponseDocument.XPathSelectElement("//xhtml:span[@id='" + key + "']", resolver);
                if (thisElement != null)
                {
                    thisElement.Value = replacementValue[key];
                }
            }

            // iterate all img elements in template
            // gererate a new unique CID value for each img URL
            // save CID and URL in replacementImage collection
            // change img src attribute to "cid:uniquevalue" pattern
            foreach (XElement thisElement in emailResponseDocument.XPathSelectElements("//xhtml:img", resolver))
            {
                String ContentID = "image" + replacementImage.Count.ToString();
                replacementImage.Add(ContentID, thisElement.Attribute("src").Value);
                thisElement.Attribute("src").Value = "cid:" + ContentID;
            }

            // now that template's XHTML has been modified appropriately, store it as an AlternateView in the email message
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(emailResponseDocument.ToString(SaveOptions.None), new System.Net.Mime.ContentType("text/html"));

            // iterate replacementImage collection (created in previous foreach loop)
            // load image data as linked resource for alternateView and assign it the CID created in previous foreach loop
            foreach (String key in replacementImage.Keys)
            {
                LinkedResource linkedResource = new LinkedResource(HttpContext.Current.Server.MapPath(replacementImage[key]));
                linkedResource.ContentId = key;
                alternateView.LinkedResources.Add(linkedResource);
            }
            message.AlternateViews.Add(alternateView);
            message.Subject = subject;
            message.IsBodyHtml = true;
            // if we got more than one address (the first was already added in the constructor) add them to the "To" list
            for (int index = 1; index < toAddresses.Count; index++)
                message.To.Add(toAddresses[index]);
            // set CC address(s)
            for (int index = 0; index < ccAddresses.Count; index++)
                message.CC.Add(ccAddresses[index]);
            // set BCC address(s)
            for (int index = 0; index < bccAddresses.Count; index++)
                message.Bcc.Add(bccAddresses[index]);
            SMTP.Send(message);
        }
    }
}