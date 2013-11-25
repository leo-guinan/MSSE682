function LoginController($scope) {


    $scope.loggedIn = $("#login").data("currentUser") ? true : false;

    $scope.loginUser = function () {
       
        $scope.loggedIn ? $('#successModal').foundation('reveal', 'open') : $('#failureModal').foundation('reveal', 'open');
    };

    $scope.login = $scope.loggedIn ? "Logout" : "Login";
    
}