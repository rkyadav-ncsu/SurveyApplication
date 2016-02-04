<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SurveyMaster.aspx.cs" Inherits="WebPages_SurveyMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:TextBox runat="server" ID="txt_UserCode"></asp:TextBox>
    <asp:Button runat="server" ID="btn_UserCode" Text="Submit User Code" onclick="btn_UserCode_Click"/> <br />
    <asp:Label runat="server" ID="lbl_Message"></asp:Label>
    <div style="width:100%; margin:15px 5px 5px 5px">
    <asp:GridView runat="server" ID="gv_SurveyMaster" AutoGenerateEditButton="false" AutoGenerateColumns="false" CellPadding="2">
        <Columns>
            <asp:BoundField HeaderText="Title"  DataField="ArtifactText" />
            <asp:HyperLinkField HeaderText=""  DataTextField="ArtifactId" DataTextFormatString="Expand" DataNavigateUrlFields="ArtifactId" DataNavigateUrlFormatString="artifact.aspx\?id={0}"  ItemStyle-HorizontalAlign="Center"/>
        </Columns>
    </asp:GridView>
        </div>
</asp:Content>

