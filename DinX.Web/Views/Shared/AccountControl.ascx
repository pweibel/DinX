<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        <%= Html.ActionLink("Dashboard", "Index", "User") %> | <%= Html.ActionLink("Manage Account", "Index", "Account") %> | <%= Html.ActionLink("Log Off", "LogOff", "Account") %> 
<%
    }
    else {
%> 
        <%= Html.ActionLink("Register", "Register", "Account") %> | <%= Html.ActionLink("Log On", "LogOn", "Account") %>
<%
    }
%>
