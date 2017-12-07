angular.module("FoodApp").service('foodService', ['$q', '$http', function ($q, $http) {
    this.createNewFood = function (newFood) {
        var deferred = $q.defer();

        $http.post('/food/create', newFood)
            .then(function (responce) {
                deferred.resolve(responce);
            }, function (responce) {
                deferred.reject(responce);
            });

        return deferred.promise;
    };

    this.getAllFoods = function () {
        var deferred = $q.defer();

        $http.get('/food/getallfoods')
            .then(function (responce) {
                deferred.resolve(responce);
            }, function (responce) {
                deferred.reject(responce);
            });

        return deferred.promise;
    };

    this.getFoodIngredients = function (foodId) {
        var deferred = $q.defer();

        $http.get('/food/ingredients', { params: { foodId: foodId } })
            .then(function (responce) {
                deferred.resolve(responce);
            }, function (responce) {
                deferred.reject(responce);
            });

        return deferred.promise;
    };

    this.searchIngredients = function (searchTerm) {
        var deferred = $q.defer();

        $http.get('/ingredient/FindByName', { params: { searchTerm: searchTerm } })
            .then(function (responce) {
                deferred.resolve(responce);
            }, function (responce) {
                deferred.reject(responce);
            });

        return deferred.promise;
    };

    this.addFoodingredient = function (foodIngredient) {
        var deferred = $q.defer();

        $http.post('/food/CreateFoodIngredient', foodIngredient)
            .then(function (responce) {
                deferred.resolve(responce);
            }, function (responce) {
                deferred.reject(responce);
            });

        return deferred.promise;
    };

    this.editFood = function (food) {
        var deferred = $q.defer();

        $http.post('/food/Edit', food)
            .then(function (responce) {
                deferred.resolve(responce);
            }, function (responce) {
                deferred.reject(responce);
            });

        return deferred.promise;
    }
}]);