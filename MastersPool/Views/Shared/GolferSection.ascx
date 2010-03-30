<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MastersPool.Models.GolferSectionViewModel>" %>
<%@ Import Namespace="MastersPool.Core" %>
<div class="golfersGroupBox">
    <div class="golfersBoxHeader">
        <h3 class="golfersBoxName"><%=Html.Encode(Model.SectionHeader) %></h3>
    </div>
    <div class="golferBox">
        <ul class="golferList">
            <% foreach (Golfer golfer in Model.Golfers)
               { %>
                <% Html.RenderPartial("SingleGolfer", golfer); %>
            <% } %>
        </ul>
    </div>
</div>
