<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Artifact.aspx.cs" Inherits="WebPages_Artifact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>Artifact Submitted </h3>
    <div style="width: 100%; height: 500px; margin: 5px 5px 5px 5px">

        <iframe runat="server" id="i_wiki" src="" style="width: 100%; height: 100%;"></iframe>
    </div>
    <hr />
    <div id="div_reviews" style="margin-top: 50px">
        <h3>Reviews</h3>
        <asp:ListView runat="server" ID="lv_Reviews" OnItemDataBound="lv_Reviews_ItemDataBound">
            <LayoutTemplate>
                <table cellpadding="2" runat="server"
                    id="tblReviews" style="height: 320px">
                    <tr runat="server" id="groupPlaceholder">
                    </tr>
                </table>
                <asp:DataPager runat="server" ID="DataPager"
                    PageSize="9">
                    <Fields>
                        <asp:NumericPagerField ButtonCount="3"
                            PreviousPageText="<--"
                            NextPageText="-->" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <GroupTemplate>
                <tr runat="server" id="reviewRow"
                    style="height: 80px">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td valign="top" align="left" style="width: 100%; margin-bottom: 10px;  border-style: double" runat="server">
                    Rated? :
                    <asp:Label ID="lbl_Status" runat="server" Text='<% #Eval("Status") %>'></asp:Label>
                    <asp:HyperLink ID="ProductLink" runat="server"  Target="_blank" Text="Click to rate" NavigateUrl='<%#"SurveyForm?ReviewRefId=" + Eval("ReviewRefId")+"&submissionId="+Eval("ReviewArtifactMapId")%>' />
                    <br />
                    <asp:Repeater runat="server" ID="repeater_Review" >
                        <ItemTemplate>
                            <div style="background-color:white;padding-left:10px;">
                            <%# DataBinder.Eval(Container.DataItem, "ReviewContent")%>
                                </div>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <div style="background-color:grey;padding-left:10px;">
                            <%# DataBinder.Eval(Container.DataItem, "ReviewContent")%>
                                </div>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </td>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

