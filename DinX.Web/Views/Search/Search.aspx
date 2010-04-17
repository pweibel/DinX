<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DinX.Web.Models.SearchViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DinX - Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="pagetitle">Search results</h2>
    
    <ul>
    <% foreach (var result in this.Model.Results) { %> <li><%= result.ToString() %></li><%} %>
	</ul>
</asp:Content>
