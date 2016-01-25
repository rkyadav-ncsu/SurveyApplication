<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Artifact.aspx.cs" Inherits="WebPages_Artifact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>Artifact Submitted </h3>
    <div style="width: 100%; margin: 5px 5px 5px 5px">
        
        <div id="div_ArtifactTitle" style="width: 100%; float: left" runat="server">
        </div>
        <div id="div_ArtifactText" style="width: 100%; float: left" runat="server">
        </div>
    </div>
    <hr />
    <div id="div_reviews" style="margin-top:50px">
        <h3>Reviews</h3>
        <asp:ListView runat="server" ID="lv_Reviews">
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
                <td valign="top" align="left" style="width:100%" runat="server">
                    <asp:Label ID="lbl_Label" runat="server" Text='<% #Eval("ReviewContent")%>'></asp:Label>
                    </br>
                    <asp:Label ID="lbl_Status" runat="server" Text='<% #Eval("Status") %>'></asp:Label>
                    <asp:HyperLink ID="ProductLink" runat="server"
                        Target="_top" Text="Click to rate"
                        NavigateUrl='<%#"SurveyForm?ReviewId=" + 
              Eval("ReviewId") %>' />
                </td>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

