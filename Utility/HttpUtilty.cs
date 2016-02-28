using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Utility
{

    /// <summary>
    /// Utility class that allows various actions against HTTP socket.
    /// </summary>
    public class HttpUtilty
    {
        public static int GET_BUFFER_MAX = 2048;

        public static HttpWebResponse TransmitGetRequest(string BaseURL, 
            Dictionary<string, string> NameValuePairs)
        {
            HttpWebRequest req;
            HttpWebResponse rsp;
            string amp; //  Get pair separator.
            string getParam;
            string getURL;

            //  Initialize.
            req = null;
            rsp = null;
            amp = string.Empty;  // Leading pair has no ampersand.
            getParam = string.Empty;
            getURL = BaseURL + "?";

            //  Build out get parameters and encode it.
            foreach(KeyValuePair<string, string> getPair in NameValuePairs)
            {
                //  Put in ampersand separator, except for the first time.
                getParam += amp;
                amp = "&";

                //  Add GET query key from pair.
                getParam += getPair.Key + "=";

                //  Add GET encoded value key from pair.
                getParam += HttpContext.Current.Server.UrlEncode(getPair.Value);
            }

            //  Build out GET web request with encoded query string.
            //  Make sure the full GET URL is within GET buffer limitation.
            getURL += getParam;
            getURL = (getURL.Length <= GET_BUFFER_MAX) ? getURL : getURL.Substring(0, GET_BUFFER_MAX);
            req = (HttpWebRequest)WebRequest.Create(getURL);
            req.Method = "GET";

            //  Invoke transmition and wait for response.
            try
            {
                rsp = (HttpWebResponse)req.GetResponse();
            }
            catch
            {
                rsp = null;
            }

            return rsp;
        }

        /// <summary>
        /// Supports various transmission types to destination URL on the HTTP 
        /// socket.
        /// </summary>
        /// <param name="SubmitURL">Destination URL to send data to.</param>
        /// <param name="ContentType">Specify the media content type.</param>
        /// <param name="ContentData">The actual data to transmit.</param>
        /// <returns>The host response from HTTP transmission.</returns>
        public static HttpWebResponse TransmitPostRequest(string SubmitURL,
            string ContentType, string ContentData)
        {
            ASCIIEncoding encoder;
            byte[] encodeSubmission;
            HttpWebRequest req;
            HttpWebResponse rsp;

            rsp = null;

            req = (HttpWebRequest)WebRequest.Create(SubmitURL);
            encoder = new ASCIIEncoding();
            encodeSubmission = encoder.GetBytes(ContentData);
            req.Method = "POST";
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
    }
}