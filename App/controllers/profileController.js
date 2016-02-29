app.controller("profileController", function ($scope, $http, $location, CustomerService, CustomerFactory) {

    CustomerService.getcustomer(localStorage.getItem("objectid"), function (response) {
        $scope.customer = response.data[0];
    });
    debugger;
    CustomerFactory.getstates(function (res) { $scope.states = res.data });
    CustomerFactory.getdistricts(function (res) { $scope.districts = res.data });
    CustomerFactory.gettalukas(function (res) { $scope.talukas = res.data });



    $scope.addprofile = function () {
        debugger;

        $http({
            method: 'post',
            url: 'http://localhost/library/Customer/addcustomer',
            data: { customer: angular.toJson($scope.customer), objectid: localStorage.getItem("objectid") }
        }).then(function successCallback(response) {
            debugger;
            alert("Profile Updated");
            $location.url("/orderbook");

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