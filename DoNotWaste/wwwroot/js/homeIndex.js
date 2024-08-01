function UpdateChart(data, ctx) {
    if (!ctx) {
        console.error("Element not found.");
        return;
    }

    let _labels = data.labels;
    let _chartData = data.data;

    new Chart(ctx,
        {
            type: "line",
            data: {
                labels: _labels,
                datasets: [{
                    label: "Consumption in kWh",
                    borderColor: "rgba(2, 117, 216, 1)",
                    data: _chartData,
                    borderWidth: 1
                }]
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
                        ticks: {
                            min: 0,
                            maxTicksLimit: 5
                        },
                        gridLines: {
                            display: true
                        }
                    }],
                },
                legend: {
                    display: true
                }
            }
        });
}

$(document).ajaxStart(function() {
    $('#overlay').show();
}).ajaxStop(function() {
    $('#overlay').hide();
});

$(document).ready(function () {
    let lineCtx = document.getElementById("lineChart");
    let barCtx = document.getElementById("barChart");

    $.getJSON('/Home/GetResidentialMeanConsumption', function (data) {
        UpdateChart(data, lineCtx);
    });
    $.getJSON('/Home/GetIndustrialMeanConsumption', function (data) {
        UpdateChart(data, barCtx);
    });
});
