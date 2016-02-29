app.service("loginService", function ($http) {

    this.login = function (user, callback) {
        debugger;
        $http({
            method: 'post',
            url: 'http://localhost/library/Home/validate',
            data: { user: angular.toJson(user) }
        }).then(function successCallback(response) {
            callback(response);
        }, function errorCallback(response) {
            callback(response);
        });


    }

});