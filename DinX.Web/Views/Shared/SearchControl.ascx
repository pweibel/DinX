<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%= Html.TextBox("SearchString") %> <%= Html.ActionLink("Search", "Search", "Search") %>