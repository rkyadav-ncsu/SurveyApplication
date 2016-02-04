<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SurveyForm.aspx.cs" Inherits="WebPages_SurveyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="div_reviews" style="margin-top:50px; padding:10px 5px 5px 0px">
        <h3>Review</h3>
        <table style="border-style:solid">
            <tr>
                <td valign="top" align="left" style="width: 100%; margin-bottom: 10px; border-style: solid" runat="server">
                    <asp:Repeater runat="server" ID="repeater_Review">
                        <ItemTemplate>
                            <div style="background-color: white; padding-left: 10px;">
                                <%# DataBinder.Eval(Container.DataItem, "ReviewContent")%>
                            </div>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <div style="background-color: grey; padding-left: 10px;">
                                <%# DataBinder.Eval(Container.DataItem, "ReviewContent")%>
                            </div>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </div>

    <div style="margin-top:10px; border-style:solid; padding:10px 5px 5px 10px">
        <asp:Repeater runat="server" ID="r_SurveyQuestions">
            <ItemTemplate>
                <asp:Label runat="server" ID="Label1" Text='<% #Eval("QuestionText") %>'></asp:Label><br />
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false" Width="100px">
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
                <br />
            </ItemTemplate>

        </asp:Repeater>

    </div>
    <div style="margin-top:10px; padding:10px 5px 5px 10px">
    <input onclick="window.close();" type="button" value="close" />
    <asp:Button runat="server" ID="btnSave" Text="Save"  OnClick="btnSave_Click" />
        </div>
</asp:Content>

