<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DinX.Common.Domain.Project>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DinX - <%= Html.Encode(Model.Name) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="pagetitle"><%= Html.Encode(Model.Name) %> Dashboard</h2>

    <fieldset>
        <legend>Info</legend>
        <div class="display-label">Name</div>
        <div class="display-field"><%= Html.Encode(Model.Name) %></div>
        <div class="display-label">Owner</div>
        <div class="display-field"><%= Html.Encode(Model.Owner.Username) %></div>
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { id= Model.Id }) %> |
        <%= Html.ActionLink("Show current sprint", "Index", "Sprint", new { id= Model.Id }, null) %> |
        <%= Html.ActionLink("Back to projects", "Index") %>
    </p>

</asp:Content>

