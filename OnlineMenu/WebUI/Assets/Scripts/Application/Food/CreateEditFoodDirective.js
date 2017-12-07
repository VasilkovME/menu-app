angular.module("FoodApp")
       .directive('createEditFoodForm', function () {
           return {
               restrict: 'E',
               templateUrl: '/Assets/Templates/CreateEditFoodFormTemplate.html',
               scope: {
                   heading: '@',
                   food: '=',
                   resources: '=',
                   clickCallBack: '&',
                   foodTypesOptions: '=',
                   blockUiId: '@',
               },
               controller: ['$scope', function ($scope) {
                   $scope.$watch(function () {
                       var enabled = ($scope.food.Name && $scope.food.FoodType);
                       return enabled;
                   }, function (newValue, oldValue) {
                       $scope.saveButtonDisabled = !($scope.food.Name && $scope.food.FoodType!=undefined);
                   });
               }]
           };
       });