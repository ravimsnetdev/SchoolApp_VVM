<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentSummary.aspx.cs" Inherits="SchoolAppUI.StudentSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-primary text-center mb-4">Student List</h2>

        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            OnRowCommand="gvStudents_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="#" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                <asp:BoundField DataField="Class" HeaderText="Class" />
                <asp:BoundField DataField="Section" HeaderText="Section" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="EditRow"
                            CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-sm btn-primary me-1" />
                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRow"
                            CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-sm btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
