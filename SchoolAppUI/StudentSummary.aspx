<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentSummary.aspx.cs" Inherits="SchoolAppUI.StudentSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-2 mb-4">

        <div class="row">
            <div class="col-10">
                <h2 class="text-primary text-center mb-4">Student List</h2>
            </div>
            <div class="col-2">
                <asp:Button ID="btnAddNew" runat="server" Text="+ Add New" OnClick="btnAddNew_Click" CssClass="btn btn-sm btn-warning" />
            </div>
        </div>

        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            OnRowCommand="gvStudents_RowCommand">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="#" />
                <asp:BoundField DataField="Name" HeaderText="Full Name" />
                <asp:BoundField DataField="RollNumber" HeaderText="Roll Number" />
                <asp:BoundField DataField="Class" HeaderText="Class" />
                <asp:BoundField DataField="Section" HeaderText="Section" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="GenderDisplay" HeaderText="Gender" />

                <%--                <asp:BoundField DataField="FirstInsertedBy" HeaderText="Created By" />
                <asp:BoundField DataField="FirstInsertedDateTime" HeaderText="Created Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="LastUpdatedBy" HeaderText="Updated By" />
                <asp:BoundField DataField="LastUpdatedDateTime" HeaderText="Updated Date" DataFormatString="{0:MM/dd/yyyy}" />
                --%>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CommandArgument='<%# Eval("StudentId") %>' Text="Edit" CssClass="btn btn-sm btn-primary" />
                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="ShowDeletePopup" CommandArgument='<%# Eval("StudentId") %>' Text="Delete" CssClass="btn btn-sm btn-danger" />
            </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <!-- Delete Confirmation Modal -->
        <div class="modal fade" id="deleteConfirmModal" tabindex="-1" aria-labelledby="deleteConfirmModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header bg-danger text-white">
                        <h5 class="modal-title" id="deleteConfirmModalLabel">Confirm Delete</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        Are you sure you want to delete this student?
                        <asp:HiddenField ID="hfDeleteId" runat="server" />
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnConfirmDelete" runat="server" Text="DELETE" CssClass="btn btn-danger" OnClick="btnConfirmDelete_Click" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">CANCEL</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
