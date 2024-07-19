let propertyDataTable;
let selectedPropertyId;
let isPropertySelected = false;

function updateGenerateButtonState() {
    if (isPropertySelected) {
        $('#generateButton').removeClass('disabled');
    } else {
        $('#generateButton').addClass('disabled');
    }
}

function updatePropertiesDropdown(data) {
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

function renderPage(pdf, pageNum, canvas, context) {
    pdf.getPage(pageNum).then(function (page) {
        const viewport = page.getViewport({scale: 1.5});
        canvas.height = viewport.height;
        canvas.width = viewport.width;

        const renderContext = {
            canvasContext: context,
            viewport: viewport
        };
        const renderTask = page.render(renderContext);
        renderTask.promise.then(function () {
            console.log('Page rendered');
            document.getElementById('pageNum').textContent = pageNum;
        });
    });
}

function updateProperty(data) {
    $("#propertyName").text(data.name);
    $("#primaryFunction").text(data.primaryFunction);
    $("#address").text(data.address);
    $("#builtYear").text(data.yearBuilt);
}

async function fetchData(url) {
    try {
        const response = await fetch(url);
        const data = await response.json();
        const lat = data[0].lat;
        const lon = data[0].lon;
        const placeRank = data[0].place_rank;
        return { lat, lon, placeRank };
    } catch (err) {
        console.log(err);
    }
}

function updateMap(address, propertyName) {
    let parts = address.split(',');
    let result = parts[0].replace(" ", "+") + "+" + parts[1].trim();
    let url = "https://nominatim.openstreetmap.org/search?format=json&limit=3&q=" + result;
    
    fetchData(url).then(({ lat, lon, placeRank }) => {
        const map = L.map('map').setView([lat, lon], placeRank);

        L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 19,
            attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
        }).addTo(map);
        
        L.marker([lat, lon],{
            color: 'red',
            title: propertyName
        }).addTo(map);
    });
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
        updateGenerateButtonState();
        $.getJSON('/PortfolioManager/LoadProperty', {propertyId: selectedPropertyId}, function (data) {
            updateProperty(data);
            updateMap(data.address, data.name);
        });
        $.getJSON('/PortfolioManager/LoadPropertyData', {propertyId: selectedPropertyId}, function (data) {
            updatePropertyData(data);
        });
    });

    updateGenerateButtonState();
    $.getJSON('/PortfolioManager/LoadProperties', function (data) {
        updatePropertiesDropdown(data);
    });
    $.getJSON('/PortfolioManager/LoadPropertyData', {propertyId: selectedPropertyId}, function (data) {
        updatePropertyData(data);
    });

    document.getElementById('generateButton').addEventListener('click', function () {
        $('#overlay').show();
        fetch('/PortfolioManager/LoadReport', {
            method: 'GET'
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.blob();
            })
            .then(blob => {
                const url = window.URL.createObjectURL(blob);
                const loadingTask = pdfjsLib.getDocument(url);
                loadingTask.promise.then(function (pdf) {
                    console.log('PDF loaded');
                    const canvas = document.getElementById('pdfViewer');
                    const context = canvas.getContext('2d');
                    let currentPage = 1;
                    const totalPages = pdf.numPages;
                    document.getElementById('pageCount').textContent = totalPages;

                    renderPage(pdf, currentPage, canvas, context);

                    document.getElementById('prevPage').addEventListener('click', function () {
                        if (currentPage > 1) {
                            currentPage--;
                            renderPage(currentPage);
                        }
                    });

                    document.getElementById('nextPage').addEventListener('click', function () {
                        if (currentPage < totalPages) {
                            currentPage++;
                            renderPage(currentPage);
                        }
                    });

                    const downloadButton = document.getElementById('downloadPdfButton');
                    downloadButton.onclick = function () {
                        fetch(url)
                            .then(response => response.blob())
                            .then(blob => {
                                const blobUrl = URL.createObjectURL(blob);
                                const a = $('<a style="display: none;"></a>').attr('href', blobUrl).attr('download', 'report.pdf');
                                $('body').append(a);
                                a[0].click();
                                a.remove();
                                URL.revokeObjectURL(blobUrl);
                            })
                    };

                    $('#pdfModal').modal('show');
                }, function (reason) {
                    console.error(reason);
                });
            })
            .catch(error => {
                console.error('There was a problem with the fetch operation:', error);
            })
            .finally(() => {
                $('#overlay').hide();
            });
    });
});

