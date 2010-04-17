<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About DinX
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="pagetitle">About DinX</h2>
    <p>
        DinX is Scrum tool, based on the following technologies:
        <ul>
			<li>ASP.Net MVC</li>
			<li>JQuery</li>
			<li>NHibernate</li>
			<li>System.Data.Sqlite</li>
			<li>Lucene.Net</li>
			<li>NHibernate.Linq</li>
			<li>NHibernate.Search</li>
			<li>NUnit</li>
        </ul>
    </p>
</asp:Content>
