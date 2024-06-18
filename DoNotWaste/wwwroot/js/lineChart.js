$(document).ready(function () {

    let lineCtx = document.getElementById("lineChart");

    $.ajax({
        type: "POST",
        url: "/Home/GetConsumption",
        data: "",
        contentType: "application/json; charset=utf8",
        dataType: "json",
        success: OnSuccess,
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("Error retrieving data:", textStatus, errorThrown);
        }
    })

    function OnSuccess(data) {
        if (!lineCtx) {
            console.error("Element not found.");
            return;
        }
        let _labels = data[0];
        let _chartData = data[1];

        new Chart(lineCtx,
            {
                type: "line",
                data: {
                    labels: _labels,
                    datasets: [{
                        label: "Monthly Consumption in kWh",
                        backgroundColor: "rgba(2,117,216,1)",
                        borderColor: "rgba(2,117,216,1)",
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
                                max: 15000,
                                maxTicksLimit: 5
                            },
                            gridLines: {
                                display: true
                            }
                        }],
                    },
                    legend: {
                        display: false
                    }
                }
            });
    }
});
