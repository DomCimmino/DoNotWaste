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

function renderPage(pdf, pageNum, canvas, context) {
    pdf.getPage(pageNum).then(function(page) {
        const viewport = page.getViewport({ scale: 1.5 });
        canvas.height = viewport.height;
        canvas.width = viewport.width;

        const renderContext = {
            canvasContext: context,
            viewport: viewport
        };
        const renderTask = page.render(renderContext);
        renderTask.promise.then(function() {
            console.log('Page rendered');
            document.getElementById('pageNum').textContent = pageNum;
        });
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
        $.getJSON('/PortfolioManager/LoadPropertyData', {propertyId: selectedPropertyId}, function (data) {
            updatePropertyData(data);
        });
    });

    updateGenerateButtonState();
    $.getJSON('/PortfolioManager/LoadProperties', function (data) {
        updateProperty(data);
    });
    $.getJSON('/PortfolioManager/LoadPropertyData', function (data) {
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
                loadingTask.promise.then(function(pdf) {
                    console.log('PDF loaded');
                    const canvas = document.getElementById('pdfViewer');
                    const context = canvas.getContext('2d');
                    let currentPage = 1;
                    const totalPages = pdf.numPages;
                    document.getElementById('pageCount').textContent = totalPages;

                    renderPage(pdf, currentPage, canvas, context);

                    document.getElementById('prevPage').addEventListener('click', function() {
                        if (currentPage > 1) {
                            currentPage--;
                            renderPage(currentPage);
                        }
                    });

                    document.getElementById('nextPage').addEventListener('click', function() {
                        if (currentPage < totalPages) {
                            currentPage++;
                            renderPage(currentPage);
                        }
                    });
                    
                    const downloadButton = document.getElementById('downloadPdfButton');
                    downloadButton.onclick = function() {
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
                }, function(reason) {
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

