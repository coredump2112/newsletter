using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DataStore;
using Newsletter;

public partial class Controls_NewsletterStorefront : System.Web.UI.UserControl
{
    private bool isFormValid()
    {
        bool status;

        //  Assume false.
        status = false;

        if (emailFormatVal.IsValid && emailReqVal.IsValid && 
            campaignSelCntVal.IsValid)
        {
            status = true;
        }

        return status;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        NewsletterStorefront store;

        //  Initialize.
        store = null;

        if (!IsPostBack)
        {
            //  Use default constructor, we are only pulling info.
            store = new NewsletterStorefront();

            //  Pull active newsletter campaigns and populate checkbox list.
            campaignListCB.DataSource = store.GetNewsletterCatalog();
            campaignListCB.DataTextField = "Key";
            campaignListCB.DataValueField = "Value";
            campaignListCB.DataBind();
        }
    }

    protected void signupBtn_Click(object sender, EventArgs e)
    {
        //  Requirement:  Any newsletter that is currently hosted on iContact
        //  will include a subscription to City Connection automaticly. The two
        //  booleans are flags to indocate 1. If customer has subscribed to a 
        //  newsletter hosted by iContact. 2. If Glendale City Connections is
        //  already included in the subscription list.
        bool isCtyConnInc;  //  Is included City Connection in subscription list.
        bool isCtyConnSub;  //  Is City Connection already in subscription list.
        
        CustomerInfo customer;
        NewsletterStorefront store;
        short cityConnNewsID;
        short iContactVenID;
        StringBuilder summary;

        //  Initialize.
        isCtyConnInc = false;   //  Currently iContact newsletter is not subscribed to.
        isCtyConnSub = false;   //  Currently City Connectiuon is not subscribed to.
        customer = null;
        cityConnNewsID = Convert.ToInt16(ConfigurationManager.AppSettings["GlendaleConnectsNewsletterID"]);
        iContactVenID = Convert.ToInt16(ConfigurationManager.AppSettings["VendorIcontactID"]);
        store = null;
        summary = new StringBuilder();

        Page.Validate("NewsletterStoreVG");

        if (isFormValid())
        {
            //  Screen validation passed, build up customer info based on form
            //  provided information.
            customer = new CustomerInfo
            {
                Email = emailT.Text
            };

            //  Register customer with store.
            store = new NewsletterStorefront(customer);

            //  Iterate though the newsletter campaign optionss and add the 
            //  selected items to the shopping cart.
            for (int i = 0; i < campaignListCB.Items.Count; i++)
            {
                Campaign newsletter;

                //  Initialize.
                newsletter = null;

                //  Only add the newsletter if customer has selected it.
                if (campaignListCB.Items[i].Selected == true)
                {
                    //  Add slected newslwtter to cart.
                    try
                    {
                        newsletter = 
                            store.GetCampainInfo(Convert.ToInt16(campaignListCB.Items[i].Value));

                        //  Only subscribe if the newsletter is active.
                        if (newsletter.isActive)
                        {
                            store.Subscribe(newsletter);

                            //  Check if newsletter is hosted on iContact.
                            if (newsletter.VendorID == iContactVenID)
                            {
                                //  This newsletter is part of iContact,
                                //  include City Connect.
                                isCtyConnInc = true;
                            }

                            //  Check if this newsletter is Glendale City 
                            //  Connection.
                            if (newsletter.CampaignID == cityConnNewsID)
                            {
                                //  We've added Glendale City Connect to our
                                //  subscription list so flag it so we don't
                                //  add it twice.
                                isCtyConnSub = true;
                            }
                        }
                        else
                        {
                            summary.Append("<li>Unable to subscribe, " + 
                                newsletter.Name + " is no longer active.");
                        }
                    }
                    catch
                    {
                        summary.Append("<li>Unable to pull information on [" + campaignListCB.Items[i].Value + "].</li>");
                    }
                }
            }

            //  We have looked through user cart selection, lets make sure:
            //  1.  User has selected newsletter that is hosted on iContact.
            //  2.  Glendale City Connection is not already in the subscription 
            //      list.
            if (isCtyConnInc && !isCtyConnSub)
            {
                //  Customer has selected an iContact hosted newsletter but has
                //  not include Glendale City Connections. We will go ahead and
                //  add subscription to the cart before checkout.
                Campaign cityConnectNewsletter;

                cityConnectNewsletter = store.GetCampainInfo(cityConnNewsID);
                store.Subscribe(cityConnectNewsletter);
            }

            //  Subscribed to all selected newsletters, proceed to checkout.
            summary.Append(store.Checkout());
            summary.Append("</ul>");

            //  Output subscription/checkout summary and present to customer.
            summaryContext.Text = summary.ToString();
            NewsletterStoreViews.SetActiveView(SummaryView);
        }
    }

    protected void campaignSelCntVal_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = (campaignListCB.SelectedIndex > -1) ? true : false;
    }
}