<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<% try
   { %>
<ul id="articleMenu">
    <li><a href="/Article/Details/<%:Model.Title %>">Details</a></li>
    <li><a href="/Article/Edit/<%:Model.Title %>">Edit</a></li>
</ul>
<% }
   catch (Exception)
   { %>
   <p>sdf</p>
<% } %>