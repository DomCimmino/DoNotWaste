function UpdateBuildings(data){
    let $buildingNumberDropdown = $('#buildingNumberDropdown').next('.dropdown-menu');
    $buildingNumberDropdown.empty();
    $.each(data, function (index, item) {
        $buildingNumberDropdown.append('<li><a class="dropdown-item" href="#">' + item.number + '</a></li>');
    });
}

$(document).ready(function () {
    $('.dropdown-item[data-type-id]').on('click', function (e) {
        e.preventDefault();
        let buildingTypeId = $(this).data('type-id');
        $.getJSON('/CoSSMic/GetBuildingsByType', { buildingTypeId: buildingTypeId }, function (data) {
            UpdateBuildings(data);
        });
    });

    
    $.getJSON('/CoSSMic/GetBuildingsByType', function (data) {
        UpdateBuildings(data);
    });
});