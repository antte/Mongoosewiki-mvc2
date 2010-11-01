<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<form method="post" action="/Article/SearchResults/">
    <label for="q" style="display: none;">Search:</label>
    <input name="q" type="text" value="<%:ViewData["q"] %>" />
    <input type="submit" value="Search" />
</form>