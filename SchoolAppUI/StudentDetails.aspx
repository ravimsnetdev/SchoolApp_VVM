<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="SchoolAppUI.StudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h5 class="text-primary">Edit Student</h5>

    <div class="mb-3">
        <label class="form-label">First Name</label>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label class="form-label">Last Name</label>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label class="form-label">Roll No</label>
        <asp:TextBox ID="txtEditRoll" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label class="form-label">Class</label>
        <asp:TextBox ID="txtEditClass" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label class="form-label">Section</label>
        <asp:TextBox ID="txtEditSection" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label class="form-label">Date of Birth</label>
        <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label class="form-label">Gender</label>
        <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" />
    </div>

    <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-success" OnClick="btnSave_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary ms-2" OnClick="btnCancel_Click" />

</asp:Content>
