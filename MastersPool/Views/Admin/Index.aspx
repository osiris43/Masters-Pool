<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AdminViewModel>" %>
<%@ Import Namespace="MastersPool.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>
<asp:Content ID="GolfStyle" ContentPlaceHolderID="golfercss" runat="server">
    <link href="../../Content/GolferSections.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_12">
        <div class="grid_12" id="headerText">
            <h2>
                The Admin Page</h2>
            <asp:Label ID="MessageLabel" runat="server"><%=Html.Encode(Model.Message) %></asp:Label>
        </div>
        <div class="clear"></div>
        <div class="grid_12">
        <asp:Label ID="Label1" runat="server" Text="Current Year" />
        <asp:Label ID="Label2" runat="server"><%= Html.Encode(Model.CurrentYear) %></asp:Label>
        <%=Html.ActionLink("Convert", "ConvertYear") %> <br /><br />
        </div>
        
        <div class="clear"></div>
        <div class="grid_3 listColumn" >
            <% Html.RenderPartial("GolferSection", Model.GolferSections[0]); %>
        </div>
        <div class="grid_3 listColumn" id="col_2">
            <% Html.RenderPartial("GolferSection", Model.GolferSections[1]); %>
            <% Html.RenderPartial("GolferSection", Model.GolferSections[2]); %>
            <% Html.RenderPartial("GolferSection", Model.GolferSections[3]); %>
        </div>
        <div class="grid_3 listColumn">
            <% Html.RenderPartial("GolferSection", Model.GolferSections[4]); %>
            <% Html.RenderPartial("GolferSection", Model.GolferSections[5]); %>
            <% Html.RenderPartial("GolferSection", Model.GolferSections[6]); %>
        </div>
        <div class="clear"></div>
        
    </div>
</asp:Content>
