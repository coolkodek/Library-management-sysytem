app.controller("PieController", function ($scope, CustomerService, $routeParams) {

    $scope.customers = [];
    $scope.statecount = [];
    $scope.districtcount = [];
    $scope.talukacount = [];




    CustomerService.getcustomers(function (res) {



        $scope.customers = res.data;
        angular.forEach($scope.customers, function (value, key) {

            if (findIndexByKeyValue($scope.statecount, "name", value.state) != null) {
                $scope.statecount[findIndexByKeyValue($scope.statecount, "name", value.state)]["y"] = parseInt($scope.statecount[findIndexByKeyValue($scope.statecount, "name", value.state)]["y"]) + 1;
            }
            else {
                $scope.statecount.push({ 'name': value.state, 'y': 1 });
            }

        });


        debugger;

        if (localStorage.getItem("dtype") == "district") {


            angular.forEach($scope.customers, function (value, key) {
                if (value.state == localStorage.getItem("dvalue")) {
                    if (findIndexByKeyValue($scope.districtcount, "name", value.district) != null) {
                        $scope.districtcount[findIndexByKeyValue($scope.districtcount, "name", value.district)]["y"] = parseInt($scope.districtcount[findIndexByKeyValue($scope.districtcount, "name", value.district)]["y"]) + 1;
                    }
                    else {
                        $scope.districtcount.push({ 'name': value.district, 'y': 1 });
                    }
                }
            });



        }




        if (localStorage.getItem("dtype") == "taluka") {

            angular.forEach($scope.customers, function (value, key) {
                if (value.district == localStorage.getItem("dvalue")) {
                    if (findIndexByKeyValue($scope.talukacount, "name", value.taluka) != null) {
                        $scope.talukacount[findIndexByKeyValue($scope.talukacount, "name", value.taluka)]["y"] = parseInt($scope.talukacount[findIndexByKeyValue($scope.talukacount, "name", value.taluka)]["y"]) + 1;
                    }
                    else {
                        $scope.talukacount.push({ 'name': value.taluka, 'y': 1 });
                    }
                }
            });



        }

        debugger;



        if (localStorage.getItem("dtype") == "district") {

            debugger;
            //////////////////////////////////////////////////
            $(function () {

                $(document).ready(function () {

                    // Build the chart
                    $('#container').highcharts({
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: ''
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: false
                                },
                                showInLegend: true
                            }
                        },
                        series: [{
                            name: 'Brands',
                            colorByPoint: true,
                            data: $scope.districtcount
                        }]
                    });
                });
            });
            //////////////////////////////////////////////////

        }
        else if (localStorage.getItem("dtype") == "taluka") {

            debugger;
            //////////////////////////////////////////////////
            $(function () {

                $(document).ready(function () {

                    // Build the chart
                    $('#container').highcharts({
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: ''
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: false
                                },
                                showInLegend: true
                            }
                        },
                        series: [{
                            name: 'Brands',
                            colorByPoint: true,
                            data: $scope.talukacount
                        }]
                    });
                });
            });
            //////////////////////////////////////////////////
        }
        else {
            debugger;
            //////////////////////////////////////////////////
            $(function () {

                $(document).ready(function () {

                    // Build the chart
                    $('#container').highcharts({
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: ''
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: false
                                },
                                showInLegend: true
                            }
                        },
                        series: [{
                            name: 'Brands',
                            colorByPoint: true,
                            data: $scope.statecount
                        }]
                    });
                });
            });
            //////////////////////////////////////////////////

        }




    });




    function findIndexByKeyValue(obj, key, value) {
        for (var i = 0; i < obj.length; i++) {
            if (obj[i][key] == value) {
                return i;
            }
        }
        return null;
    }








});