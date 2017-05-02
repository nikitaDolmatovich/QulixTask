angular.module("ManagerApp.Controllers", ["ManagerApp.Services"])

    .controller("WorkerController", ["WorkerFactory", "$scope", function (workerFactory, $scope) {
        $scope.workers = workerFactory.all();
    }])

    .controller("CompanyController", ["CompanyFactory", "$scope", "$routeParams", function (productFactory, $scope, $routeParams) {
        $scope.products = productFactory.get({ id: $routeParams.id });
    }]);