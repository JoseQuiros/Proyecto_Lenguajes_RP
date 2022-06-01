
var price = 500;//This will come from database
var reservedSeats = []; //get reserved seats if any
var resvalues = Array.from(reservedSeats);



$('#idParkingSelection').change(function () {

    var idParking= $('#idParkingSelection').val();

    GetParkingSlotByParking(idParking);


});

function GetParkingSlotByParking(idParking) {

    
    $.ajax({
        url: "/ParkingSlot/GetParkingSlotByParking",
        type: "GET",
        data: { id: idParking },
        success: function (result) {


            var seats = new Array(result.length);
       

            $("#bus").empty();
            var i = seats.length;
            $.each(result, function (key, item) {

                seats[i] = document.createElement('DIV');
                seats[i].innerHTML = item.number;
                seats[i].setAttribute("id", item.idParkingSlot);
                seats[i].setAttribute("class", "numbers inline");

                document.getElementById('bus').append(seats[i]);

                if (reservedSeats.length > 0) {
                    for (var j = 0; j < reservedSeats.length; j++) {

                        if (seats[i].innerHTML === reservedSeats[j].innerHTML) {
                            seats[i].style.backgroundColor = "red";
                            seats[i].style.pointerEvents = "none";
                        }
                    }//for 


                }




            });

        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#result').text("Error en la conexión.");
            }
            $('#result').text("User not added");
            $('#result').css('color', 'red');
            $('#password').val('');
        }
    });
}

if (reservedSeats.length > 0) {
    for (var loop = 0; loop < reservedSeats.length; loop++) {
        reservedSeats[loop] = document.createElement('DIV');
        reservedSeats[loop].innerHTML = resvalues[loop];

    }
}

// alert(reservedSeats[0].innerHTML);

function loadSeats(seats) {
    $("#bus").empty();
    var i = seats.length;
    for (i; i > 0; i--) {
        seats[i] = document.createElement('DIV');
        seats[i].innerHTML = i;
        seats[i].setAttribute("id", i);
        seats[i].setAttribute("class", "numbers inline");

        document.getElementById('bus').prepend(seats[i]);

        if (reservedSeats.length > 0) {
            for (var j = 0; j < reservedSeats.length; j++) {

                if (seats[i].innerHTML === reservedSeats[j].innerHTML) {
                    seats[i].style.backgroundColor = "red";
                    seats[i].style.pointerEvents = "none";
                }
            }//for 


        }


    }
}


var selecteditems = new Array();
    document.getElementById('bus').addEventListener('click', function (e) {
    if (e.target !== e.currentTarget) {

        var clickeditem = e.target.id;



        if (!selecteditems.includes(clickeditem)) {
            if (selecteditems.length < 6) {
                selecteditems.push(clickeditem);
                document.getElementById('sseat').innerText = "Seat No: " + selecteditems;
                document.getElementById(clickeditem).style.backgroundColor = "blue";
                document.getElementById('error').innerText = "";
            }
            else {
                document.getElementById('error').innerText = "You cannot reserve more than 6 seats";
            }

        }

        else if (selecteditems.includes(clickeditem)) {
            const index = selecteditems.indexOf(clickeditem);
            if (index > -1) {
                selecteditems.splice(index, 1);
            }

            document.getElementById('sseat').innerText = "Seat No: " + selecteditems;
            document.getElementById(clickeditem).style.backgroundColor = "green";
            document.getElementById('error').innerText = "";
        }

        if (selecteditems.length === 0) {
            document.getElementById('price').innerText = "";
        }
        else {
            document.getElementById('price').innerText = "Total Seats:" + selecteditems.length + "\nTotal Price = " + selecteditems.length * price + " Rs";
        }

        if (selecteditems.length <= 0) {
            document.getElementById('next').style.visibility = "hidden";
        }
        else if (selecteditems.length > 0) {
            document.getElementById('next').style.visibility = "visible";
        }

        //      for(var i=30;i>0;i--)
        // {

        //   // if(seats[i].innerText !== clickeditem){
        //   //      seats[i].style.backgroundColor = "blue";   
        //   // }

        // }

    }
    e.stopPropagation();

    });




