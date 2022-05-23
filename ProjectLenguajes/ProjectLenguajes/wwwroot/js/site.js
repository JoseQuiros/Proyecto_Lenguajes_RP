
$(document).ready(function () {
    GetTypes();
    GetVehicles();
    LoadUsers();
    LoadVehicles();
    //LoadClients();
    
    $(document).on('submit', '#user-entry-form', function () {

        if ($('#id').val() !== null) {
      

            Add();
        }else {

            Update();
        }
        return false;
    });
    //$('#vehicle-entry-form').click(function () {
    //    AddVehicle();
    //});

    $(document).on('submit', '#vehicle-entry-form', function () {
        //AddVehicle();
        if ($('#id').val() !== null) {
           
            AddVehicle();
        } else {

            //Update();
        }
        return false;
    });
    $(document).on('submit', '#client-entry-form', function () {
        //AddVehicle();
        if ($('#id').val() !== null) {

            AddClient();
        } else {

            //Update();
        }
        return false;
    });
    //$(function () {
    //    $(".button").click(function () {
    //        // validate and process form here
    //    });
    //});

});


function Add() {
    var user = {
       idRol: $('#idRol').val(),
        name: $('#name').val(),
        dni: $('#dni').val(),
        age: parseInt( $('#age').val()),
        telephone:$('#telephone').val(),
        email: $('#email').val(),
        password: $('#password').val(),

    };

    
    if (user != null) {

        $.ajax({
            url: "/Home/Insert",
            data: JSON.stringify(user), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                // alert("resultado: "+result);
                $('#result').text("Added successfully");
                //document.getElementById("result").style.color = "green";
                $('#result').css('color', 'green');
                $('#name').val('');
                $('#email').val('');
                $('#dni').val('');
                $('#age').val('');
                $('#telephone').val('');
                $('#password').val('');
                $('#idRol').val($("#rol option:first").val());
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


function LoadUsers() {

    $.ajax({
        url: "/Home/GetAllUsers",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {

                html += '<tr>';
                html += '<td>' + item.idUser + '</td>';
                html += '<td>' + item.idRol+ '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.dni + '</td>';
                html += '<td>' + item.age + '</td>';
                html += '<td>' + item.telephone + '</td>';
                html += '<td>' + item.email + '</td>';
                html += '<td>' + item.password + '</td>';
                //html += '<td><a href="#about" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="Delete(' + item.id + ')">Delete</button></td>';
                html += '</tr>';
            });

            $('#user-tbody').html(html); 
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });

}


function Clear() {


}


function LogIn() {
          var user = {
              idRol: 1,
              name: "x",
              dni: "x",
              age: 1,
              telephone: "x",
              Email: document.getElementById("cf-email").value,
              Password: document.getElementById("cf-password").value

        };
        $.ajax({
            url: "/Home/Login",
            data: JSON.stringify(user), //onverte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result == "Authenticated") {
                    $('#result').text("logged successfully");
                    $('#result').css('color', 'green');
                } else if (result == "Incorrect") {
                    $('#result').text("Password Incorrect");
                    $('#result').css('color', 'red');
                    $('#password').val('');
                } else {

                    $('#result').text("User no registered");
                    $('#result').css('color', 'red');

                }

            },
            error: function (errorMessage) {

                $('#result').text("Boom");
                $('#result').css('color', 'red');
                $('#password').val('');
            }
        });

    
}


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

    $.ajax({
        url: "/TypeVehicle/Get",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //llenar el dropdowns (select)
            var html = '';
            $.each(result, function (key, item) {
                html += '<option value="' + item.idType + '" id="' + item.idType + '">' + item.name + '</option>';
            });
            $('#types').append(html);

        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });
}





function AddClient() {
    var client = {
        // idVehicle: $('#idVehicle').val(),
        idVehicle: parseInt($('#idVehicle').val()),
        name: $('#name').val(),
        dni: $('#dni').val(),
        age: parseInt($('#age').val()),
        telephone: $('#telephone').val(),
        email: $('#email').val(),
        password: $('#password').val(),


    };

    if (client != null) {

        $.ajax({
            url: "/Client/InsertClient",
            data: JSON.stringify(client), //onverte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                //LoadVehicles();
                // alert("resultado: "+result);
                $('#result').text("Added successfully");
                //document.getElementById("result").style.color = "green";
                $('#result').css('color', 'green');
                // $('#idRol').val($("#rol option:first").val());
               // $('#major').val(result.major.id);
                $('#idVehicle').val('');
                $('#user').val(result.user.name);
                $('#user').val(result.user.dni);
                $('#user').val(result.user.age);
                $('#user').val(result.user.telephone);
                $('#user').val(result.user.email);
                $('#user').val(result.user.password);
              

                //LoadUsers();
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


function LoadClients() {

    $.ajax({
        url: "/Home/GetAllClients",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {

                html += '<tr>';
                html += '<td>' + item.idClient + '</td>';
                html += '<td>' + item.idVehicle + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.dni + '</td>';
                html += '<td>' + item.age + '</td>';
                html += '<td>' + item.telephone + '</td>';
                html += '<td>' + item.email + '</td>';
                html += '<td>' + item.password + '</td>';
                html += '<td>' + item.idRol + '</td>';
                html += '<td>' + item.state + '</td>';
                //html += '<td><a href="#about" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="Delete(' + item.id + ')">Delete</button></td>';
                html += '</tr>';
            });

            $('#clients-tbody').html(html);
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });

}

function GetVehicles() {

    $.ajax({
        url: "/Home/GetAllVehicles",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //llenar el dropdowns (select)
            var html = '';
            $.each(result, function (key, item) {
                html += '<option value="' + item.idVehicle + '" id="' + item.idVehicle + '">' + item.register + '</option>';
            });
            $('#register_v').append(html);

        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });
}