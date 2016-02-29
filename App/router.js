app.config(function ($routeProvider) {
    $routeProvider

   
            .when('/profile', {
                templateUrl: '../../Library/App/partials/profile.html',
                controller: 'profileController'
            })
             .when('/Customers', {
                 templateUrl: '../../Library/App/partials/customers.html',
                 controller: 'customersController'
             })
              .when('/orders/:id', {
                  templateUrl: '../../Library/App/partials/orders.html',
                  controller: 'ordersController'
              })
               .when('/CustomerByLocation', {
                   templateUrl: '../../Library/App/partials/CustomerByLocation.html',
                   controller: 'CustomerByLocationController2'
               })
                .when('/CustomerByLocation/:type/:id', {
                    templateUrl: '../../Library/App/partials/CustomerByLocation.html',
                    controller: 'CustomerByLocationController2'
                })
            .when('/orderbook', {
                templateUrl: '../../Library/App/partials/IssueBook.html',
                controller: 'issuebookController'
            });


});
