var app = angular.module('EmployeeModule', [])

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', { templateUrl: '/home/index' })
        .when('/home/about', { templateUrl: '/home/about' })
        .when('/home/contact', { templateUrl: '/home/contact' });
    $locationProvider.html5Mode(true);
}]);