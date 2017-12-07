angular.module('languageApp', [])
    .controller('languageController', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        
        $scope.init = function (languages) {
            $scope.availableLanguages = [];
            angular.forEach(languages, function (lang) {
                $scope.availableLanguages.push({ value: lang.cultureName, name: lang.languageName.toUpperCase() });
            });
        }
    }])
    .directive('languageSelect', function () {
        return {
            restrict: 'E',
            templateUrl: '/Assets/Templates/LanguageControlTemplate.html',
            scope: {                
                currentLanguage: '@',
                availableLanguages: '='
            },
            controller: ['$scope', '$window', '$location', function ($scope, $window, $location) {
                $scope.changeLang = function () {
                    $window.location.href = '/language/change?language=' + this.currentLanguage + '&returnUrl=' + $location.absUrl();
                };
            }]
        }
    });
