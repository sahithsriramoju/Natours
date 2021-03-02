(function ($) {

    angular.module('designer').requires.push('expander', 'sfSelectors');

    angular.module('designer').controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.itemType = 'Telerik.Sitefinity.DynamicTypes.Model.Tours.Tour';

        $scope.$watch('properties.SelectedItems.PropertyValue', function (newValue, oldValue) {
            if (newValue) {
                $scope.selectedItems = JSON.parse(newValue);
            }
        });
        $scope.$watch('selectedItems', function (newValue, oldValue) {
            if (newValue) {
                $scope.properties.SelectedItem.PropertyValue = JSON.stringify(newValue);
            }
        });
        $scope.$watch('properties.SelectedIds.PropertyValue', function (newValue, oldValue) {
            if (newValue) {
                $scope.ids = JSON.parse(newValue);
            }
        });
        $scope.$watch('ids', function (newValue, oldValue) {
            if (newValue) {
                $scope.properties.SelectedIds.PropertyValue = JSON.stringify(newValue);
            }
        });

        propertyService.get()
            .then(function (data) {
                if (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);

                    var selectedItemsIds = $.parseJSON($scope.properties.SelectedIds.PropertyValue || null);
                }
            },
            function (data) {
                $scope.feedback.showError = true;
                if (data)
                    $scope.feedback.errorMessage = data.Detail;
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });

    }]);
})(jQuery);