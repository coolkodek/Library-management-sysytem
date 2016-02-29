app.controller("logincontroller", function ($scope, loginService, $location) {


    $scope.login = function () {
        debugger;
        loginService.login($scope.user, function (response) {

            if (response.data.length) {
                if (response.data[0].role[0] == "customer") {
                    window.location.replace("http://localhost/Library/Customer");
                    localStorage.setItem("objectid", response.data[0]._id.$oid);
                    localStorage.setItem("fullname", response.data[0].fullname);

                }
                else if (response.data[0].role[0] == "admin") {
                    window.location.replace("http://localhost/Library/Admin");
                    localStorage.setItem("objectid", response.data[0]._id.$oid);
                    localStorage.setItem("fullname", response.data[0].fullname);

                }
                else {
                    window.location.replace("http://localhost/Home/Index");
                }
            }
            else {
                alert("Wrong Login Id and Passord");
            }




        });

















    }







});