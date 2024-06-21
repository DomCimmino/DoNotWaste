let currentChart;

function UpdateChart(data, lineCtx) {

    if (!lineCtx) {
        console.error("Element not found.");
        return;
    }

    if (currentChart) {
        currentChart.destroy();
    }

    let labels = data[0].labels;
    let dataset = [];
    let rand = Math.random;

    data.forEach(function (chartData) {
        dataset.push({
            label: `${chartData.buildingName} ${chartData.buildingTypeName} consumption in kWh`,
            borderColor: `rgb(${Math.floor(rand() * 256)}, ${Math.floor(rand() * 256)}, ${Math.floor(rand() * 256)})`,
            data: chartData.data,
            borderWidth: 1
        });
    });

    console.log(dataset);

    currentChart = new Chart(lineCtx, {
        type: "line",
        data: {
            labels: labels,
            datasets: dataset
        },
        options: {
            scales: {
                xAxes: [{
                    time: {
                        unit: 'month'
                    },
                    gridLines: {
                        display: false
                    },
                    ticks: {
                        maxTicksLimit: 6
                    }
                }],
                yAxes: [{
                    type: 'logarithmic',
                    ticks: {
                        callback: function (value, index, values) {
                            return Number(value.toString());
                        },
                        min: 1,
                        maxTicksLimit: 10,
                    }
                }],
                legend: {
                    display: true
                }
            }
        }
    });
}

function UpdateBuildings(data) {
    let $buildingNumberDropdown = $('#buildingNumberDropdown').next('.dropdown-menu');
    $buildingNumberDropdown.empty();
    $.each(data, function (index, item) {
        $buildingNumberDropdown.append(`<li><a class="dropdown-item" href="#" id="${item.id}" data-type-id="${item.buildingTypeId}">${item.number}</a></li>`);
    });
}

$(document).ready(function () {
    let lineCtx = document.getElementById("buildingChart").getContext('2d');
    let selectedBuildingTypeId;
    let selectedBuildingNumberId;
    
    $('.dropdown-item[data-type-id]').on('click', function (e) {
        e.preventDefault();
        selectedBuildingTypeId = $(this).data('type-id');
        
        $.getJSON('/CoSSMic/GetBuildingsByType', {buildingTypeId: selectedBuildingTypeId}, function (data) {
            UpdateBuildings(data);
        });
        $.getJSON('/CoSSMic/GetBuildingDataChart', {buildingTypeId: selectedBuildingTypeId}, function (data) {
            UpdateChart(data, lineCtx);
        });
    });

    $('#buildingNumberDropdown').next('.dropdown-menu').on('click', function (e) {
        console.log(e);
        e.preventDefault();
        selectedBuildingTypeId = e.target.dataset.typeId;
        selectedBuildingNumberId = e.target.id;
        
        console.log(selectedBuildingTypeId);
        console.log(selectedBuildingNumberId);
        
        if (selectedBuildingTypeId && selectedBuildingNumberId) {
            $.getJSON('/CoSSMic/GetBuildingDataChart', {
                buildingTypeId: selectedBuildingTypeId,
                buildingNumberId: selectedBuildingNumberId
            }, function (data) {
                UpdateChart(data, lineCtx);
            });
        }
    });

    $.getJSON('/CoSSMic/GetBuildingsByType', function (data) {
        UpdateBuildings(data);
    });
    $.getJSON('/CoSSMic/GetBuildingDataChart', function (data) {
        UpdateChart(data, lineCtx);
    });
});