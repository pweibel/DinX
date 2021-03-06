﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    DinX
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="pagetitle"><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about DinX visit the <%= Html.ActionLink("About", "About", "Home") %> page.
    </p>
</asp:Content>
