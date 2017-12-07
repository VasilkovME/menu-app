angular.module("IngredientApp")
       .service("ingredientService", ["$q", "$http", function ($q, $http) {
           this.getAllIngredients = function () {
               var deferred = $q.defer();

               $http.get('/ingredient/getallingredients')
                   .then(function (responce) {
                       deferred.resolve(responce);
                   },
                   function (responce) {
                       deferred.reject(responce);
                   });

               return deferred.promise;
           };
        
           this.createIngredient = function (ingredient) {
               var deferred = $q.defer();

               $http.post('/ingredient/create', ingredient)
                   .then(function (responce) {
                       deferred.resolve(responce);
                   },
                   function (responce) {
                       deferred.reject(responce);
                   });

               return deferred.promise;
           };

           this.getById = function (ingredientId) {
               var deferred = $q.defer();

               $http.get('/ingredient/getbyid/' + ingredientId)
                    .then(function (responce) {
                               deferred.resolve(responce);
                           }, function (responce) {
                               deferred.reject(responce);
                           });

               return deferred.promise;
           };

           this.editIngredient = function (ingredient) {
               var deferred = $q.defer();

               $http.post('/ingredient/edit', ingredient)
                   .then(function (responce) {
                       deferred.resolve(responce);
                   },
                   function (responce) {
                       deferred.reject(responce);
                   });

               return deferred.promise;
           };

           this.deleteIngredient = function (ingredientId) {
               var deferred = $q.defer();
               var data = { ingredientId: ingredientId };

               $http.post('/ingredient/delete', data)
                   .then(function (responce) {
                       deferred.resolve(responce);
                   },
                   function (responce) {
                       deferred.reject(responce);
                   });

               return deferred.promise;
           };

        }]);