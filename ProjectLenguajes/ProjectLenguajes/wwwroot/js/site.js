/*

I built this login form to block the front end of most of my freelance wordpress projects during the development stage.

This is just the HTML / CSS of it but it uses wordpress's login system.

Nice and Simple

*/
// Write your JavaScript code.
$(document).ready(function () {
    LoadUsers();
    
    $(document).on('submit', '#user-entry-form', function () {

        if ($('#id').val() !== null) {

            Add();
        }else {

            Update();
        }
        return false;
    });


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

    //var rol = {

    //    id: parseInt($('#role').val()),
    //    name: $('#role').find('option:selected').text()

    //};

   // student.major = major;
    //user.rol = rol;
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
        url: "/Home/Get",
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

            $('#students-tbody').html(html); 
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });

}



function Clear() {


}


function LogIn(emailUser, passwordUser) {

    var email = "";
    var password = "";
    $.ajax({
        url: "/User/LogIn",
        //url: "https://localhost:7280/api/LogIn/{email},{password}",
        type: "GET",
        data: {
            email: emailUser,
            password: passwordUser
        },
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            if (result != null) {
                $('#result').text("logged successfully");
                $('#result').css('color', 'green');
            }

            //$('#modalId').val(result.id);
            //$('#modalName').val(result.name);
            //$('#modalEmail').val(result.email);
            //$('#password').val(result.password);
            //$('#modalMajor').val(result.major.id);
        },
        error: function (errorMessage) {
            if (errorMessage === "no connection") {
                $('#result').text("Error en la conexión.");
            }
            $('#result').text("User not logged");
            $('#result').css('color', 'red');
            $('#password').val('');
        }
    });
}


function Update() {

}



