app.controller("registercontroller", function ($scope, $http, $location) {


    $scope.register = function () {
        debugger;
        $scope.user.role = ["customer"];
        $http({
            method: 'post',
            url: 'http://localhost/library/Home/addcustomer',
            data: { customer: angular.toJson($scope.user) }
        }).then(function successCallback(response) {
            debugger;
            localStorage.setItem("objectid", response.data);
            localStorage.setItem("fullname", $scope.user.fullname);
            window.location.replace("http://localhost/Library/Customer");

            // this callback will be called asynchronously
            // when the response is available
            if (!response)
                alert("Please enter correct Login Pass");
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });


    }







});