﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Artifact.aspx.cs" Inherits="WebPages_Artifact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>Artifact Submitted </h3>
    <div style="width: 100%; height: 500px; margin: 5px 5px 5px 5px">

        <iframe runat="server" id="i_wiki" src="" style="width: 100%; height: 100%;"></iframe>
    </div>
    <hr />
    <div id="div_reviews" style="margin-top: 50px">
        <div style="visibility:hidden">
        <h3>Reviews</h3> (refresh the page to receive review status) <br />
        Each review element is divided into three lines: Question, Score, and Answer. One or more of these elements can be absent, which means, either it was not provided or was not necessary.<br />
        -1 for Score means no score was provided.<br /></div>
        <asp:ListView runat="server" ID="lv_Reviews" OnItemDataBound="lv_Reviews_ItemDataBound">
            <LayoutTemplate>
                <table cellpadding="2" runat="server"
                    id="tblReviews" style="height: 320px">
                    <tr runat="server" id="groupPlaceholder">
                    </tr>
                </table>
                <asp:DataPager runat="server" ID="DataPager"
                    PageSize="50">
                    <Fields>
                        <asp:NumericPagerField ButtonCount="3"
                            PreviousPageText="<---"
                            NextPageText="--->" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <GroupTemplate>
                <tr style="height:10px; background-color:lightgreen; border-style: solid">
                    <td></td>
                </tr>
                <tr runat="server" id="reviewRow"
                    style="height: 80px">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td valign="top" align="left" style="width: 100%; margin-bottom: 10px;  padding:5px 5px 0px 10px; border-style: solid" runat="server">
                    <%--Rated? :--%>
                    <asp:Label ID="lbl_Status" runat="server" Text='<% #Eval("Status") %>' Font-Bold="true" Visible="false"></asp:Label>
                    <%--<asp:HyperLink ID="ProductLink" runat="server"  Target="_blank" Text="Click to rate" NavigateUrl='<%#"SurveyForm?ReviewRefId=" + Eval("ReviewRefId")+"&submissionId="+Eval("ReviewArtifactMapId")%>' />--%>
                    
                    <hr />
                    <asp:Repeater runat="server" ID="repeater_Review" >
                        <ItemTemplate>
                            <div style="background-color:white;padding-left:10px;">
                            <%# DataBinder.Eval(Container.DataItem, "ReviewContent")%>
                                </div>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <div style="background-color:lightgrey;padding-left:10px;">
                            <%# DataBinder.Eval(Container.DataItem, "ReviewContent")%>
                                </div>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </td>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

