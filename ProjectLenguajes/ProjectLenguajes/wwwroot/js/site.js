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
        }
    });
}



function Update() {

}
