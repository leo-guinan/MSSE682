<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListAllTasks.aspx.cs" Inherits="TaskWebApplication.ListAllTasks" MasterPageFile="~/TaskWebApp.Master" %>

<asp:Content ID="listAllTasksContent" ContentPlaceHolderID="ContentBody" runat="Server">


    <div class="row">


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
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td runat="server"><%#Eval("name")%></td>
                    <td runat="server"><%#Eval("description")%></td>
                    <td runat="server"><%#Eval("notes")%></td>
                    <td runat="server"><%#Eval("priority")%></td>
                    <td runat="server"><%#Eval("dateCreated")%></td>
                    <td runat="server"><%#Eval("dueDate")%></td>
                    <td runat="server"><%#Eval("estimate.time")%> <%#Eval("estimate.type")%></td>
                </tr>                            
            </ItemTemplate>
        </asp:ListView>

    </div>
</asp:Content>
