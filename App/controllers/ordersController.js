app.controller("ordersController", function ($scope, $routeParams, CustomerService) {


 


    CustomerService.getcustomer($routeParams.id, function (response) {
        debugger;
        $scope.customer = response.data[0];
    });


  

});