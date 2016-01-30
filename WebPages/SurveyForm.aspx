<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SurveyForm.aspx.cs" Inherits="WebPages_SurveyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <div id="div_reviews" style="margin-top: 50px">
        <h3>Reviews</h3>
                <td valign="top" align="left" style="width: 100%; margin-bottom: 10px;  border-style: double" runat="server">
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
    </div>

    <div>
        <asp:Label runat="server" ID="Label1" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" ID="Label2" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" ID="Label3" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" ID="Label4" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" ID="Label5" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" ID="Label6" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" ID="Label7" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" ID="Label8" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList8" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" ID="Label9" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList9" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" ID="Label10" Text=""></asp:Label><br />
    <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="false">
        <asp:ListItem Text="1" Value="1">
        </asp:ListItem>
        <asp:ListItem Text="2" Value="2">
        </asp:ListItem>
        <asp:ListItem Text="3" Value="3">
        </asp:ListItem>
        <asp:ListItem Text="4" Value="4">
        </asp:ListItem>
        <asp:ListItem Text="5" Value="5">
        </asp:ListItem>
    </asp:DropDownList>
    </div>
    <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" />
    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
</asp:Content>

