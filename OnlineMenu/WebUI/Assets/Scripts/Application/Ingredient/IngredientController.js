angular.module("IngredientApp")
       .controller("ingredientController", ["$scope", "ingredientService", 'uiGridConstants', function ($scope, ingredientService, uiGridConstants) {
            $scope.newIngredient = {};
            $scope.loading = true;

            var columns = [
                    {
                        field: 'IngredientId',
                        width: '15%',
                        enableColumnMenu: false
                    },
                    {
                        field: 'Name',
                        filter: { condition: uiGridConstants.filter.CONTAINS, placeholder: 'contains' },
                        enableColumnMenu: false
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
                angular.copy(entityToEdit, $scope.gridOptions.expandableRowScope.ingredientToEdit);
                $scope.gridApi.expandable.toggleRowExpansion(entityToEdit);
            };

            $scope.gridOptions = {
                width: '100%',
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
                expandableRowTemplate: '/Assets/Templates/IngredientTableItemTemplate.html',
                //remove default expand buttons
                enableExpandableRowHeader: false,
                expandableRowHeight: 200,
                expandableRowScope: {
                    Save: function (ingredient, row) {
                        ingredientService.editIngredient(ingredient)
                            .then(function (responce) {
                                $scope.gridApi.expandable.toggleRowExpansion(row.entity);
                                angular.copy(responce.data, row.entity);
                            }, function (responce) {
                                alert('error');
                            });
                    },
                    CollapseRow: function (row) {
                        $scope.gridApi.expandable.toggleRowExpansion(row.entity);
                    },
                    Delete: function (row) {
                        var entityToDelete = row.entity;
                        ingredientService.deleteIngredient(entityToDelete.IngredientId)
                            .then(function (responce) {
                                var data = $scope.gridOptions.data;
                                var indexToDelete = -1;
                                angular.forEach(data, function (item, index) {
                                    if (item.IngredientId == entityToDelete.IngredientId) {
                                        indexToDelete = index;
                                    }
                                });

                                if (indexToDelete >= 0) {
                                    data.splice(indexToDelete, 1);
                                }
                            },
                            function (responce) {
                                alert('error');
                            });
                    },
                    Resources: {
                        ingredient: GlobalResources.Ingredient,
                        save: GlobalResources.Save,
                        cancel: GlobalResources.Cancel,
                        remove: GlobalResources.Remove
                    },
                    ingredientToEdit: {}
                }
            };

            ingredientService.getAllIngredients()
                            .then(function (responce) {
                                $scope.gridOptions.data = responce.data;
                                $scope.loading = false;
                               // $scope.gridApi.core.notifyDataChange(uiGridConstants.dataChange.EDIT)
                            }, function (responce) {
                            });

            $scope.createIngredient = function (ingredient) {
                ingredientService.createIngredient(ingredient)
                         .then(function (responce) {
                                $scope.gridOptions.data.push(responce.data);
                                $scope.newIngredient = {};
                             }, function () { });
            };

}]);