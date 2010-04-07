<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProjectViewModel>" %>
<%@ Import Namespace="DinX.Common.Domain"%>
<%@ Import Namespace="DinX.Web.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DinX - Projects
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="pagetitle">Projects</h2>
    <%= Html.ActionLink("New Project", "Create", "Project")%>
    <ul>
    <% foreach(Project project in this.Model.Projects){%>
        <li><%= Html.ActionLink(project.Name, "Show", new { id = project.Id}) %></li>
    <% } %>
    </ul>
</asp:Content>
