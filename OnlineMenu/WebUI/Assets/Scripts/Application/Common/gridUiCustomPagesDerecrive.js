angular.module('commonModule')
    .directive('gridUiCustomPages', function () {
        return {
            restrict: 'E',
            scope: {
                pagination: '=',

            },
            templateUrl: '/Assets/Templates/GridUiPagesTemplate.html',


            controller: ['$scope', function ($scope) {
                // $scope.$watch('pagination', function () {
                //    previousNextButton();
                //});

                $scope.pagesCount = 0;
                $scope.currentPage = 0;
                $scope.showPrevious = true;
                $scope.showNext = true;

                $scope.pages = [];

                //pages count
                $scope.$watch(function () {
                    return getTotalPages();
                },
                function (newValue, oldValue) {
                    previousNextButton();
                    $scope.pagesCount = newValue;

                    $scope.pages = [];

                    for (var i = 1; i <= newValue; i++) {
                        $scope.pages.push(i);
                    }
                });

                //current page
                $scope.$watch(function () {
                    return getPage();
                },
                function (newValue, oldValue) {
                    previousNextButton();
                    $scope.currentPage = newValue;
                });


                function getPage() {
                    return $scope.pagination ? $scope.pagination.getPage() : 1;
                }

                function getTotalPages() {
                    return $scope.pagination ? $scope.pagination.getTotalPages() : 1;
                }

                function previousNextButton() {

                    var currentPage = getPage();
                    var pagesNumber = getTotalPages();

                    if (currentPage == pagesNumber) {
                        $scope.showNext = false;
                    }
                    else {
                        $scope.showNext = true;
                    }

                    if (currentPage == 1) {
                        $scope.showPrevious = false;
                    }
                    else {
                        $scope.showPrevious = true;
                    }
                };
            }]
        }
    });