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
