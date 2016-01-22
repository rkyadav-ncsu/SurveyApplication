<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Expertiza Survey</h1>
        <p class="lead">This website is ad-hoc portal created for expertiza based survey.</p>
    </div>

    <div class="row">
        <div class="col-md-10">
            <h2>Tasks you will be performing</h2>
            <ul>
                <li>Select a topic to review.</li>
                <li>Read that topic.</li>
                <li>
                    <div>
                        <ul>
                            
                            <li>Select a review written for the current topic.</li>
                            <li>Rate review based on the questionnaire.</li>
                            <li>Select one more review and rate that for this topic.</li>
                        </ul>
                    </div>
                </li>
                <li>
                    Repeat the process for 10 other topics. Make sure to select previously unselected topics.
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
