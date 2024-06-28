function UpdateProperty(data){
    let $buildingNumberDropdown = $('#energyStarBuilding').next('.dropdown-menu');
    $buildingNumberDropdown.empty();
    $.each(data, function (index, item) {
        $buildingNumberDropdown.append(`<li><a class="dropdown-item" href="#" id="${item.id}">${item.name}</a></li>`);
    });
}

window.addEventListener('DOMContentLoaded', event => {
    let dataTable = document.getElementById('consumptionDataTable');
    if (dataTable) {
        new DataTable(dataTable);
    }
});

$(document).ajaxStart(function() {
    $('#overlay').show();
}).ajaxStop(function() {
    $('#overlay').hide();
});

$(document).ready(function() {
    $('#dataTable').DataTable();

    $('#buildingNumberDropdown').next('.dropdown-menu').on('click', function (e) {
        e.preventDefault();
        let selectedPropertyId = e.target.id;
    });

    $.getJSON('/PortfolioManager/LoadProperties', function (data) {
        UpdateProperty(data);
    });
});
