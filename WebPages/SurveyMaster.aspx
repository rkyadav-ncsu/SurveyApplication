<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SurveyMaster.aspx.cs" Inherits="WebPages_SurveyMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView runat="server" ID="gv_SurveyMaster" AutoGenerateEditButton="false" AutoGenerateColumns="false" CellPadding="2">
        <Columns>
            <asp:BoundField HeaderText="Title"  DataField="ArtifactText" />
            <asp:HyperLinkField HeaderText=""  DataTextField="ArtifactId" DataTextFormatString="Expand" DataNavigateUrlFields="ArtifactId" DataNavigateUrlFormatString="artifact.aspx\?id={0}"  ItemStyle-HorizontalAlign="Center"/>
        </Columns>
    </asp:GridView>
</asp:Content>

