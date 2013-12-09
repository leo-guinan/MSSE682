<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListAllTasks.aspx.cs" Inherits="TaskWebApplication.ListAllTasks" MasterPageFile="~/TaskWebApp.Master" %>

<asp:Content ID="listAllTasksContent" ContentPlaceHolderID="ContentBody" runat="Server">


    <div class="row">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DEFAULT" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <asp:ListView runat="server" ID="listAllTasks">
                    <LayoutTemplate>
                        <table id="tasks" data-direction="@Model.direction" data-sort="@Model.sort">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Description</th>
                                    <th>Notes</th>
                                    <th>Priority</th>
                                    <th>Date Created</th>
                                    <th>Due Date</th>
                                    <th>Estimate</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr runat="server">
                            <td runat="server">
                                <asp:TextBox runat="server" OnTextChanged="EditSubmitClick" CssClass='<%#Eval("id")%>' Text='<%#Eval("name")%>' Enabled="false" data-field="name"></asp:TextBox></td>
                            <td runat="server">
                                <asp:TextBox runat="server" OnTextChanged="EditSubmitClick" CssClass='<%#Eval("id")%>' Text='<%#Eval("description")%>' Enabled="false" data-field="description"></asp:TextBox></td>
                            <td runat="server">
                                <asp:TextBox runat="server" OnTextChanged="EditSubmitClick" CssClass='<%#Eval("id")%>' Text='<%#Eval("notes")%>' Enabled="false" data-field="notes"></asp:TextBox></td>
                            <td runat="server">
                                <asp:TextBox runat="server" OnTextChanged="EditSubmitClick" CssClass='<%#Eval("id")%>' Text='<%#Eval("priority")%>' Enabled="false" data-field="priority"></asp:TextBox></td>
                            <td runat="server">
                                <asp:TextBox runat="server" OnTextChanged="EditSubmitClick" CssClass='<%#Eval("id")%>' Text='<%#Eval("dateCreated")%>' Enabled="false" data-field="dateCreated"></asp:TextBox></td>
                            <td runat="server">
                                <asp:TextBox runat="server" OnTextChanged="EditSubmitClick" CssClass='<%#Eval("id")%>' Text='<%#Eval("dueDate")%>' Enabled="false" data-field="dueDate"></asp:TextBox></td>
                            <td runat="server">
                                <asp:TextBox runat="server" OnTextChanged="EditSubmitClick" CssClass='<%#Eval("id")%>' Text='<%#Eval("estimate.time")%>' Enabled="false" data-field="estimateTime"></asp:TextBox>
                                <asp:TextBox runat="server" OnTextChanged="EditSubmitClick" CssClass='<%#Eval("id")%>' Text='<%#Eval("estimate.type")%>' Enabled="false" data-field="estimateType"></asp:TextBox></td>
                            <td runat="server">
                                <asp:Button runat="server" Text="Edit" OnClick="EditClick" data-id='<%#Eval("id")%>' CssClass="EDIT" /></td>
                            <td runat="server">
                                <asp:Button runat="server" Text="Delete" OnClick="DeleteClick" data-id='<%#Eval("id")%>' CssClass="DELETE" /></td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <asp:Button ID="DEFAULT" Visible="false" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
