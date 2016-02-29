app.controller("CustomerByLocationController", function ($scope, CustomerService, $routeParams) {

    $scope.customers = [];
    $scope.state = {};
    $scope.district = {};
    $scope.taluka = {};
    $scope.statecount = [];
    $scope.districtcount = [];
    $scope.talukacount = [];
    $scope.stateshow = true;
    $scope.districtshow = false;
    $scope.talukashow = false;


    debugger;

    CustomerService.getcustomers(function (res) {



        $scope.customers = res.data;
        angular.forEach($scope.customers, function (value, key) {

            if ($scope.state[value.state] != null)
                $scope.state[value.state] = parseInt($scope.state[value.state]) + 1;
            else
                $scope.state[value.state] = 1;
        });

        angular.forEach($scope.state, function (value, key) {

            $scope.statecount.push({ 'name': key, 'count': value });

        });






        if ($routeParams.type == "state") {
            debugger;
            angular.forEach($scope.customers, function (value, key) {
                if (value.state == $routeParams.id) {
                    if ($scope.district[value.district] != null)
                        $scope.district[value.district] = parseInt($scope.district[value.district]) + 1;
                    else
                        $scope.district[value.district] = 1;
                }
            });

            angular.forEach($scope.district, function (value, key) {

                $scope.districtcount.push({ 'name': key, 'count': value });

            });
            debugger;
            $scope.stateshow = false;
            $scope.districtshow = true;

        }




        if ($routeParams.type == "district") {
            debugger;
            angular.forEach($scope.customers, function (value, key) {
                if (value.district == $routeParams.id) {
                    if ($scope.taluka[value.taluka] != null)
                        $scope.taluka[value.taluka] = parseInt($scope.taluka[value.taluka]) + 1;
                    else
                        $scope.taluka[value.taluka] = 1;
                }
            });

            angular.forEach($scope.taluka, function (value, key) {

                $scope.talukacount.push({ 'name': key, 'count': value });

            });
            debugger;
            $scope.stateshow = false;
            $scope.talukashow = true;

        }








    });











});