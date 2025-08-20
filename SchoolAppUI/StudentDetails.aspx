<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="SchoolAppUI.StudentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">
        <div class="card shadow-sm border-0 rounded-3">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">
                    <asp:Label ID="lblHeader" runat="server"></asp:Label>
                </h4>
            </div>
            <div class="card-body p-4">

                <!-- First & Last Name -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label class="form-label fw-bold">First Name</label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server"
                            ControlToValidate="txtFirstName" ErrorMessage="First Name is required."
                            CssClass="text-danger small" Display="Dynamic" />
                    </div>
                    <div class="col-md-6">
                        <label class="form-label fw-bold">Last Name</label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server"
                            ControlToValidate="txtLastName" ErrorMessage="Last Name is required."
                            CssClass="text-danger small" Display="Dynamic" />
                    </div>
                </div>

                <!-- Roll No & Gender -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label class="form-label fw-bold">Roll No</label>
                        <asp:TextBox ID="txtEditRoll" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="rfvRoll" runat="server"
                            ControlToValidate="txtEditRoll" ErrorMessage="Roll Number is required."
                            CssClass="text-danger small" Display="Dynamic" />
                        <asp:RangeValidator ID="rvRoll" runat="server"
                            ControlToValidate="txtEditRoll" MinimumValue="1" MaximumValue="1000"
                            Type="Integer" ErrorMessage="Roll Number must be between 1 and 1000."
                            CssClass="text-danger small" Display="Dynamic" />
                    </div>
                    <div class="col-md-6">
                        <label class="form-label fw-bold">Gender</label>
                        <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="rfvGender" runat="server"
                            ControlToValidate="txtGender" ErrorMessage="Gender is required."
                            CssClass="text-danger small" Display="Dynamic" />
                    </div>
                </div>

                <!-- Class & Section -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label class="form-label fw-bold">Class</label>
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-- Select Class --" Value="" />
                            <asp:ListItem Text="1" Value="1" />
                            <asp:ListItem Text="2" Value="2" />
                            <asp:ListItem Text="3" Value="3" />
                            <asp:ListItem Text="4" Value="4" />
                            <asp:ListItem Text="5" Value="5" />
                            <asp:ListItem Text="6" Value="6" />
                            <asp:ListItem Text="7" Value="7" />
                            <asp:ListItem Text="8" Value="8" />
                            <asp:ListItem Text="9" Value="9" />
                            <asp:ListItem Text="10" Value="10" />
                            <asp:ListItem Text="11" Value="11" />
                            <asp:ListItem Text="12" Value="12" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvClass" runat="server"
                            ControlToValidate="ddlClass" InitialValue=""
                            ErrorMessage="Class is required."
                            CssClass="text-danger small" Display="Dynamic" />
                    </div>
                    <div class="col-md-6">
                        <label class="form-label fw-bold">Section</label>
                        <asp:TextBox ID="txtEditSection" runat="server" CssClass="form-control" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="rfvSection" runat="server"
                            ControlToValidate="txtEditSection" ErrorMessage="Section is required."
                            CssClass="text-danger small" Display="Dynamic" />
                    </div>
                </div>

                <!-- DOB & Buttons -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label class="form-label fw-bold">Date of Birth</label>
                        <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" TextMode="Date" />
                        <asp:RequiredFieldValidator ID="rfvDOB" runat="server"
                            ControlToValidate="txtDateOfBirth" ErrorMessage="Date of Birth is required."
                            CssClass="text-danger small" Display="Dynamic" />
                        <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDateOfBirth"
                            ErrorMessage="Student age cannot be greater than 30 years."
                            CssClass="text-danger small" Display="Dynamic"
                            OnServerValidate="cvDOB_ServerValidate" />
                    </div>

                    <div class="col-md-6 mt-2">
                        <div class="mt-4">
                            <!-- Save Button -->
                            <asp:Button ID="Button1" runat="server" Text="Save Changes" CssClass="btn btn-success me-2"
                                OnClientClick="showSaveConfirm(); return false;" CausesValidation="true" />

                            <!-- Cancel Button (No Validation) -->
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary"
                                OnClick="btnCancel_Click" CausesValidation="false" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <!-- Save Confirmation Modal -->
    <div class="modal fade" id="saveConfirmModal" tabindex="-1" aria-labelledby="saveConfirmLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="saveConfirmLabel">Confirm Save</h5>
                    <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    Are you sure you want to save this student record?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnConfirmSave" runat="server" Text="Save"
                        CssClass="btn btn-success" OnClick="btnSave_Click" CausesValidation="true" />
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function showSaveConfirm() {
            // run client-side validation
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
                if (!Page_IsValid) {
                    return false; // stop if validation fails
                }
            }

            // if valid → show modal
            var modal = new bootstrap.Modal(document.getElementById('saveConfirmModal'));
            modal.show();
            return false; // still prevent immediate postback
        }
    </script>

</asp:Content>
