
$(document).ready(function () {
    GetTypes();
    GetVehicles();
    GetParkings();
    GetTimes();
    GetRols();
    LoadUsers();
    LoadVehicles();
    LoadClients();
    LoadParkings();
    LoadParkingSlot();
    LoadReservations();
    LoadReservationsClient()
    LoadFees();
    LoadRol();
    LoadBills();
    $(document).on('submit', '#user-entry-form', function () {

        if ($('#id').val() !== null) {
      

            Add();
        }else {

            UpdateUser();
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
            UpdateClient();
            
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



    $(document).on('submit', '#fee-entry-form', function () {

        if ($('#id').val() !== null) {

            AddFee();
        } else {

            UpdateFee();
        }
        return false;
    });

    $(document).on('submit', '#reservation-entry-form', function () {

        if ($('#id').val() !== null) {

            AddReservation();
        } else {

            UpdateFee();
        }
        return false;
    });
    

    $(document).on('submit', '#rol-entry-form', function () {

        if ($('#id').val() !== null) {

             AddRol();
        } else {

            UpdateRol();
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
                if (result != "ITSREGIS") {
                    $('#result').text("Added successfully");
                    $('#result').css('color', 'green');
                    $('#name').val('');
                    $('#email').val('');
                    $('#dni').val('');
                    $('#age').val('');
                    $('#telephone').val('');
                    $('#password').val('');
                    $('#idRol').val($("#rol option:first").val());
                    LoadUsers();
                } else {
                    $('#result').text("Usuario ya registrado");
                    $('#result').css('color', 'red');
                    $('#password').val('');
                }
                
              
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

    var authority = localStorage.getItem("authority");
    if (authority == "3") {
        $.ajax({
            url: "/Home/GetAllUsers",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.IdUser + '</td>';
                    html += '<td>' + item.Name + '</td>';
                    html += '<td>' + item.Dni + '</td>';
                    html += '<td>' + item.Age + '</td>';
                    html += '<td>' + item.Telephone + '</td>';
                    html += '<td>' + item.Email + '</td>';
                    html += '<td>' + item.NameRol + '</td>';
                    //html += '<td><a href="#about" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';

                    html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalUser" onclick="GetUserById(\'' + item.IdUser + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalUserDelete" onclick="GetUserByIdDelete(' + item.IdUser + ')">Delete</button></td>';
                    html += '</tr>';
                });

                $('#user-tbody').html(html);

                $(document).ready(function () {
                    $('#users-table').DataTable();
                });

            },
            error: function (errorMessage) {
                // alert("Error");
                alert(errorMessage.responseText);
            }
        });

    }

}

function GetUserById(idUser) {

    var id = "";
    $.ajax({
        url: "/Home/GetUserById",
        type: "GET",
        data: { id: idUser },
        success: function (result) {
            $('#modalResultUser').text("");
            $('#idUserModal').val(result.idUser);
            $('#idRolUserModal').val(result.idRol);
            $('#nameUserModal').val(result.name);
            $('#dniUserModal').val(result.dni);
            $('#ageUserModal').val(result.age);
            $('#telephoneUserModal').val(result.telephone);
            $('#emailUserModal').val(result.email);
            $('#passwordUserModal').val(result.password);

        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#modalResultUser').text("Error en la conexión.");
            }
            $('#modalResultUser').text("Error capa 8");
            $('#modalResultUser').css('color', 'red');
            $('#password').val('');
        }
    });


    $(document).on('submit', '#reservation-entry-form', function () {

        if ($('#id').val() !== null) {

            AddReservation();
        } else {

            UpdateFee();
        }
        return false;
    });
}

function UpdateUser() {
    var user = {
        idUser: parseInt($('#idUserModal').val()),
        idRol: parseInt($('#idRolUserModal').val()),
        name: $('#nameUserModal').val(),
        dni: $('#dniUserModal').val(),
        age: parseInt($('#ageUserModal').val()),
        telephone: $('#telephoneUserModal').val(),
        email: $('#emailUserModal').val(),
        password: $('#passwordUserModal').val(),


    };

    if (user != null) {

        $.ajax({
            url: "/Home/UpdateUser",
            data: JSON.stringify(user), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#modalResultUser').text("Cambios realizados");
                $('#modalResultUser').css('color', 'green');

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

                $('#result').text("Exitoso");
                $('#result').css('color', 'green');
                
            
                window.location = result.url;
                   
                localStorage.setItem("userId",result.user.idUser);
                localStorage.setItem("name", result.user.name);
                localStorage.setItem("idTypeVehicle", result.user.idTypeVehicle);
                localStorage.setItem("authority", result.authority);
                if (result.authority ==1) {
                    localStorage.setItem("TypeVehicle", result.typeVehicle);
                   
                }
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
function Logout() {
    $.ajax({
        url: "/Home/Logout",
        type: "GET",
        success: function (result) {

            window.location = result.url;
            localStorage.clear();
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

                $('#modalResult').text("Cambios realizados");
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
function GetUserByIdDelete(idUser) {
var id = "";
$.ajax({
    url: "/Home/GetUserById",
    type: "GET",
    data: { id: idUser },
    success: function (result) {
        $('#modalResultUserDelete').text("");
        $('#idUserModalD').val(result.idUser);
        $('#idRolUserModalD').val(result.idRol);
        $('#nameUserModalD').val(result.name);
        $('#dniUserModalD').val(result.dni);
        $('#ageUserModalD').val(result.age);
        $('#telephoneUserModalD').val(result.telephone);
        $('#emailUserModalD').val(result.email);
        $('#passwordUserModalD').val(result.password);

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


function DeleteUserById() {

    var id = document.getElementById("idUserModalD").value;
    $.ajax({
        url: "/Home/DeleteUserById",
        type: "GET",
        data: { id: id },
        success: function (result) {
            $('#modalResultUserDelete').text("Eliminado completo");
            $('#modalResultUserDelete').css('color', 'green');

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

   

    var idvehicle;
    if (validarForm()) {

        $.ajax({
            url: "/Vehicle/InsertVehicle",
            data: JSON.stringify(vehicle), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                var client = {
                    idVehicle: result,
                    name: $('#nameClient').val(),
                    dni: $('#dniClient').val(),
                    age: parseInt($('#ageClient').val()),
                    telephone: $('#telephoneClient').val(),
                    email: $('#emailClient').val(),
                    password: $('#passwordClient').val()
                };

                AddClient(client);


                LoadVehicles();

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
                $('#resultVehicle').text("No se pudo registrar");
                $('#resultVehicle').css('color', 'red');
                $('#password').val('');
            }
        });

    } else {
        $('#resultVehicle').text("Llenar todos los espacios");
        $('#resultVehicle').css('color', 'red');




    }
}

function LoadVehicles() {
    var authority = localStorage.getItem("authority");
    if (authority == "2" || authority == "3") {
        $.ajax({
            url: "/Home/GetAllVehicles",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                var html = '';
                $.each(result, function (key, item) {

                    html += '<tr>';
                    html += '<td>' + item.Idvehicle + '</td>';
                    html += '<td>' + item.Brand + '</td>';
                    html += '<td>' + item.Model + '</td>';
                    html += '<td>' + item.Color + '</td>';
                    html += '<td>' + item.Year + '</td>';
                    html += '<td>' + item.Register + '</td>';
                    html += '<td>' + item.Description + '</td>';
                    html += '<td>' + item.Type + '</td>';
                    //html += '<td><a href="#about" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                    html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalVehicle" onclick="GetVehicleById(\'' + item.Idvehicle + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalVehicleDelete" onclick="GetVehicleByIdDelete(' + item.Idvehicle + ')">Delete</button></td>';
                    html += '</tr>';
                });

                $('#vehicle-tbody').html(html);

                $(document).ready(function () {
                    $('#vehicles-table').DataTable();
                });

            },
            error: function (errorMessage) {
                // alert("Error");
                alert(errorMessage.responseText);
            }
        });
    }
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
                html += '<option value="' + item.IdType + '" id="' + item.IdType + '">' + item.Name + '</option>';
            });
            $('#types').append(html);      
            $('#typesModal').append(html);
            $('#idTypeVehicle').append(html);
            $('#idTypeVehicleModal').append(html);
            $('#idTypeVehicleFee').append(html);
            $('#idTypeVehicleFeeModal').append(html);
            $('#idTypeVehicleFeeModalDelete').append(html);

        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });
}

function GetVehicles() {
    var authority = localStorage.getItem("authority");
    if (authority == "2" || authority == "3") {
        $.ajax({
            url: "/Home/GetAllVehicles",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                //llenar el dropdowns (select)
                var html = '';
                $.each(result, function (key, item) {
                    html += '<option value="' + item.Idvehicle + '" id="' + item.Idvehicle + '">' + item.Register + '</option>';
                });
                $('#register_v').append(html);
                $('#vehicleClientModal').append(html);

            },
            error: function (errorMessage) {
                // alert("Error");
                alert(errorMessage.responseText);
            }
        });
    }
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

                $('#modalResultVehicleUpdate').text("Cambios realizados");
                $('#modalResultVehicleUpdate').css('color', 'green');
              
                LoadVehicles();
            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#modalResultVehicleUpdate').text("Error en la conexión.");
                }
                $('#resmodalResultVehicleUpdateult').text("Cambios no realizados");
                $('#modalResultVehicleUpdate').css('color', 'red');
                $('#modalResultVehicleUpdate').val('');
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

            $('#modalResultVehicleUpdate').text("");
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
function GetVehicleByIdDelete(idVehicle) {

    var id = "";
    $.ajax({
        url: "/Vehicle/GetVehicleById",
        type: "GET",
        data: { id: idVehicle },
        success: function (result) {

            $('#modalResultDelete').text("");
            $('#idVehicleModalD').val(result.idvehicle);
            $('#brandModalD').val(result.brand);
            $('#modelModalD').val(result.model);
            $('#colorModalD').val(result.color);
            $('#yearModalD').val(result.year);
            $('#registerModalD').val(result.register);

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


function DeleteVehicleById() {

    var id = document.getElementById("idVehicleModalD").value;
    $.ajax({
        url: "/Vehicle/DeleteVehicleById",
        type: "POST",
        data: { id: id },
        success: function (result) {

            $('#modalResultDelete').text("Eliminado realizado");
            $('#modalResultDelete').css('color', 'green');
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



//----------------------- Clients ------------------------------
function AddClient(client) {
 
    if (client) {

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

                $('#resultClient').text("registro exitoso");
                $('#resultClient').css('color', 'green');
                $('#password').val('');
                LoadClients();
            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#result').text("Error en la conexión.");
                }
                $('#resultClient').text("Es necesario llenar todos los campos");
                $('#resultClient').css('color', 'red');
                $('#password').val('');
            }
        });

    }
}

function LoadClients() {
    var authority = localStorage.getItem("authority");
    if (authority == "2" || authority == "3") {
        $.ajax({
            url: "/Home/GetAllClients",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                var html = '';
                $.each(result, function (key, item) {

                    html += '<tr>';
                    html += '<td>' + item.IdClient + '</td>';
                    html += '<td>' + item.Name + '</td>';
                    html += '<td>' + item.Dni + '</td>';
                    html += '<td>' + item.Age + '</td>';
                    html += '<td>' + item.Telephone + '</td>';
                    html += '<td>' + item.Email + '</td>';
                    html += '<td>' + item.Register + '</td>';
                    //html += '<td><a href="#about" onclick="GetStudentByEmail(\'' + item.email + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';

                    html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalClient" onclick="GetClientById(\'' + item.IdClient + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalClientDelete" onclick="GetClientByIdDelete(' + item.IdClient + ')">Delete</button></td>';

                    html += '</tr>';
                });
                $('#client-tbody').html(html);

                $(document).ready(function () {
                    $('#clients-table').DataTable();
                });

            },
            error: function (errorMessage) {
                // alert("Error");
                alert(errorMessage.responseText);
            }
        });
    }
}

function UpdateClient() {
    var client = {
        idClient: $('#idClientModal').val(),
        idVehicle: parseInt($('#vehicleClientModal').val()),
        name: $('#nameClientModal').val(),
        dni: $('#dniClientModal').val(),
        age: parseInt($('#ageClientModal').val()),
        telephone: $('#telephoneClientModal').val(),
        email: $('#emailClientModal').val(),
        password: $('#passwordClientModal').val(),


    };

    if (client != null) {

        $.ajax({
            url: "/Client/UpdateClient",
            data: JSON.stringify(client), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#modalResult').text("Cambios realizados");
                $('#modalResult').css('color', 'green');

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


function GetClientById(idClient) {

    var id = "";
    $.ajax({
        url: "/Client/GetClientById",
        type: "GET",
        data: { id: idClient },
        success: function (result) {
            $('#modalResult').text("");
            $('#idClientModal').val(result.idClient);
            $('#vehicleClientModal').val(result.idVehicle);
            $('#nameClientModal').val(result.name);
            $('#dniClientModal').val(result.dni);
            $('#ageClientModal').val(result.age);
            $('#telephoneClientModal').val(result.telephone);
            $('#emailClientModal').val(result.email);
            $('#passwordClientModal').val(result.password);

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

function GetClientByIdDelete(idClient) {

    var id = "";
    $.ajax({
        url: "/Client/GetClientById",
        type: "GET",
        data: { id: idClient },
        success: function (result) {


            $('#modalResultClientDelete').text("");
            $('#idClientModalD').val(result.idClient);
            $('#nameClientModalD').val(result.name);
            $('#dniClientModalD').val(result.dni);
            $('#ageClientModalD').val(result.age);
            $('#telephoneClientModalD').val(result.telephone);
            $('#emailClientModalD').val(result.email);
  


        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#modalResultClientDelete').text("Error en la conexión.");
            }
            $('#modalResultClientDelete').text("User not added");
            $('#modalResultClientDelete').css('color', 'red');
  
        }
    });
}


function DeleteClientById() {

    var id = document.getElementById("idClientModalD").value;
    $.ajax({
        url: "/Client/DeleteClientById",
        type: "GET",
        data: { id: id },
        success: function (result) {

            $('#modalResultClientDelete').text("Eliminado realizado");
            $('#modalResultClientDelete').css('color', 'green');
            LoadClients();

        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#result').text("Error en la conexión.");
            }
            $('#modalResultClientDelete').text("User not added");
            $('#modalResultClientDelete').css('color', 'red');
            $('#modalResultClientDelete').val('');
        }
    });
}

function validarForm() {

    var name = $('#nameClient').val();

    if (name.length == 0) {

        document.getElementById('nameClient').focus();
        return false;
    }


    var dni = $('#dniClient').val();
    if (dni.length == 0) {

        document.getElementById('dniClient').focus();
        return false;
    }

    var age = parseInt($('#ageClient').val());
    if (age.length === 0) {

        document.getElementById('ageClient').focus();
        return false;
    }

    var tel = $('#telephoneClient').val();
    if (tel.length == 0) {

        document.getElementById('telephoneClient').focus();
        return false;
    }

    var email = $('#emailClient').val();
    if (email.length == 0) {

        document.getElementById('emailClient').focus();
        return false;
    }

    var password = $('#passwordClient').val();
    if (password.length == 0) {

        document.getElementById('passwordClient').focus();
        return false;
    }

    return true;




}
//----------------------- Parking ------------------------------
function LoadParkings() {
    var authority = localStorage.getItem("authority");
    if (authority == "3") {
        $.ajax({
            url: "/Parking/GetAllParkings",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                var html = '';
                $.each(result, function (key, item) {

                    html += '<tr>';
                    html += '<td>' + item.IdParking + '</td>';
                    html += '<td>' + item.ParkingName + '</td>';
                    //html += '<td><a href="#about" onclick="GetParkingByID(\'' + item.idParking + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                    html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalParking" onclick="GetParkingById(\'' + item.IdParking + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalParkingDelete" onclick="GetParkingByIdDelete(' + item.IdParking + ')">Delete</button></td>';
                    html += '</tr>';
                });
                $('#parking-tbody').html(html);

                $(document).ready(function () {
                    $('#parkings-table').DataTable();
                });

            },
            error: function (errorMessage) {
                // alert("Error");
                alert(errorMessage.responseText);
            }
        });
    }
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
                $('#result').text("Registro exitoso");
                $('#result').css('color', 'green');
                $('#parkingName').val('');
                LoadParkings();
                GetParkings();


            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#result').text("Error en la conexión.");
                }
                $('#result').text("Error");
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

            $('#modalResult').text("");

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

                $('#modalResult').text("Cambios realizados");
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
                html += '<option value="' + item.IdParking + '" id="' + item.IdParking + '">' + item.ParkingName + '</option>';
            });

            $('#idParkingSelect').empty();
            $('#idParkingSelection').empty();
            $('#idParkingSelect').append(html);
            $('#idParkingSelection').append(html);
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });

}

function GetParkingByIdDelete(idParking) {

    var id = 0;
    $.ajax({
        url: "/Parking/GetParkingById",
        type: "GET",
        data: { id: idParking },
        success: function (result) {

            $('#modalResultParkingDelete').text("");

            $('#idParkingModalD').val(result.idParking);
            $('#parkingNameModalD').val(result.parkingName);



        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#modalResultParkingDelete').text("Error en la conexión.");
            }
            $('#modalResultParkingDelete').text("Parqueo no eliminado");
            $('#modalResultParkingDelete').css('color', 'red');
            $('#password').val('');
        }
    });
}

function DeleteParking() {
    
    var id = document.getElementById("idParkingModalD").value;


       $.ajax({
       url: "/Parking/DeleteParking",
       type: "GET",
       data: { id: id },
       success: function (result) {

           $('#modalResultParkingDelete').text("Parqueo Eliminado");
           $('#modalResultParkingDelete').css('color', 'green');

           LoadParkings();
           LoadParkingSlot();
            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#result').text("Error en la conexión.");
                }
                $('#modalResultParkingDelete').text("Parqueo no eliminado");
                $('#modalResultParkingDelete').css('color', 'red');
                $('#password').val('');
            }
        });

    
}




//----------------------- ParkingSlot ------------------------------
function LoadParkingSlot() {
    var authority = localStorage.getItem("authority");
    if (authority == "3") {
        $.ajax({
            url: "/ParkingSlot/GetAllParkingSlot",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                var html = '';
                $.each(result, function (key, item) {

                    html += '<tr>';
                    html += '<td>' + item.IdParkingSlot + '</td>';
                    html += '<td>' + item.Parking + '</td>';
                    html += '<td>' + item.Type + '</td>';
                    html += '<td>' + item.Number + '</td>';
                    html += '<td>' + item.PreferentialSlot + '</td>';
                    html += '<td>' + item.State + '</td>';
                    //html += '<td><a href="#about" onclick="GetParkingByID(\'' + item.idParking + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                    html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalParkingSlot" onclick="GetParkingSlotById(\'' + item.IdParkingSlot + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalParkingSlotDelete" onclick="GetParkingSlotByIdDelete(' + item.IdParkingSlot + ')">Delete</button></td>';
                    html += '</tr>';
                });
                $('#parkingSlot-tbody').html(html);

                $(document).ready(function () {
                    $('#parkingSlots-table').DataTable();
                });

            },
            error: function (errorMessage) {
                // alert("Error");
                alert(errorMessage.responseText);
            }
        });
    }
}

function AddParkingSlot() {

    var parkingSlot = {
        idParking: $('#idParkingSelect').val(),
        idTypeVehicle: $('#idTypeVehicle').val(),
        number: $('#number').val(),
        preferentialSlot: $('#preferentialSlot').val(),
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
    LoadParkingSlot();
}

function GetParkingSlotById(idParkingSlot) {

    var id = 0;
    $.ajax({
        url: "/ParkingSlot/GetParkingSlotById",
        type: "GET",
        data: { id: idParkingSlot },
        success: function (result) {

            $('#modalResult').text("");
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
                LoadParkingSlot(); // no recarga por lo grande
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

function GetParkingSlotByIdDelete(idParkingSlot) {

    var id = 0;
    $.ajax({
        url: "/ParkingSlot/GetParkingSlotById",
        type: "GET",
        data: { id: idParkingSlot },
        success: function (result) {

            $('#modalResultDeleteFee').text("");

            $('#idParkingSlotModalD').val(result.idParkingSlot);
            $('#numberModalD').val(result.number);
   
    


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

function DeleteParkingSlotById() {

    var id = document.getElementById("idParkingSlotModalD").value;
    $.ajax({
        url: "/ParkingSlot/DeleteParkingSlootById",
        type: "GET",
        data: { id: id },
        success: function (result) {

            $('#modalResultDeleteFee').text("Eliminado exitosamente");
            $('#modalResultDeleteFee').css('color', 'green');
            LoadParkingSlot();
            LoadFees();
        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#modalResultDeleteFee').text("Error en la conexión.");
            }
            $('#modalResultDeleteFee').text("Espacio no eliminado");
            $('#modalResultDeleteFee').css('color', 'red');
        }
    });
}

//----------------------- Times ------------------------------

function GetTimes() {

    $.ajax({
        url: "/Time/Get",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //llenar el dropdowns (select)
            var html = '';
            $.each(result, function (key, item) {
                html += '<option value="' + item.IdTime + '" id="' + item.IdTime + '">' + item.Name + '</option>';
            });
            $('#idTime').append(html);
            $('#idTimeModal').append(html);
            $('#idTimeModalDelete').append(html);
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });
}


//----------------------- fee ------------------------------

function AddFee() {
    var fee = {
        idTypeVehicle: $('#idTypeVehicleFee').val(),
        idTime: $('#idTime').val(),
        price: $('#price').val()
    };

    if (fee != null) {
        $.ajax({
            url: "/Fee/InsertFee",
            data: JSON.stringify(fee), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#resultFee').text("Registro exitoso");
                $('#resultFee').css('color', 'green');
                $('#idTypeVehicleFee').val('');
                $('#idTime').val('');
                $('#price').val('');
                LoadFees();
            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#resultFee').text("Error en la conexión.");
                }
                $('#resultFee').text("Registro sin exitoso");
                $('#resultFee').css('color', 'red');
            }
        });
    }
}

function LoadFees() {
    var authority = localStorage.getItem("authority");
    if (authority == "3") {
        $.ajax({
            url: "/Fee/GetAllFees",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.IdFee + '</td>';
                    html += '<td>' + item.TypeVehicle + '</td>';
                    html += '<td>' + item.Time + '</td>';
                    html += '<td>' + item.Price + '</td>';
                    html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalFee" onclick="GetFeeById(\'' + item.IdFee + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalFeeDelete" onclick="GetFeeById(' + item.IdFee + ')">Delete</button></td>';
                    html += '</tr>';
                });

                $('#fee-tbody').html(html);

                $(document).ready(function () {
                    $('#fees-table').DataTable();
                });

            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });
    }
}

function GetFeeById(idFee) {

    var id = "";
    $.ajax({
        url: "/Fee/GetFeeById",
        type: "GET",
        data: { id: idFee },
        success: function (result) {
            $('#modalResultFee').text("");

            $('#idFeeModal').val(result.idFee);
            $('#idTypeVehicleFeeModal').val(result.idtypeVehicle);
            $('#idTimeModal').val(result.idTime);
            $('#priceModal').val(result.price);


            $('#idFeeModalDelete').val(result.idFee);
            $('#idTypeVehicleFeeModalDelete').val(result.idtypeVehicle);
            $('#idTimeModalDelete').val(result.idTime);
            $('#priceModalDelete').val(result.price);
        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#modalResultFee').text("Error en la conexión.");
            }
            $('#modalResultFee').text("Tarifa no cargada");
            $('#modalResultFee').css('color', 'red');
        }
    });
}

function UpdateFee() {
    var fee = {
        idFee: parseInt($('#idFeeModal').val()),
        idTypeVehicle: parseInt($('#idTypeVehicleFeeModal').val()),
        idTime: $('#idTimeModal').val(),
        price: $('#priceModal').val(),
    };

    if (fee != null) {

        $.ajax({
            url: "/Fee/UpdateFee",
            data: JSON.stringify(fee), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#modalResultFee').text("Cambios realizados");
                $('#modalResultFee').css('color', 'green');
                LoadFees();
            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#modalResultFee').text("Error en la conexión.");
                }
                $('#modalResultFee').text("Cambios no realizados");
                $('#modalResultFee').css('color', 'red');
            }
        });

    }
}

function DeleteFeeById() {

    var id = document.getElementById("idFeeModalDelete").value;
    $.ajax({
        url: "/Fee/DeleteFeeById",
        type: "GET",
        data: { id: id },
        success: function (result) {

            $('#modalResultDeleteFee').text("Eliminado exitosamente");
            $('#modalResultDeleteFee').css('color', 'green');
            LoadFees();
        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#modalResultDeleteFee').text("Error en la conexión.");
            }
            $('#modalResultDeleteFee').text("No se eliminó");
            $('#modalResultDeleteFee').css('color', 'red');
        }
    });
}

//----------------------- Reservation ------------------------------
function AddReservation() {
    var reservation = {
        idTime: $('#idTime').val(),
        cantTime: $('#cantTime').val(),
        idClient: localStorage.getItem("userId"),
        idParkingSlot: $('#slotNumber').val(),
        idParking: $('#idParkingSelection').val(),
        date: $('#dateHour').val()
    };

    if (reservation != null) {
        $.ajax({
            url: "/Reservation/InsertReservation",
            data: JSON.stringify(reservation), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result > -1) {
                    $('#resultReservation').text("Reservacion exitosa");
                    $('#resultReservation').css('color', 'green');
                    LoadReservations();
                    LoadReservationsClient();
                } else {
                    $('#resultReservation').text("Espacio solicitado se encuentra ocupado.");
                    $('#resultReservation').css('color', 'red');

                }
             
            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#resultReservation').text("Espacio solicitado se encuentra ocupado.");
                }
                $('#resultReservation').text("Espacio solicitado se encuentra ocupado.");
                $('#resultReservation').css('color', 'red');
            }
        });
    }
}

function Clear() {
    document.getElementById("reservation-entry-form").reset();
}


function LoadReservations() {
    var authority = localStorage.getItem("authority");
    if (authority == "2" || authority == "3") {
        $.ajax({
            url: "/Reservation/GetAllReservation",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {


                var html = '';
                $.each(result, function (key, item) {

                    html += '<tr>';
                    html += '<td>' + item.IdReservation + '</td>';
                    html += '<td>' + item.Parking + '</td>';
                    html += '<td>' + item.ParkingSlot + '</td>';
                    html += '<td>' + item.Client + '</td>';
                    html += '<td>' + item.Vehicle + '</td>';
                    html += '<td>' + item.Register + '</td>';
                    html += '<td>' + item.CantTime + '</td>';
                    html += '<td>' + item.Time + '</td>';
                    html += '<td>' + item.TotalCost + '</td>';
                    html += '<td>' + item.InitDate + '</td>';
                    html += '<td>' + item.FinalDate + '</td>';

                    //html += '<td><a href="#about" onclick="GetParkingByID(\'' + item.idParking + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                    html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalReservationCancel" onclick="GetReservationById(' + item.IdReservation + ')">Cancelar</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalReservationPayment" onclick="GetReservationById(' + item.IdReservation + ')">Cobrar</button></td>';
                     html += '</tr>';
                });
                $('#reservation-tbody').html(html);

                $(document).ready(function () {
                    $('#reservation-table').DataTable();
                });

            },
            error: function (errorMessage) {
                // alert("Error");
                alert(errorMessage.responseText);
            }
        });
    }

}

function LoadReservationsClient() {
    var authority = localStorage.getItem("authority");
    var id = localStorage.getItem("userId");
    if (authority=="1") {
    $.ajax({
        url: "/Reservation/GetAllReservationByClient",
        type: "GET",
        data: { id: id },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
     
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {

                html += '<tr>';
                html += '<td>' + item.IdReservation + '</td>';
                html += '<td>' + item.Parking + '</td>';
                html += '<td>' + item.ParkingSlot + '</td>';
                html += '<td>' + item.Client + '</td>';
                html += '<td>' + item.Vehicle + '</td>';
                html += '<td>' + item.Register + '</td>';
                html += '<td>' + item.CantTime + '</td>';
                html += '<td>' + item.Time + '</td>';
                html += '<td>' + item.TotalCost + '</td>';
                html += '<td>' + item.InitDate + '</td>';
                html += '<td>' + item.FinalDate + '</td>';
                if (item.State == "A") {
                    html += '<td>' + 'Reservada' + '</td>';
                    html += '<td><button id="cancelButonReservationClient" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalReservationCancel" onclick="GetReservationById(' + item.IdReservation + ')">Cancelar</button></td>';

                } else if (item.State == "R") {
                    html += '<td>' + 'Cancelada' + '</td>';
                    html += '<td><button id="cancelButonReservationClient" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalReservationCancel" onclick="GetReservationById(' + item.IdReservation + ')"disabled >Cancelar</button></td>';

                } else {
                    html += '<td>' + 'Facturada' + '</td>';
                    html += '<td><button id="cancelButonReservationClient" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalReservationCancel" onclick="GetReservationById(' + item.IdReservation + ')" disabled>Cancelar</button></td>';

                }
                //html += '<td><a href="#about" onclick="GetParkingByID(\'' + item.idParking + '\')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
                 html += '</tr>';

            
            });
            $('#reservationClient-tbody').html(html);

            $(document).ready(function () {
                $('#reservationClient-table').DataTable();
            });

        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }

    });
    }

}


function GetReservationById(IdReservation) {
    

    $.ajax({
        url: "/Reservation/GetReservationById",
        type: "GET",
        data: { id: IdReservation },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#modalResultReservation').text("");
            $('#idReservation').val(result.IdReservation);
            $('#Parking').val(result.Parking);
            $('#ParkingSlot').val(result.ParkingSlot);
            $('#Client').val(result.Client);
            $('#Vehicle').val(result.Vehicle);
            $('#Register').val(result.Register);
            $('#CantTime').val(result.CantTime);
            $('#Time').val(result.Time);
            $('#InitDate').val(result.InitDate);
            $('#FinalDate').val(result.FinalDate);


            $('#idReservationPayment').val(result.IdReservation);
            $('#ParkingPayment').val(result.Parking);
            $('#ParkingSlotPayment').val(result.ParkingSlot);
            $('#ClientPayment').val(result.Client);
            $('#VehiclePayment').val(result.Vehicle);
            $('#RegisterPayment').val(result.Register);
            $('#CantTimePayment').val(result.CantTime);
            $('#TimePayment').val(result.Time);
            $('#totalCostModalPayment').val(result.TotalCost);
            $('#InitDatePayment').val(result.InitDate);
            $('#FinalDatePayment').val(result.FinalDate);



        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#result').text("Error en la conexión.");
            }
            $('#modalResultReservation').text("User not added");
            $('#modalResultReservation').css('color', 'red');
            $('#modalResultReservation').val('');
        }
    });

}
 function DeleteReservationById() {
    var id = document.getElementById("idReservation").value;
    $.ajax({
        url: "/Reservation/CancelReservationB",
        type: "GET",
        data: { id: id },
        success: function (result) {

            $('#modalResultReservation').text("Reservacion cancelada");
            $('#modalResultReservation').css('color', 'green');
            LoadReservationsClient();
            LoadReservations();
        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#modalResultReservation').text("Error en la conexión.");
            }
            $('#modalResultReservation').text("No se canceló la reservacion");
            $('#modalResultReservation').css('color', 'red');
        }
    });
}

function consultReservation() {
    var reservation = {
        idTime: $('#idTime').val(),
        cantTime: $('#cantTime').val(),
        idClient: localStorage.getItem("userId"),
        idParkingSlot: $('#slotNumber').val(),
        idParking: $('#idParkingSelection').val(),
        date: $('#dateHour').val()
    };

    if (reservation != null) {
        $.ajax({
            url: "/Reservation/consultReservation",
            data: JSON.stringify(reservation), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.Availability == "available") {
                    $('#idTotalCostResult').val(result.TotalCost);
                    $('#resultReservationAvailable').text("Espacio disponible");
                    $('#resultReservationAvailable').css('color', 'green');
                }
                else
                {
                    $('#resultReservationAvailable').text("Espacio no disponible");
                    $('#resultReservationAvailable').css('color', 'red');
                }
                
            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#resultReservation').text("Espacio solicitado se encuentra ocupado.");
                }
                $('#resultReservation').text("Espacio solicitado se encuentra ocupado.");
                $('#resultReservation').css('color', 'red');
            }
        });
    }
}


//----------------------- Roles ------------------------------

function GetRols() {

        $.ajax({
            url: "/Rol/GetRols",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                //llenar el dropdowns (select)
                var html = '';
                $.each(result, function (key, item) {
                    html += '<option value="' + item.IdRol + '" id="' + item.Name + '">' + item.Name + '</option>';
                });
                $('#idRol').append(html);
                $('#idRolUserModal').append(html);

            },
            error: function (errorMessage) {
                // alert("Error");
                alert(errorMessage.responseText);
            }
        });
    
}




function AddRol() {
    var rol = {

        name: $('#rolName').val(),
        authority: $('#authority').val()

    };

    if (rol != null) {
        $.ajax({
            url: "/Rol/InsertRol",
            data: JSON.stringify(rol), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#resultRol').text("Agregado exitosamente");
                $('#resultRol').css('color', 'green');
                $('#rolName').val('');
                $('#authority').val($("#rol option:first").val());
                LoadRol();
                GetRols();
            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#resultRol').text("Error en la conexión.");
                }
                $('#resultRol').text("Rol no añadido");
                $('#resultRol').css('color', 'red');

            }
        });
    }
}
function LoadRol() {
    var authority = localStorage.getItem("authority");
    if (authority == "3") {
        $.ajax({
            url: "/Rol/GetRols",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.IdRol + '</td>';
                    html += '<td>' + item.Name + '</td>';
                    html += '<td>' + item.Authority + '</td>';

                    html += '<td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalRol" onclick="GetRolById(\'' + item.IdRol + '\')">Edit</button> | <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalRolDelete" onclick="GetRolByIdDelete(' + item.IdRol + ')">Delete</button></td>';
                    html += '</tr>';
                });

                $('#rol-tbody').html(html);

                $(document).ready(function () {
                    $('#roles-table').DataTable();
                });

            },
            error: function (errorMessage) {
                //   alert(errorMessage.responseText);
            }
        });
    }
}


