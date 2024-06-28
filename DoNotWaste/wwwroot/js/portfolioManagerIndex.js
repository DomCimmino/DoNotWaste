let propertyDataTable;
let selectedPropertyId;
let isPropertySelected = false;

function updateButtonState() {
    if (isPropertySelected) {
        $('#viewReportButton').removeClass('disabled');
    } else {
        $('#viewReportButton').addClass('disabled');
    }
}

function updateProperty(data) {
    let $buildingNumberDropdown = $('#energyStarProperties').next('.dropdown-menu');
    $buildingNumberDropdown.empty();
    $.each(data, function (index, item) {
        $buildingNumberDropdown.append(`<li><a class="dropdown-item" href="#" id="${item.id}">${item.name}</a></li>`);
    });
}

function updatePropertyData(data) {
    if (propertyDataTable) {
        propertyDataTable.destroy();
    }
    propertyDataTable = $('#consumptionDataTable').DataTable();
    if (data.length === 0) return;
    let $tableBody = $('.tableBody');
    $tableBody.empty();
    let rows = data.map(item => [
        item.usage + " kWh",
        "$ " + item.cost,
        item.startDate,
        item.endDate
    ]);
    propertyDataTable.rows.add(rows).draw();
}

$(document).ajaxStart(function () {
    $('#overlay').show();
}).ajaxStop(function () {
    $('#overlay').hide();
});

$(document).ready(function () {

    $('#energyStarProperties').next('.dropdown-menu').on('click', function (e) {
        e.preventDefault();
        selectedPropertyId = e.target.id;
        isPropertySelected = true;
        updateButtonState();
        $.getJSON('/PortfolioManager/LoadPropertyData', {propertyId: selectedPropertyId}, function (data) {
            updatePropertyData(data);
        });
    });

    updateButtonState()
    $.getJSON('/PortfolioManager/LoadProperties', function (data) {
        updateProperty(data);
    });
    $.getJSON('/PortfolioManager/LoadPropertyData', function (data) {
        updatePropertyData(data);
    });
});

