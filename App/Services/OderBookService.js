app.service("OrderBookService", function ($http) {

    this.orderbooks = function (customer, objectid, callback) {


        $http({
            method: 'post',
            url: 'http://localhost/library/Customer/orderbooks',
            data: { customer: angular.toJson(customer), objectid: objectid }
        }).then(function successCallback(response) {
            callback(response);

        }, function errorCallback(response) {
            callback(response);
        });


    }


});