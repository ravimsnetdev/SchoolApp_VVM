<%@ Page Title="Student Summary" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentSummary.aspx.cs" Inherits="SchoolAppUI.StudentSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-3 mb-4">

        <!-- Header -->
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h3 class="text-primary fw-bold">👩‍🎓 Student Summary</h3>
            <asp:Button ID="btnAddNew" runat="server" Text="+ Add Student" CssClass="btn btn-success shadow-sm" OnClick="btnAddNew_Click" />
        </div>

        <!-- Grid -->
        <div class="card shadow-sm rounded-3 border-0">
            <div class="card-body p-0">
                <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-hover align-middle mb-0"
                    HeaderStyle-CssClass="table-light fw-bold"
                    GridLines="None" BorderStyle="None"
                    OnRowCommand="gvStudents_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="StudentId" HeaderText="#" ItemStyle-CssClass="text-muted" />

                        <asp:BoundField DataField="Name" HeaderText="Full Name" />

                        <asp:BoundField DataField="RollNumber" HeaderText="Roll No." />

                        <asp:BoundField DataField="Class" HeaderText="Class" />

                        <asp:BoundField DataField="Section" HeaderText="Section" />

                        <asp:BoundField DataField="DateOfBirth" HeaderText="DOB" DataFormatString="{0:dd-MMM-yyyy}" />

                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <span class='badge <%# Eval("GenderDisplay").ToString() == "Male" ? "bg-primary" : "bg-success" %>'>
                                    <%# Eval("GenderDisplay") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server"
                                    CommandName="EditRow"
                                    CommandArgument='<%# Eval("StudentId") %>'
                                    CssClass="btn btn-sm btn-outline-primary me-2">
                                    <i class="bi bi-pencil-square"></i> Edit
                                </asp:LinkButton>

                                <asp:LinkButton ID="lnkDelete" runat="server"
                                    CommandName="ShowDeletePopup"
                                    CommandArgument='<%# Eval("StudentId") %>'
                                    CssClass="btn btn-sm btn-outline-danger">
                                    <i class="bi bi-trash"></i> Delete
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- Delete Confirmation Modal -->
        <div class="modal fade" id="deleteConfirmModal" tabindex="-1" aria-labelledby="deleteConfirmModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content shadow-lg border-0 rounded-3">
                    <div class="modal-header bg-danger text-white">
                        <h5 class="modal-title fw-bold" id="deleteConfirmModalLabel">⚠️ Confirm Delete</h5>
                        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        Are you sure you want to delete this student record?
                        <asp:HiddenField ID="hfDeleteId" runat="server" />
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnConfirmDelete" runat="server" Text="Yes, Delete" CssClass="btn btn-danger" OnClick="btnConfirmDelete_Click" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
