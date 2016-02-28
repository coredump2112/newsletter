<%@ Page Title="" Language="C#" MasterPageFile="~/Vision/VisionInternet.master" AutoEventWireup="true" CodeFile="NewsletterStorefront.aspx.cs" Inherits="FrameViews_NewsletterStorefront" %>
<%@ Register Src="~/Controls/NewsletterStorefront.ascx" TagName="NewsletterStore" TagPrefix="uc1" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="StorefrontContent" ContentPlaceHolderID="content" Runat="Server">
    <uc1:NewsletterStore ID="newsletterStore" runat="server" />
</asp:Content>