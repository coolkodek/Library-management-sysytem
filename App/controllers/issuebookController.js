app.controller("issuebookController", function ($scope, OrderBookService,CustomerService, $location, BookFactory) {
    debugger;
    $scope.customer = { "books": [] };

    BookFactory.getbooks(function (response) {

        $scope.books = response.data;

        CustomerService.getcustomer(localStorage.getItem("objectid"), function (response) {
            $scope.customer = response.data[0];
        });

    });



    $scope.orderbooks = function () {
        debugger;
        OrderBookService.orderbooks($scope.customer, localStorage.getItem("objectid"), function (response) {
            alert("Books orderd successfully");
        });

    }




});