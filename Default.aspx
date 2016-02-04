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
                <li>Click on artifacts menu.</li>
                <li>Provide your usercode.</li>
                <li>Select an artifact to rate its reviews.</li>
                <li>Read the artifact (In most cases, just a glance over artifact is enough).</li>
                <li>
                    <div>
                        <ul>
                            
                            <li>Select a review written for the artifact.</li>
                            <li>Rate the review based on the questionnaire below.</li>
                            <li>Select one more review and rate that for the same topic.</li>
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
