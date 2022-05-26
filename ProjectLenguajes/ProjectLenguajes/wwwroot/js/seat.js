

$(document).ready(function () {

    loadSeats();

    availabeSeat();

    // on seat booking function
    $('.seat').change(function () {
        if (this.checked) {
            var id = $(this).prop("id");
            bookingSeat.push(id);
            allCalculation();
        } else {
            var idName = $(this).prop("id");
            var index = bookingSeat.indexOf(idName);
            if (index > -1) {
                bookingSeat.splice(index, 1);
            }
            allCalculation();
        }
    });

});
function loadSeats(){

    var noOfSeats = 40; // not used for now
    var noOfRows = 5;
    var noOfColumns = 10;
    var bookedSeat = ['A1', 'A8', 'B2', 'A10', 'B8']; //if some seat was already booked
    var bookingSeat = []; // use for seat booking
    var ticket = [500, 900];
    var alpha = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']

    for (i = 0; i < noOfRows; i++) {
        $('#seating').append('<div class="div-row" id="row' + i + '"></div>');
        for (j = 1; j <= noOfColumns; j++) {
            var seat = '<div class="seat-checkbox">' +
                '<label style="font-size:1.5em">' +
                '<input type="checkbox" class="seat" id="' + alpha[i] + "" + j + '" value="">' +
                '<span class="cr"><span class="cr-icon ">' + alpha[i] + "" + j + '</span></span>' +
                '</label>' +
                '</div>';
            $('#row' + i).append(seat);
        }
    }



}

// seat and price calculation
function allCalculation() {
    if (bookingSeat.length > 0) {
        $('#bookingSeat').html("Total Seats :" + bookingSeat.length);
        $('#bookingPrice').html("<button class='btn btn-primary'>Pay Rs." + bookingPrice() + "</button>");
        $('#seat').html("Your Seats :" + bookingSeat);
    } else {
        $('#bookingSeat').html("");
        $('#bookingPrice').html("");
        $('#seat').html("");
    }
    availabeSeat();
}

//available seat counting 
function availabeSeat() {
    var availSeat = (noOfRows * noOfColumns) - bookedSeat.length - bookingSeat.length;
    $('#availSeat').html("Total Available Seat :" + availSeat);
}

//multi-price booking function
function bookingPrice() {
    var no = noOfRows / 2;
    var ticketPrice = 0;
    var row = Math.round(no);

    for (h = 0; h < bookingSeat.length; h++) {
        if (alpha.indexOf(bookingSeat[h].substring(0, 1)) >= row) {
            ticketPrice += ticket[0];
        } else {
            ticketPrice += ticket[1];
        }
    }
    return ticketPrice;
}
