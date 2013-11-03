function LoginController($scope) {
    $scope.users = [
      { username: 'User1', password: "password" },
      { username: 'User2', password: "password" }];

    $scope.loggedIn = false;

    $scope.addUser = function () {
        $scope.users.push({ username: $scope.addUsername, password: $scope.addPassword });
    };

    $scope.login = function () {
        var success = false;
        for (var index = 0; index < $scope.users.length;  index++) {
            if ($scope.username === $scope.users[index].username) {
                if ($scope.password === $scope.users[index].password) {
                    $scope.loggedIn = true;
                    success = true;
}
            }
        }
        success ? $('#successModal').foundation('reveal', 'open') : $('#failureModal').foundation('reveal', 'open');
    };

    $scope.getLabel = function () {
        return $scope.loggedIn ? "Logout" : "Login";
    };

}