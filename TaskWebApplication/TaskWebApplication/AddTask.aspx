<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="TaskWebApplication.AddTask" MasterPageFile="~/TaskWebApp.Master" %>

<asp:Content ID="addTaskContent" ContentPlaceHolderID="ContentBody" runat="Server">


    <div class="row">
        <label for="name">
            Name:
        </label>
        <asp:TextBox ID="name" runat="server" />
    </div>
    <div class="row">
        <label for="notes">
            Notes:
        </label>
        <asp:TextBox ID="notes" runat="server" />

        <label for="description">
            Description:
        </label>
        <asp:TextBox ID="description" runat="server" />
    </div>
    <div class="row">
        <label for="priority">
            Priority:
        </label>
        <asp:TextBox ID="priority" runat="server" />

        <label for="dueDate">
            Due Date:
        </label>
        <asp:TextBox ID="dueDate" runat="server" TextMode="Date" />
    </div>
    <div class="row">
        <label for="time">
            Time:
        </label>
        <asp:TextBox ID="time" runat="server" />
        <label for="type">
            Type:
        </label>
        <asp:TextBox ID="type" runat="server" />
    </div>
    <asp:Button ID="submit" OnClick="AddTask_Click" runat="server" Text="Add Task" />

</asp:Content>
