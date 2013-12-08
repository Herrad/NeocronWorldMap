window.onload = function () {
    var worldGrid = $('.world-grid'),
        cells = $('td', worldGrid);
    
    removeAnchorsAndBindClickEvents(cells);
}

function removeAnchorsAndBindClickEvents(cells) {

    cells.each(function (index, cell) {
        $('a', cell).remove();
        $(cell).bind('click', cellClicked);
    });
}

function cellClicked(cell) {
    $.ajax({
        url: "/zone/partialdetails?xCoordinate=10&yCoordinate=f",
        success: function(result) {
            $('.zone-detail').html(result);
        }
    });
}