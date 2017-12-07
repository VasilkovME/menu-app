angular.module("FoodApp")
       .controller('foodController', ['$scope', 'foodService', 'uiGridConstants', 'toaster', 'blockUI', function ($scope, foodService, uiGridConstants, toaster, blockUI) {

           var foodTypes = [
               { value: 0, name: 'SideDish'},
               { value: 1, name: 'Soup' },
               { value: 2, name: 'Salad' },
               { value: 3, name: 'Meat' },
               { value: 4, name: 'Fish' }
           ];

           $scope.newFood = {};
           $scope.loading = true;
           $scope.activeTabIndex = 0;
           $scope.newFoodBlockId = 'newFoodBlockId';
           $scope.editFoodBlockId = 'editFoodBlockId';

           $scope.newFoodResources = {
               foodName: 'Food Name',
               foodType: 'Food Type',
               buttonLabel: 'Create',
               placeholder: 'Input food name',
               foodCreated: 'Food has been successfully created'
           };
           $scope.editFoodResources = {
               foodName: 'Food Name',
               foodType: 'Food Type',
               buttonLabel: 'Save',
               placeholder: 'Input food name',
               foodSaved: 'Food has been successfully saved'
           };
           $scope.foodTypes = foodTypes;

           var columns = [
                   {
                       field: 'FoodId',
                       visible: false
                   },
                   {
                       field: 'Name',
                       filter: { condition: uiGridConstants.filter.CONTAINS, placeholder: 'contains' },
                       enableColumnMenu: false
                   },
                   {
                       field: 'FoodTypeName',
                       displayName: 'Food type',
                       filter: { condition: uiGridConstants.filter.CONTAINS, placeholder: 'contains' },
                       enableColumnMenu: false,
                       width: '15%'
                   },
                   {
                       field: 'ExpandRowControl',
                       enableColumnMenu: false,
                       displayName: '',
                       enableFiltering: false,
                       width: '30',
                       cellTemplate: '/Assets/Templates/ExpandRowCellTemplate.html',
                   }
           ];
                      
           $scope.toggleExpand = function (row) {
               var entityToEdit = row.entity;
               var destination = $scope.gridOptions.expandableRowScope.foodToEdit;
               angular.copy(entityToEdit, destination);
               $scope.gridApi.expandable.toggleRowExpansion(entityToEdit);
           };

           $scope.gridOptions = {
               data: [],
               enableFiltering: true,
               columnDefs: columns,
               enablePagination: true,
               enablePaginationControls: false,
               paginationPageSizes: [5, 10, 15],
               enableHorizontalScrollbar: uiGridConstants.scrollbars.NEVER,
               enableVerticalScrollbar: uiGridConstants.scrollbars.NEVER,
               onRegisterApi: function (gridApi) {

                   gridApi.expandable.on.rowExpandedStateChanged($scope, function (row) {
                       //collapse the other rows
                       if (row.isExpanded) {
                           var rows = row.grid.rows;
                           angular.forEach(rows, function (value, key) {
                               if (value.isExpanded && row.uid != value.uid) {
                                   gridApi.expandable.toggleRowExpansion(value.entity);
                               }
                           });
                       }
                   });

                   $scope.gridApi = gridApi;
               },
               expandableRowTemplate: 'tmpl',
               //remove default expand buttons
               enableExpandableRowHeader: false,
               expandableRowHeight: 500,
               expandableRowScope: {
                   editFood: function (food) {

                       var editBlock = blockUI.instances.get($scope.editFoodBlockId);
                       editBlock.start();

                       foodService.editFood(food)
                           .then(function (responce) {
                               toaster.pop('success', GlobalResources.Success, $scope.editFoodResources.foodSaved);
                               var responceData = responce.data;
                               var foodGridData = $scope.gridOptions.data;
                               var entityToEdit = foodGridData.find(function (item) {
                                   return item.FoodId == responceData.FoodId;
                               });

                               entityToEdit.Name = responceData.Name;
                               entityToEdit.FoodType = responceData.FoodType;
                               entityToEdit.FoodTypeName = responceData.FoodTypeName;

                               editBlock.stop();
                       });
                   },
                   CollapseRow: function (row) {
                       $scope.gridApi.expandable.toggleRowExpansion(row.entity);
                   },
                   deleteFood: function (row) {

                   },
                   editFoodResources: $scope.editFoodResources,
                   foodTypes: foodTypes,
                   loadFoodIngredients: function (foodId) {
                       foodService.getFoodIngredients(foodId).then(
                           function (responce) {
                               var tableOptions = getFoodIngredientsTableOptions();
                               tableOptions.data = responce.data;
                           },
                           function (responce) {

                           });
                   },
                   ingredientsGridOptions: getIngredientsGridOptions(),
                   foodToEdit: {},
                   newFoodIngredient: {},
                   addIngredient: function () {
                       var foodId = this.foodToEdit.FoodId;
                       var foodIngredient = {
                           foodId: this.foodToEdit.FoodId,
                           ingredientId: this.newFoodIngredient.ingredient.IngredientId,
                           amount: this.newFoodIngredient.amount,
                           unitOfMeasure: this.newFoodIngredient.unitOfMeasure
                       };

                       foodService.addFoodingredient(foodIngredient).then(function (responce) {
                           var tableOptions = getFoodIngredientsTableOptions();
                           
                           tableOptions.data.push(responce.data);
                           console.log(tableOptions.data);
                       });
                   },
                   searchIngredients: function(searchTerm){
                       return foodService.searchIngredients(searchTerm)
                           .then(function (responce) {
                               return responce.data;
                           },
                           function (responce) {

                           });
                   },
                   //pagination: {}
               }
           };

           foodService.getAllFoods()
                      .then(function (responce) {
                               $scope.gridOptions.data = responce.data;
                               $scope.loading = false;
                           }, function (responce) {
                           });    

           $scope.createFood = function (food) {

               var createBlock = blockUI.instances.get($scope.newFoodBlockId);
               createBlock.start();

               foodService.createNewFood(food)
                        .then(function (responce) {
                            $scope.gridOptions.data.push(responce.data);
                            $scope.newFood = {};

                            createBlock.stop();
                            toaster.pop('success', GlobalResources.Success, $scope.newFoodResources.foodCreated);
                        }, function (responce) {

                        });
           };

           function getIngredientsGridOptions() {
               var gridColumns = [
                   {
                       field: 'IngredientId',
                       visible: false
                   },
                   {
                       field: 'FoodId',
                       visible: false
                   },
                   {
                       field: 'IngredientName',
                       displayName: 'Name',
                       filter: { condition: uiGridConstants.filter.CONTAINS, placeholder: 'contains' },
                       enableColumnMenu: false,
                       width: '70%'
                   },
                   {
                       field: 'Amount',
                       displayName: 'Amount',
                       enableColumnMenu: false,
                       width: '15%'
                   },
                   {
                       field: 'UnitOfMeasure',
                       displayName: 'UnitOfMeasure',
                       enableColumnMenu: false,
                       width: '15%'
                   }
               ];

               return {
                   data: [],
                   enableFiltering: false,
                   columnDefs: gridColumns,
                   enablePaginationControls: false,
                   paginationPageSizes: [5, 10, 15],
                   onRegisterApi: function (gridApi) {
                       $scope.gridOptions.expandableRowScope.pagination = gridApi.pagination;
                   }
               };
           };

           function getFoodIngredientsTableOptions() {
               return $scope.gridOptions.expandableRowScope.ingredientsGridOptions;
           };
       }]);