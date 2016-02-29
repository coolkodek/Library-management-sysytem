app.factory("CustomerFactory", function ($http) {
    var factory = [];
    factory.getstates = function (callback) {
        
        $http({
            method: 'get',
            url: 'http://localhost/library/Customer/getstates'

        })
        .then(function successCallback(response) {
            callback(response);
        }, function errorCallback(response) {
            callback(response);
        });

    };

    factory.getdistricts = function (callback) {
        $http({
            method: 'get',
            url: 'http://localhost/library/Customer/getdistricts'

        })
        .then(function successCallback(response) {
            callback(response);
        }, function errorCallback(response) {
            callback(response);
        });

    };
    factory.gettalukas = function (callback) {
        $http({
            method: 'get',
            url: 'http://localhost/library/Customer/gettalukas'

        })
        .then(function successCallback(response) {
            callback(response);
        }, function errorCallback(response) {
            callback(response);
        });

    };

    return factory;

});