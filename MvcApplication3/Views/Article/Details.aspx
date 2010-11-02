<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication3.Models.Article>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%: Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% Html.RenderPartial("ArticleMenu"); %>
    
    <% Html.RenderPartial("SearchForm"); %>

    <h2><%: Model.Title %></h2>

    <p><%= Model.getBodyToHTML() %></p>

</asp:Content>
