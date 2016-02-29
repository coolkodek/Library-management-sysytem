app.factory("BookFactory", function ($http) {
    var factory = [];
    factory.getbooks = function (callback) {
        $http({
            method: 'get',
            url: 'http://localhost/library/Customer/getbooks'

        })
        .then(function successCallback(response) {
            callback(response);
        }, function errorCallback(response) {
            callback(response);
        });

    };

    return factory;

});