<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TaskWebApplication.Index" %>

<%@ Register TagPrefix="uc" TagName="Menu"
    Src="~/MenuControl.ascx" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml" ng-app>
<head runat="server" >
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width">
    <title>Task Web Application - Welcome</title>
    <link rel="stylesheet" href="Content/foundation/foundation.css">
</head>
<body>
    <uc:Menu ID="menu" runat="server" />
    <h1>Welcome to the Task Management Web Application! Select an option from the menu to begin!</h1>
</body>
</html>
