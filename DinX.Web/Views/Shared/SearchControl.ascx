<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<% using (Html.BeginForm("Search", "Search")) {%>
	<%= Html.TextBox("Query") %> <input type="submit" value="Search" />
<% } %>