function GetRolById(IdRol) {

    var id = 0;
    $.ajax({
        url: "/Rol/GetRolById",
        type: "GET",
        data: { id: IdRol },
        success: function (result) {

            $('#resultRolModal').text("");

            $('#idRolModal').val(result.idRol);
            $('#rolNameModal').val(result.name);
            $('#authorityModal').val(result.authority);



        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#resultRolModal').text("Error en la conexión.");
            }
            $('#resultRolModal').text("Rol not added");
            $('#resultRolModal').css('color', 'red');
            /*        $('#password').val('');*/
        }
    });
}

function UpdateRol() {
    var rol = {
        idRol: parseInt($('#idRolModal').val()),
        name: $('#rolNameModal').val(),
        authority: parseInt($('#authorityModal').val())
    };

    if (rol != null) {

        $.ajax({
            url: "/Rol/UpdateRol",
            data: JSON.stringify(rol),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#resultRolModal').text("Cambios realizados");
                $('#resultRolModal').css('color', 'green');

                LoadRol();
            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#result').text("Error en la conexión.");
                }
                $('#resultRolModal').text("rol not added");
                $('#resultRolModal').css('color', 'red');
                ///*                */$('#password').val('');
            }
        });

    }
}


function GetRolByIdDelete(IdRol) {

    var id = 0;
    $.ajax({
        url: "/Rol/GetRolById",
        type: "GET",
        data: { id: IdRol },
        success: function (result) {

            $('#modalResultRolDelete').text("");

            $('#idRolModalD').val(result.idRol);
            $('#rolNameModalD').val(result.name);
            $('#AuthorityModalD').val(result.authority);



        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#modalResultRolDelete').text("Error en la conexión.");
            }
            $('#modalResultRolDelete').text("Rol not added");
            $('#modalResultRolDelete').css('color', 'red');
            /*        $('#password').val('');*/
        }
    });
}


