
$(document).ready(function () {
    GetTypes();
    GetVehicles();
    GetParkings();
    LoadUsers();
    LoadVehicles();
    LoadClients();
    LoadParkings();
    LoadParkingSlot()
    
    $(document).on('submit', '#user-entry-form', function () {

        if ($('#id').val() !== null) {
      

            Add();
        }else {

            Update();
        }
        return false;
    });

    $(document).on('submit', '#vehicle-entry-form', function () {
  
        if ($('#id').val() !== null) {
           
            AddVehicle();
        } else {

            UpdateVehicle();
        }
        return false;
    });
    $(document).on('submit', '#client-entry-form', function () {
        
        if ($('#id').val() !== null) {

            AddClient();
        } else {

            
        }
        return false;
    });



    $(document).on('submit', '#parking-entry-form', function () {
        
        if ($('#id').val() !== null) {

            AddParking();
        } else {

            UpdateParking();
        }
        return false;
    });


    $(document).on('submit', '#parkingSlot-entry-form', function () {
       
        if ($('#id').val() !== null) {

            AddParkingSlot();
        } else {

            UpdateParkingSlot();
        }
        return false;
    });






});

//----------------------- User ------------------------------
function Add() {
    var user = {
       idRol: $('#idRol').val(),
        name: $('#name').val(),
        dni: $('#dni').val(),
        age: parseInt( $('#age').val()),
        telephone:$('#telephone').val(),
        email: $('#email').val(),
        password: $('#password').val()
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
                html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalUser" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="Delete(' + item.id + ')">Delete</button></td>';
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
            if (result.result == "Redirect") {

                $('#result').text("logged successfully");
                $('#result').css('color', 'green');

                window.location = result.url;
                alert(HttpContextAccessor.HttpContext.Session.GetString("UserEmail"));

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
    var student = {
        idUser: $('#idUserModal').val(),
        idRol: $('#idRolModal').val(),
        name: $('#nameModal').val(),
        dni: $('#dniModal').val(),
        age: parseInt($('#ageModal').val()),
        telephone: $('#telephoneModal').val(),
        email: $('#emailModal').val(),
        password: $('#passwordModal').val(),

    };

    if (student != null) {

        $.ajax({
            url: "/User/Update",
            data: JSON.stringify(student), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#modalResult').text("Updated successfully");
                $('#modalResult').css('color', 'green');
                //$('#name').val('');
                //$('#email').val('');
                //$('#password').val('');
                //$('#major').val($("#major option:first").val());
                LoadStudents();
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

//----------------------- Vehicle ------------------------------
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
                html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalVehicle" onclick="GetVehicleById(\'' + item.idvehicle + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="Delete(' + item.id + ')">Delete</button></td>';
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
            $('#typesModal').append(html);
            $('#idTypeVehicle').append(html);
            $('#idTypeVehicleModal').append(html);

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
                html += '<option value="' + item.idvehicle + '" id="' + item.idvehicle + '">' + item.register + '</option>';
            });
            $('#register_v').append(html);
            $('#register_vModal').append(html);

        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });
}


function UpdateVehicle() {
    var vehicle = {
        idVehicle: $('#idVehicleModal').val(),
        idType: parseInt($('#typesModal').val()),
        brand: $('#brandModal').val(),
        model: $('#modelModal').val(),
        color: $('#colorModal').val(),
        year: parseInt($('#yearModal').val()),
        register: $('#registerModal').val(),
        description: $('#descriptionModal').val(),
       

    };

    if (vehicle != null) {

        $.ajax({
            url: "/Vehicle/UpdateVehicle",
            data: JSON.stringify(vehicle), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#modalResult').text("Updated successfully");
                $('#modalResult').css('color', 'green');
              
                LoadVehicles();
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

function GetVehicleById(idVehicle) {

    var id = "";
    $.ajax({
        url: "/Vehicle/GetVehicleById",
        type: "GET",
        data: { id: idVehicle },
        success: function (result) {
            $('#idVehicleModal').val(result.idvehicle);
            $('#typesModal').val(result.idtype);
            $('#brandModal').val(result.brand);
            $('#modelModal').val(result.model);
            $('#colorModal').val(result.color);
            $('#yearModal').val(result.year);
            $('#registerModal').val(result.register);
            $('#descriptionModal').val(result.description);



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

//----------------------- Clients ------------------------------
function AddClient() {
    var client = {
        idVehicle: parseInt($('#register_v').val()),
        name: $('#nameClient').val(),
        dni: $('#dniClient').val(),
        age: parseInt($('#ageClient').val()),
        telephone: $('#telephoneClient').val(),
        email: $('#emailClient').val(),
        password: $('#passwordClient').val()
    };

    if (client != null) {

        $.ajax({
            url: "/Client/InsertClient",
            data: JSON.stringify(client), //onverte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#result').text("Added successfully");
                $('#result').css('color', 'green');
                $('#register_v').val($("#name option:first").val());
                $('#nameClient').val('');
                $('#dniClient').val('');
                $('#ageClient').val('');
                $('#telephoneClient').val('');
                $('#emailClient').val('');
                $('#passwordClient').val('');
                LoadClients();
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
                html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalClient" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="Delete(' + item.id + ')">Delete</button></td>';
                html += '</tr>';
            });
            $('#client-tbody').html(html);
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });

}

//----------------------- Parking ------------------------------
function LoadParkings() {

    $.ajax({
        url: "/Parking/GetAllParkings",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {

                html += '<tr>';
                html += '<td>' + item.idParking + '</td>';
                html += '<td>' + item.parkingName + '</td>';
                //html += '<td><a href="#about" onclick="GetParkingByID(\'' + item.idParking + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalParking" onclick="GetParkingById(\'' + item.idParking + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="Delete(' + item.id + ')">Delete</button></td>';
                html += '</tr>';
            });
            $('#parking-tbody').html(html);
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });

}

function AddParking() {
    var parking = {
        parkingName: $('#parkingName').val()
    };

    if (parking != null) {

        $.ajax({
            url: "/Parking/InsertParking",
            data: JSON.stringify(parking), //onverte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#result').text("Added successfully");
                $('#result').css('color', 'green');
                $('#parkingName').val('');
                LoadParkings();
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

function GetParkingById(idParking) {

    var id = 0;
    $.ajax({
        url: "/Parking/GetParkingById",
        type: "GET",
        data: { id: idParking },
        success: function (result) {
            $('#idParkingModal').val(result.idParking);
            $('#parkingNameModal').val(result.parkingName);



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

function UpdateParking() {
    var parking = {
        idParking: parseInt($('#idParkingModal').val()),
        parkingName: $('#parkingNameModal').val()
    };

    if (parking != null) {

        $.ajax({
            url: "/Parking/UpdateParking",
            data: JSON.stringify(parking),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#modalResult').text("Updated successfully");
                $('#modalResult').css('color', 'green');

                LoadParkings();
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

function GetParkings() {

    $.ajax({
        url: "/Parking/GetAllParkings",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //llenar el dropdowns (select)
            var html = '';
            $.each(result, function (key, item) {
                html += '<option value="' + item.idParking + '" id="' + item.idParking + '">' + item.parkingName + '</option>';
            });
            $('#idParkingSelect').append(html);

        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });
}


//----------------------- ParkingSlot ------------------------------
function LoadParkingSlot() {

    $.ajax({
        url: "/ParkingSlot/GetAllParkingSlot",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {

                html += '<tr>';
                html += '<td>' + item.idParkingSlot + '</td>';
                html += '<td>' + item.idParking + '</td>';
                html += '<td>' + item.idTypeVehicle + '</td>';
                html += '<td>' + item.number + '</td>';
                html += '<td>' + item.preferentialSlot + '</td>';
                html += '<td>' + item.state + '</td>';
                //html += '<td><a href="#about" onclick="GetParkingByID(\'' + item.idParking + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalParkingSlot" onclick="GetParkingSlotById(\'' + item.idParkingSlot + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="Delete(' + item.id + ')">Delete</button></td>';
                html += '</tr>';
            });
            $('#parkingSlot-tbody').html(html);
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });

}

function AddParkingSlot() {
    var parkingSlot = {
        idParking: $('#idParkingSelect').val(),
        idTypeVehicle: $('#idTypeVehicle').val(),
        preferentialSlot: $('#preferentialSlot').val()
    };

    if (parkingSlot != null) {

        $.ajax({
            url: "/ParkingSlot/InsertParkingSlot",
            data: JSON.stringify(parkingSlot),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#result').text("Added successfully");
                $('#result').css('color', 'green');
                $('#parkingName').val('');
                LoadParkingSlot();
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

function GetParkingSlotById(idParkingSlot) {

    var id = 0;
    $.ajax({
        url: "/ParkingSlot/GetParkingSlotById",
        type: "GET",
        data: { id: idParkingSlot },
        success: function (result) {
            $('#idParkingSlotModal').val(result.idParkingSlot);
                $('#numberModal').val(result.number);
            $('#idTypeVehicleModal').val(result.idTypeVehicle);
            $('#preferentialSlotModal').val(result.preferentialSlot);



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

function UpdateParkingSlot() {
    var parkingSlot = {
        idParkingSlot: parseInt($('#idParkingSlotModal').val()),
        //idParking: 0,
        idTypeVehicle: parseInt($('#idTypeVehicleModal').val()),
        //number: 0,
        preferentialSlot: $('#preferentialSlotModal').val(),
        //state: 'A'
    };

    if (parkingSlot != null) {

        $.ajax({
            url: "/ParkingSlot/UpdateParkingSlot",
            data: JSON.stringify(parkingSlot),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#modalResult').text("Updated successfully");
                $('#modalResult').css('color', 'green');
                $('#modalParkingSlot').modal('hide');
                LoadParkingSlot();
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