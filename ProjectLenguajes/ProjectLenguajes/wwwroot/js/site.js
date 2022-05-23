/*

I built this login form to block the front end of most of my freelance wordpress projects during the development stage.

This is just the HTML / CSS of it but it uses wordpress's login system.

Nice and Simple

*/
// Write your JavaScript code.
$(document).ready(function () {



});


function Add() {



}

function Clear() {


}


<<<<<<< Updated upstream
function Login(emailUser) {
   
    $.ajax({
        url: "/User/GetByEmail",
        type: "GET",
        data: { email: emailUser },
        success: function (result) {

        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
            }
=======
function LogIn() {

    var email1 = document.getElementById("cf-email").value;
    var password1 = document.getElementById("cf-password").value;
  

        $.ajax({
            url: "/User/Login",
            data: {
                email: email1, password: password1
            },
            type: "GET",
        success: function (result) {
            if (result == "Authenticated") {
                $('#result').text("logged successfully");
                $('#result').css('color', 'green');
            } else if (result == "Failed") {
                $('#result').text("User not register");
                $('#result').css('color', 'red');
                $('#password').val('');
            } else {

                $('#result').text("User not logged");
                $('#result').css('color', 'red');

            }

            /Set the value in a local storage object
            localStorage.setItem('email', email1);

            //Get the value from storage object
          

        },
        error: function (errorMessage) {
      
            $('#result').text("Boom");
            $('#result').css('color', 'red');
            $('#password').val('');
>>>>>>> Stashed changes
        }
    });

}


<<<<<<< Updated upstream
=======

function Update() {

}


function AddVehicle() {
    var vehicle = {
        // idVehicle: $('#idVehicle').val(),
        idType: parseInt($('#types').val()),
        brand: $('#brand').val(),
        model: $('#model').val(),
        color: $('#color').val(),
        year: parseInt($('#year').val()),
        register: $('#register').val(),
        description: $('#description').val(),
    

    };

    if (vehicle != null) {

        $.ajax({
            url: "/Vehicle/InsertVehicle",
            data: JSON.stringify(vehicle), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                LoadVehicles();
                // alert("resultado: "+result);
                $('#result').text("Added successfully");
                //document.getElementById("result").style.color = "green";
                $('#result').css('color', 'green');
               // $('#idRol').val($("#rol option:first").val());
              
                $('#idType').val($("#rol option:first").val());
                $('#brand').val('');
                $('#model').val('');
                $('#color').val('');
                $('#year').val('');
                $('#register').val('');
                $('#description').val('');
            
                LoadUsers();
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
}


function LoadVehicles() {

    $.ajax({
        url: "/Home/GetAllVehicles",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {

                html += '<tr>';
                html += '<td>' + item.idvehicle + '</td>';
                html += '<td>' + item.idtype + '</td>';
                html += '<td>' + item.brand + '</td>';
                html += '<td>' + item.model + '</td>';
                html += '<td>' + item.color + '</td>';
                html += '<td>' + item.year + '</td>';
                html += '<td>' + item.register + '</td>';
                html += '<td>' + item.description + '</td>';
                //html += '<td><a href="#about" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="Delete(' + item.id + ')">Delete</button></td>';
                html += '</tr>';
            });

            $('#vehicle-tbody').html(html);
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });

}

function GetTypes() {
>>>>>>> Stashed changes

function Update() {

}
