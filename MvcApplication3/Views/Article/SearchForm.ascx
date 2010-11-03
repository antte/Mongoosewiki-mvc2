<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<form method="post" action="/Article/SearchResults/" id="SearchForm">
    <label for="q" style="display: none;">Search:</label>
    <input name="q" id="q" type="text" value="<%:ViewData["q"] %>" />
    <input type="submit" value="Search" />
</form>