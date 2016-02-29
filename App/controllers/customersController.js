app.controller("customersController", function ($scope, OrderBookService, CustomerService, $location, BookFactory) {

//    var car = [{ type: "Fiat", model: "500", color: "white" },{ type: "maruti", model: "300", color: "red" }];
//    alert(car[findIndexByKeyValue(car,"model","500")]["type"]);
//    car[findIndexByKeyValue(car,"model","500")]["type"] = "maruti";
//    console.log(car);



    CustomerService.getcustomers(function (response) {

        $scope.customers = response.data;
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