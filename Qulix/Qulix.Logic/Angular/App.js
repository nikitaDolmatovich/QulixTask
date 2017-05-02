angular.module("ManagerApp", ["ngRoute", "Manager.Services", "Manager.Controllers"])

.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/workers", {
            templateUrl: "Angular/Views/Workers.html",
            controller: "WorkerController"
        })
        .when("/shop/:id/products", {
            templateUrl: "AngularUI/Views/productsView.html",
            controller: "productsController"
        })
        .otherwise({
            redirectTo: "/shops"
        });
}]);