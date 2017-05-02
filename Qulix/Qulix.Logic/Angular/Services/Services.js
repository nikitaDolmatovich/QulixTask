angular.module("ManagerApp.Services", ["ngResource"])

.factory("WorkerFactory", ["$resource", function ($resource) {
    return $resource("worker", {}, {
        all: { method: "GET", isArray: true }
    });
}])

.factory("CompanyFactory", ["$resource", function ($resource) {
    return $resource("shop/:id/products", { id: "@id" }, {
        get: { method: "GET", isArray: true }
    });
}]);