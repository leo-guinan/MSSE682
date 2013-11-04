<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListAllTasks.aspx.cs" Inherits="TaskWebApplication.ListAllTasks" %>

<%@ Register TagPrefix="uc" TagName="Menu"
    Src="~/MenuControl.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width">
    <title>Task Web Application - View All Tasks</title>
    <link rel="stylesheet" href="Content/foundation/foundation.css">
</head>
<body>
    <uc:Menu runat="server" ID="menu" />
    <div class="row">
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
                <tr>
                    <td>@task.name</td>
                    <td>@task.description</td>
                    <td>@task.notes</td>
                    <td>@task.priority</td>
                    <td>@task.dateCreated</td>
                    <td>@task.dueDate</td>
                    <td>@task.time @task.type</td>
                </tr>
                <tr>
                    <td>@task.name</td>
                    <td>@task.description</td>
                    <td>@task.notes</td>
                    <td>@task.priority</td>
                    <td>@task.dateCreated</td>
                    <td>@task.dueDate</td>
                    <td>@task.time @task.type</td>
                </tr>
                <tr>
                    <td>@task.name</td>
                    <td>@task.description</td>
                    <td>@task.notes</td>
                    <td>@task.priority</td>
                    <td>@task.dateCreated</td>
                    <td>@task.dueDate</td>
                    <td>@task.time @task.type</td>
                </tr>
                <tr>
                    <td>@task.name</td>
                    <td>@task.description</td>
                    <td>@task.notes</td>
                    <td>@task.priority</td>
                    <td>@task.dateCreated</td>
                    <td>@task.dueDate</td>
                    <td>@task.time @task.type</td>
                </tr>
                <tr>
                    <td>@task.name</td>
                    <td>@task.description</td>
                    <td>@task.notes</td>
                    <td>@task.priority</td>
                    <td>@task.dateCreated</td>
                    <td>@task.dueDate</td>
                    <td>@task.time @task.type</td>
                </tr>
                <tr>
                    <td>@task.name</td>
                    <td>@task.description</td>
                    <td>@task.notes</td>
                    <td>@task.priority</td>
                    <td>@task.dateCreated</td>
                    <td>@task.dueDate</td>
                    <td>@task.time @task.type</td>
                </tr>
                <tr>
                    <td>@task.name</td>
                    <td>@task.description</td>
                    <td>@task.notes</td>
                    <td>@task.priority</td>
                    <td>@task.dateCreated</td>
                    <td>@task.dueDate</td>
                    <td>@task.time @task.type</td>
                </tr>
            </tbody>
        </table>
    </div>
</body>
</html>
