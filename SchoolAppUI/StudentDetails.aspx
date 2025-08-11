<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="SchoolAppUI.StudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <h5 class="text-primary">Edit Student</h5>
  <asp:HiddenField ID="hfEditID" runat="server" />
  <div class="mb-3">
      <label class="form-label">Name</label>
      <asp:TextBox ID="txtEditName" runat="server" CssClass="form-control" />
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
  <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-success" OnClick="btnSave_Click" />
  <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary ms-2" OnClick="btnCancel_Click" />
       

</asp:Content>
