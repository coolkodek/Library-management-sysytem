app.controller("CustomerByLocationController2", function ($scope, CustomerService, $routeParams) {

    $scope.customers = [];
    $scope.statecount = [];
    $scope.districtcount = [];
    $scope.talukacount = [];
    $scope.stateshow = true;
    $scope.districtshow = false;
    $scope.talukashow = false;
    localStorage.setItem("dtype", "state");
    localStorage.setItem("dvalue", "");



    CustomerService.getcustomers(function (res) {


       
        $scope.customers = res.data;
        angular.forEach($scope.customers, function (value, key) {

            if (findIndexByKeyValue($scope.statecount, "name", value.state) != null) {
                $scope.statecount[findIndexByKeyValue($scope.statecount, "name", value.state)]["count"] = parseInt($scope.statecount[findIndexByKeyValue($scope.statecount, "name", value.state)]["count"]) + 1;
            }
            else {
                $scope.statecount.push({ 'name': value.state, 'count': 1 });
            }

        });




        if ($routeParams.type == "state") {

           
            angular.forEach($scope.customers, function (value, key) {
                if (value.state == $routeParams.id) {
                    if (findIndexByKeyValue($scope.districtcount, "name", value.district) != null) {
                       
                        $scope.districtcount[findIndexByKeyValue($scope.districtcount, "name", value.district)]["count"] = parseInt($scope.districtcount[findIndexByKeyValue($scope.districtcount, "name", value.district)]["count"]) + 1;
                    }
                    else {
                        $scope.districtcount.push({ 'name': value.district, 'count': 1 });
                    }
                }
            });

            $scope.stateshow = false;
            $scope.districtshow = true;
            localStorage.setItem("dtype", "district");
            localStorage.setItem("dvalue", $routeParams.id);

        }




        if ($routeParams.type == "district") {

            angular.forEach($scope.customers, function (value, key) {
                if (value.district == $routeParams.id) {
                    if (findIndexByKeyValue($scope.talukacount, "name", value.taluka) != null) {
                        $scope.talukacount[findIndexByKeyValue($scope.talukacount, "name", value.taluka)]["count"] = parseInt($scope.talukacount[findIndexByKeyValue($scope.talukacount, "name", value.taluka)]["count"]) + 1;
                    }
                    else {
                        $scope.talukacount.push({ 'name': value.taluka, 'count': 1 });
                    }
                }
            });

            $scope.stateshow = false;
            $scope.talukashow = true;
            localStorage.setItem("dtype", "taluka");
            localStorage.setItem("dvalue", $routeParams.id);
        }








    });




    function findIndexByKeyValue(obj, key, value) {
        for (var i = 0; i < obj.length; i++) {
            if (obj[i][key] == value) {
                return i;
            }
        }
        return null;
    }



});