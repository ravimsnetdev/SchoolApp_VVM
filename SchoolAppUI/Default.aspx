<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolAppUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
    <h3 class="text-primary mb-4">School Dashboard</h3>

    <div class="row">
        <!-- Students Count -->
        <div class="col-md-3 mb-3">
            <div class="card text-white bg-primary shadow rounded-3">
                <div class="card-body text-center">
                    <h5 class="card-title">Total Students</h5>
                    <h2><asp:Label ID="lblStudentsCount" runat="server" /></h2>
                </div>
            </div>
        </div>

        <!-- Teachers Count -->
        <div class="col-md-3 mb-3">
            <div class="card text-white bg-info shadow rounded-3">
                <div class="card-body text-center">
                    <h5 class="card-title">Total Teachers</h5>
                    <h2><asp:Label ID="lblTeachersCount" runat="server" /></h2>
                </div>
            </div>
        </div>

        <!-- Present Students -->
        <div class="col-md-3 mb-3">
            <div class="card text-white bg-success shadow rounded-3">
                <div class="card-body text-center">
                    <h5 class="card-title">Present Students</h5>
                    <h2><asp:Label ID="lblPresentStudents" runat="server" /></h2>
                </div>
            </div>
        </div>

        <!-- Absent Students -->
        <div class="col-md-3 mb-3">
            <div class="card text-white bg-danger shadow rounded-3">
                <div class="card-body text-center">
                    <h5 class="card-title">Absent Students</h5>
                    <h2><asp:Label ID="lblAbsentStudents" runat="server" /></h2>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

