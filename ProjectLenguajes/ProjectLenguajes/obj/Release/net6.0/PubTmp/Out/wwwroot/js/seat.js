
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
                seats[i].setAttribute("IDparking", item.idParking);
                seats[i].setAttribute("IDtypeVehicle", item.idTypeVehicle);
                seats[i].setAttribute("Number", item.number);
                seats[i].setAttribute("PreferentialSlot", item.preferentialSlot);
                seats[i].setAttribute("State", item.state);
                seats[i].setAttribute("class", "numbers inline");

                document.getElementById('bus').append(seats[i]);


        
             
                    if (seats[i].getAttribute("PreferentialSlot") == "Y") {
                            seats[i].style.backgroundColor = "yellow";
                        

                    }
                    else
                    if (seats[i].getAttribute("State") == "O") {
                    seats[i].style.backgroundColor = "red";
                    seats[i].style.pointerEvents = "none";
                    }
                //pendiente validacion de campo de vehiculo

                
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




var selecteditems = new Array();
    document.getElementById('bus').addEventListener('click', function (e) {
    if (e.target !== e.currentTarget) {

        var clickeditem = e.target.id;



        if (!selecteditems.includes(clickeditem)) {//apenas se clickea
            if (selecteditems.length < 1) {
                selecteditems.push(clickeditem);
      
                document.getElementById(clickeditem).style.backgroundColor = "blue";
                $('#slotNumber').val(document.getElementById(clickeditem).getAttribute("Number"));
                $('#parkingName').val($("#idParkingSelection option:selected").text());
            } 
            else {
                document.getElementById('error').innerText = "You cannot reserve more than 6 seats";
            }

        }

        else if (selecteditems.includes(clickeditem)) { //desclickeo
            const index = selecteditems.indexOf(clickeditem);
            if (index > -1) {
                selecteditems.splice(index, 1);
            }

            if (document.getElementById(clickeditem).getAttribute("PreferentialSlot") == "Y") {
                document.getElementById(clickeditem).style.backgroundColor = "yellow";
                $('#slotNumber').val("");
                $('#parkingName').val("");

            } else {

                document.getElementById(clickeditem).style.backgroundColor = "green";
                $('#slotNumber').val("");
                $('#parkingName').val("");

            }

            
     
        }

        if (selecteditems.length === 0) {
       
          

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

    

    }
    e.stopPropagation();

    });




