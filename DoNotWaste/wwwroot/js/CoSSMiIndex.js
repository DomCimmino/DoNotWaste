let lineChart;
let donutChart;
let rand = Math.random;

function UpdateChart(data, lineCtx) {

    if (!lineCtx) {
        console.error("Element not found.");
        return;
    }

    if (lineChart) {
        lineChart.destroy();
    }

    let labels = data[0].labels;
    let dataset = [];


    data.forEach(function (chartData) {
        dataset.push({
            label: `${chartData.buildingName} ${chartData.buildingTypeName} consumption in kWh`,
            borderColor: `rgb(${Math.floor(rand() * 256)}, ${Math.floor(rand() * 256)}, ${Math.floor(rand() * 256)})`,
            data: chartData.data,
            borderWidth: 1
        });
    });

    lineChart = new Chart(lineCtx, {
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

function UpdateConsumptionProgressBar(data) {
    let container = $('#device-consumption-container');
    container.empty();
    if (data.length === 0) {
        container.append('<p>No data available please select building type or building number.</p>');
    } else {
        let maxValue = Math.max(...data.map(x => x.value));
        $.each(data, function (index, item) {
            let percentage = Math.ceil((item.value / maxValue) * 100);
            let progressBarHtml = `
                                    <h4 class="small font-weight-bold">
                                        ${item.deviceName}
                                        <span class="float-right">${parseFloat(item.value.toFixed(2))} kWh</span>
                                    </h4>
                                    <div class="progress mb-4">
                                        <div class="progress-bar" role="progressbar"
                                             style="width: ${percentage}%; background-color: rgb(${Math.floor(rand() * 256)}, ${Math.floor(rand() * 256)}, ${Math.floor(rand() * 256)});"
                                             aria-valuenow="${percentage}" aria-valuemin="0" aria-valuemax="100">
                                        </div>
                                    </div>`;
            container.append(progressBarHtml);
        });
    }
}

function UpdateSourceEnergy(data, donutCtx) {
    let container = $('#device-photovoltaic-container');
    if (data.length === 0) {
        donutCtx.style.display = 'none';
        container.append('<p id="statement" style="display: block">No data available please select building type or building number.</p>');
    } else {
        document.getElementById("statement").style.display = 'none';
        donutCtx.style.display = 'block';

        if (!donutCtx) {
            console.error("Element not found.");
            return;
        }

        if (donutChart) {
            donutChart.destroy();
        }
        
        let dataset = [{
            data: data.data,
            backgroundColor: data.labels.map(() => {
                return `rgb(${Math.floor(Math.random() * 256)}, ${Math.floor(Math.random() * 256)}, ${Math.floor(Math.random() * 256)})`;
            }),
        }];
        
        console.log(data.labels);
        console.log(dataset);
        
        donutChart = new Chart(donutCtx, {
            type: "doughnut",
            data: {
                labels : data.labels,
                datasets : dataset
            },
            options: {
                maintainAspectRatio: false,
                tooltips: {
                    xPadding: 15,
                    yPadding: 15,
                    displayColors: false,
                    caretPadding: 10,
                },
                cutoutPercentage: 80,
            }
        });
    }
}

$(document).ajaxStart(function () {
    $('#overlay').show();
}).ajaxStop(function () {
    $('#overlay').hide();
});

$(document).ready(function () {
    let lineCtx = document.getElementById("buildingChart");
    let donutCtx = document.getElementById("photovoltaicProductionChart");
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
        $.getJSON('/CoSSMic/GetDeviceConsumptionData', {buildingTypeId: selectedBuildingTypeId}, function (data) {
            UpdateConsumptionProgressBar(data);
        });
        $.getJSON('/CoSSMic/GetSourceDataEnergy', {buildingTypeId: selectedBuildingTypeId}, function (data) {
            UpdateSourceEnergy(data, donutCtx);
        });
    });

    $('#buildingNumberDropdown').next('.dropdown-menu').on('click', function (e) {
        e.preventDefault();
        selectedBuildingTypeId = e.target.dataset.typeId;
        selectedBuildingNumberId = e.target.id;

        if (selectedBuildingTypeId && selectedBuildingNumberId) {
            $.getJSON('/CoSSMic/GetBuildingDataChart', {
                buildingTypeId: selectedBuildingTypeId,
                buildingNumberId: selectedBuildingNumberId
            }, function (data) {
                UpdateChart(data, lineCtx);
            });
            $.getJSON('/CoSSMic/GetDeviceConsumptionData', {
                buildingTypeId: selectedBuildingTypeId,
                buildingNumberId: selectedBuildingNumberId
            }, function (data) {
                UpdateConsumptionProgressBar(data);
            });
            $.getJSON('/CoSSMic/GetSourceDataEnergy', {
                buildingTypeId: selectedBuildingTypeId,
                buildingNumberId: selectedBuildingNumberId
            }, function (data) {
                UpdateSourceEnergy(data, donutCtx);
            });
        }
    });

    $.getJSON('/CoSSMic/GetBuildingsByType', function (data) {
        UpdateBuildings(data);
    });
    $.getJSON('/CoSSMic/GetBuildingDataChart', function (data) {
        UpdateChart(data, lineCtx);
    });
    $.getJSON('/CoSSMic/GetDeviceConsumptionData', function (data) {
        UpdateConsumptionProgressBar(data);
    });
    $.getJSON('/CoSSMic/GetSourceDataEnergy', function (data) {
        UpdateSourceEnergy(data, donutCtx);
    });
});