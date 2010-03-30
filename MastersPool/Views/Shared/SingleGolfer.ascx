<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MastersPool.Core.Golfer>" %>
<li id="golfer_<%=Model.Id %>" class="golferRow">
    <span class="golferName"><%=Html.Encode(Model.DisplayName) %></span>
</li>

