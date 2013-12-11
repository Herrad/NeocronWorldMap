window.onload = function () {
    var worldGrid = $('.world-grid'),
        cells = $('td', worldGrid);
    
    removeAnchorsAndBindClickEvents(cells);
};

function removeAnchorsAndBindClickEvents(cells) {

    cells.each(function (index, cell) {
        $('a', cell).remove();
        $(cell).bind('click', cellClicked);
    });
}

function cellClicked() {
    var cell = $(this),
        xcoordinate = cell.data("xcoordinate"),
        ycoordinate = cell.data("ycoordinate");
    
    $.ajax({
        url: "zone/partialdetails?xCoordinate=" + xcoordinate + "&yCoordinate=" + ycoordinate,
        success: function(result) {
            $('.zone-detail').html(result);
            $('.zone-detail').removeClass("hidden");
        }
    });
}