<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="TaskWebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width">
    <title>Task Web Application - Add Task</title>
    <link rel="stylesheet" href="Content/foundation/foundation.css">
</head>

<body ng-controller="LoginController">

    <div id="loginModal" class="reveal-modal">
        <form id="login" class="row" ng-submit="login()">
            <div class="large-4 columns">
                <label for="username">User Name:</label>
                <input type="text" id="username" name="username" ng-model="username" />
                <label for="password">Password:</label>
                <input type="password" id="password" name="password" ng-model="password" />
                <input type="submit" value="Submit" />
            </div>
        </form>
        <a class="close-reveal-modal">&#215;</a>
    </div>
    <div id="successModal" class="reveal-modal">
        <span>Login Successful!</span>
        <a class="close-reveal-modal">&#215;</a>

    </div>
    <div id="failureModal" class="reveal-modal">
        <span>Login failed. Please try again.</span>
        <input type="button" value="Login" data-reveal-id="loginModal" />
        <a class="close-reveal-modal">&#215;</a>

    </div>

    <nav class="top-bar">
        <ul class="title-area">
            <!-- Title Area -->
            <li class="name">
                <h1><a href="#">Task Management Web Application </a></h1>
            </li>
            <!-- Remove the class "menu-icon" to get rid of menu icon. Take out "Menu" to just have icon alone -->
            <li class="toggle-topbar menu-icon"><a href="#"><span>Menu</span></a></li>
        </ul>

        <section class="top-bar-section">
            <!-- Right Nav Section -->
            <ul class="right">
                <li class="divider"></li>
                <li class="has-dropdown"><a href="#">Tasks</a>
                    <ul class="dropdown">
                        <li><a href="#">Add Task</a></li>
                        <li class="divider"></li>
                        <li><a href="#">Edit Tasks</a></li>
                        <li class="divider"></li>
                        <li><a href="#">View All Tasks</a></li>
                    </ul>
                </li>
                <li class="divider"></li>
                <li class="divider hide-for-small"></li>
                <li><a href="#" data-reveal-id="loginModal">{{getLabel()}}</a></li>
                <li class="divider"></li>
            </ul>
        </section>
    </nav>

    <form id="form1" runat="server">
        <div class="row">
            <label for="name">
                Name:
            </label>
            <input type="text" name="name" />
        </div>
        <div class="row">
            <label for="notes">
                Notes:
            </label>
            <input type="text" name="notes" />

            <label for="description">
                Description:
            </label>
            <input type="text" name="description" />
        </div>
        <div class="row">
            <label for="priority">
                Priority:
            </label>
            <input type="text" name="priority" />

            <label for="dueDate">
                Due Date:
            </label>
            <input type="text" name="dueDate" />
        </div>
        <div class="row">
            </label>
            <input type="text" name="time" />
            <label for="type">
                Type:
            </label>
            <input type="text" name="type" />
        </div>
        <input type="submit" value="Add Task" id="addTask" />
    </form>
    <script>
        document.write('<script src=' +
        ('__proto__' in {} ? 'Scripts/zepto' : 'Scripts/jquery') +
        '.js><\/script>')
  </script>
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/controllers/LoginController.js"></script>

    <script src="Scripts/foundation/foundation.js"></script>
    <script src="Scripts/foundation/foundation.reveal.js"></script>
    <script>
        $(document).foundation();
  </script>

</body>
</html>
