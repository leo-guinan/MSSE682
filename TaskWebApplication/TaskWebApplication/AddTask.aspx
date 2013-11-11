<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="TaskWebApplication.AddTask" %>

 <%@ Register TagPrefix="uc" TagName="Menu" 
    Src="~/MenuControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>Task Web Application - Add Task</title>
    <link rel="stylesheet" href="Content/foundation/foundation.css" />
</head>

<body>
    
    <uc:Menu id="menu" runat="server" />

    <form id="form1" runat="server">
        <div class="row">
            <label for="name">
                Name:
            </label>
            <asp:input type="text" name="name" />
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
            <asp:TextBox ID="dueDate" runat="server" />
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
    </form>
 

</body>
</html>