function DeleteRol() {

    var id = document.getElementById("idRolModalD").value;


    $.ajax({
        url: "/Rol/DeleteRol",
        type: "GET",
        data: { id: id },
        success: function (result) {

            $('#modalResultRolDelete').text("Rol Eliminado");
            $('#modalResultRolDelete').css('color', 'green');

            LoadRol();
        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#result').text("Error en la conexión.");
            }
            $('#modalResultRolDelete').text("Rol no eliminado");
            $('#modalResultRolDelete').css('color', 'red');

        }
    });
}




//-----------------------bills ------------------------------

function AddBill() {
    var bill = {
   
        idBill: document.getElementById("idReservationPayment").value,
        client: document.getElementById("ClientPayment").value,
        vehicle: document.getElementById("VehiclePayment").value,
        parking: document.getElementById("ParkingPayment").value,
        parkingSlot: document.getElementById("ParkingSlotPayment").value,
        totalCost: document.getElementById("totalCostModalPayment").value,
        facturator: localStorage.getItem("name"),
    }

    if (bill != null) {
        $.ajax({
            url: "/Bill/InsertBill",
            data: JSON.stringify(bill), //converte la variable estudiante en tipo json
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#modalResultReservationPayment').text("Facturado exitoso");
                $('#modalResultReservationPayment').css('color', 'green');
                LoadBills();
                LoadReservations();

            },
            error: function (errorMessage) {
                if (errorMessage === "no connection") {
                    $('#modalResultReservationPayment').text("Error en conexion.");
                }
                $('#modalResultReservationPayment').text("error al facturar.");
                $('#modalResultReservationPayment').css('color', 'red');
            }
        });
    }
}

function LoadBills() {
    var authority = localStorage.getItem("authority");
    var id = localStorage.getItem("userId");
    if (authority == "2" || authority == "3") {
        $.ajax({
            url: "/Bill/GetBills",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {

                    html += '<tr>';
                    html += '<td>' + item.IdBill + '</td>';
                    html += '<td>' + item.Client + '</td>';
                    html += '<td>' + item.Vehicle + '</td>';
                    html += '<td>' + item.DateRem + '</td>';
                    html += '<td>' + item.Parking + '</td>';
                    html += '<td>' + item.ParkingSlot + '</td>';
                    html += '<td>' + item.TotalCost + '</td>';
                    html += '<td>' + item.Facturator + '</td>';
                    html += '</tr>';
                });
                $('#bills-tbody').html(html);

                $(document).ready(function () {
                    $('#bills-table').DataTable();
                });

            },
            error: function (errorMessage) {
                // alert("Error");
                alert(errorMessage.responseText);
            }
        });
    }
}
    