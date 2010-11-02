<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SearchResults
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SearchResults</h2>

    <% Html.RenderPartial("SearchForm", ViewData); %>

    <%if (((List<MvcApplication3.Models.Article>)ViewData["articles"]).Count == 0)
      {%>
      <h2>Inga resultat</h2>
    <% } %>

    <ul id="searchResults">
    <% foreach (MvcApplication3.Models.Article article in (List<MvcApplication3.Models.Article>)ViewData["articles"])
       { %>
        <li>
            <h3><a href="/Article/Details/<%:article.Title %>"><%:article.Title %></a></h3>
            <p><%=article.Body %></p>
        </li>
    <% } %>
    </ul>

</asp:Content>
