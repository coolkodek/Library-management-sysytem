app.service("CustomerService", function ($http) {

    this.getcustomer = function (objectid, callback) {


        $http({
            method: 'get',
            url: 'http://localhost/library/Customer/getcustomer',
            params: { objectid: objectid }
        }).then(function successCallback(response) {
            callback(response)
        }, function errorCallback(response) {
            callback(response)
        });


    }


    this.getcustomers = function ( callback) {

        
        $http({
            method: 'get',
            url: 'http://localhost/library/Customer/getcustomers'
            
        }).then(function successCallback(response) {
            callback(response)
        }, function errorCallback(response) {
            callback(response)
        });


    }


});