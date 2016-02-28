<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsletterStorefront.ascx.cs" Inherits="Controls_NewsletterStorefront" %>
<asp:MultiView ID="NewsletterStoreViews" runat="server" ActiveViewIndex="0">
    <asp:View ID="CatalogView" runat="server">
        <div>
            <asp:Label ID="emailL" runat="server" Text="Email: " AssociatedControlID="emailT"></asp:Label>
            <asp:RequiredFieldValidator ID="emailReqVal" runat="server" 
                ErrorMessage="Email address is required." ControlToValidate="emailT" 
                ValidationGroup="NewsletterStoreVG" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="emailFormatVal" runat="server" 
                ErrorMessage="Invalid email address." ControlToValidate="emailT" 
                Display="Dynamic" ValidationGroup="NewsletterStoreVG"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
        <div class="form_submit">
            <asp:TextBox ID="emailT" Columns="40" runat="server"></asp:TextBox>
        </div>        
	    <div class="checkboxlist-container">
            <fieldset>
                <legend>Newsletters</legend>
                <asp:CustomValidator ID="campaignSelCntVal" runat="server" ValidationGroup="NewsletterStoreVG"
                    ErrorMessage="Please select at least one newsletter." Display="Dynamic" 
                    onservervalidate="campaignSelCntVal_ServerValidate" ForeColor="Red"></asp:CustomValidator><br />
                <asp:CheckBoxList ID="campaignListCB" runat="server" RepeatColumns="2">
                </asp:CheckBoxList>
            </fieldset>
        </div>
        <asp:Button ID="signupBtn" runat="server" Text="Signup" onclick="signupBtn_Click" />
    </asp:View>
    <asp:view id="SummaryView" runat="server">
        <asp:Literal ID="summaryContext" runat="server"></asp:Literal>
    </asp:view>
</asp:MultiView>