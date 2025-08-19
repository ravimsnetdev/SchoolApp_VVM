<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentSummary.aspx.cs" Inherits="SchoolAppUI.StudentSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-2 mb-4">

        <div class="row">
            <div class="col-10">
                <h2 class="text-primary text-center mb-4">Student List</h2>
            </div>
            <div class="col-2">
                <asp:Button ID="btnAddNew" runat="server" Text="+ Add New" OnClick="btnAddNew_Click"  />
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
                        <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="EditRow"
                            CommandArgument='<%# Eval("StudentId") %>' CssClass="btn btn-sm btn-primary me-1" />
                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRow"
                            CommandArgument='<%# Eval("StudentId") %>' CssClass="btn btn-sm btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />

    </div>
</asp:Content>
