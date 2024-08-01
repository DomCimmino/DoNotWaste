let selectedBuildingId;
let isBuildingSelected = false;

function updateGenerateButtonState() {
    if (isBuildingSelected) {
        $('#generateButton').removeClass('disabled');
    } else {
        $('#generateButton').addClass('disabled');
    }
}

function isValidURL(string) {
    try {
        new URL(string);
        return true;
    } catch (_) {
        return false;
    }
}

function loadBuildingUrl(data) {
    let element = document.getElementById("buildingUrl");
    
    if(isBuildingSelected){
        element.style.display = "block";
        element.innerHTML = "";
        element.innerHTML += `Navigate to <a href="${data.htmlUrl}" target="_blank">${data.htmlUrl}</a> to view building in the tool`;
    }else{
        element.style.display = "none";
    }
    
}

function loadDropdownValues(data) {
    let $buildingNumberDropdown = $('#assetScoreBuildings').next('.dropdown-menu');
    $buildingNumberDropdown.empty();
    $.each(data, function (index, item) {
        $buildingNumberDropdown.append(`<li><a class="dropdown-item" href="#" id="${item.id}">${item.name}</a></li>`);
    });
}

function appendColToRow(name, data, row){
    let colLabel = document.createElement("div");
    colLabel.className = "col-sm-3";
    colLabel.innerHTML = `<h6 class="mb-0">${name}</h6>`;

    row.appendChild(colLabel);

    let colValue = document.createElement("div");
    colValue.className = "col-sm-9 text-secondary";
    colValue.id = "propertyName";
    
    if (isValidURL(data)) {
        let link = document.createElement("a");
        link.href = data;
        link.textContent = data;
        link.target = "_blank";  // Open link in a new tab
        colValue.appendChild(link);
    } else {
        colValue.textContent = data;
    }
    row.appendChild(colValue);
}

function loadBuildingRecommendation(data) {
    let container = document.getElementById("recommendations");
    container.innerHTML = "";
    
    if(!isBuildingSelected){
        container.innerHTML = "<p>Please select building.</p>";
    }else{
        data.forEach(function(recommendation, index) {

            let row = document.createElement("div");
            row.className = "row";

            appendColToRow("Recommendation",recommendation.advice,row);
            appendColToRow("Cost",recommendation.cost,row);
            appendColToRow("Energy Savings",recommendation.energySavings,row);
            appendColToRow("Guide to upgrade",recommendation.upgradeGuide,row);

            container.appendChild(row);

            if (index < data.length - 1) {
                let hr = document.createElement("hr");
                container.appendChild(hr);
            }
        });
    }
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

$(document).ajaxStart(function () {
    $('#overlay').show();
}).ajaxStop(function () {
    $('#overlay').hide();
});


$(document).ready(function () {

    $('#assetScoreBuildings').next('.dropdown-menu').on('click', function (e) {
        e.preventDefault();
        selectedBuildingId = e.target.id;
        isBuildingSelected = true;
        $.getJSON('/AssetScore/LoadBuilding', {buildingId: selectedBuildingId}, function (data) {
            updateGenerateButtonState();
            loadBuildingUrl(data);
        });
        $.getJSON('/AssetScore/LoadBuildingRecommendations', function (data) {
            loadBuildingRecommendation(data);
        });
    });

    loadBuildingRecommendation();
    loadBuildingUrl();
    updateGenerateButtonState();
    $.getJSON('/AssetScore/LoadBuildings', function (data) {
        loadDropdownValues(data);
    });
    document.getElementById('generateButton').addEventListener('click', function () {
        $('#overlay').show();
        fetch('/AssetScore/LoadReport', {
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
                            renderPage(pdf, currentPage, canvas, context);
                        }
                    });

                    document.getElementById('nextPage').addEventListener('click', function () {
                        if (currentPage < totalPages) {
                            currentPage++;
                            renderPage(pdf, currentPage, canvas, context);
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
    