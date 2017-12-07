angular.module("FoodApp", ['ngTouch', 'ngAnimate', 'ngSanitize', 'ui.grid', 'ui.grid.pagination', 'ui.grid.expandable', 'ui.bootstrap', 'languageApp', 'toaster', 'blockUI', 'commonModule'])
    .config(function (blockUIConfig) {

        // Change the default overlay message
        blockUIConfig.message = GlobalResources.Loading;

        // Change the default delay to 100ms before the blocking is visible
        blockUIConfig.autoInjectBodyBlock = false;
        blockUIConfig.autoBlock = false;

    });