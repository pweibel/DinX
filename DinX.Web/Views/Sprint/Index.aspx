<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DinX.Web.Models.SprintViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DinX - Current sprint
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="pagetitle">Current sprint of <%= this.Model.Project.Name %></h2>

    <%= Html.ActionLink("Go back to project", "Show", "Project", new { id = this.Model.Project.Id }, null) %>

</asp:Content>
