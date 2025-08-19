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

     <asp:Button ID="Button1" runat="server" Text="Save Changes" CssClass="btn btn-success"
        OnClientClick="showSaveConfirm(); return false;" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary ms-2" OnClick="btnCancel_Click" />

     <!-- Save Confirmation Modal -->
    <div class="modal fade" id="saveConfirmModal" tabindex="-1" aria-labelledby="saveConfirmLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="saveConfirmLabel">Confirm Save</h5>
                    <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    Are you sure you want to save this student record?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                    <asp:Button ID="btnConfirmSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function showSaveConfirm() {
            var modal = new bootstrap.Modal(document.getElementById('saveConfirmModal'));
            modal.show();
        }
    </script>

</asp:Content>
