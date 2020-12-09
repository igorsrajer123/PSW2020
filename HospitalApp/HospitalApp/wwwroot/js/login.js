$(document).ready(function(){

    $('#login').click(function (event) {
        event.preventDefault();
        login();
    });
});

function login() {

    var username = $("#username").val();
    var password = $("#password").val();
   
    $.ajax({
        url: 'http://localhost:50324/login/' + username + '/' + password,
        type: 'POST',
        complete: function (data) {
            if (data.status == 200) {
                alert("Uspeh!");
                window.location.href = "../index.html";
            }
            else
                alert("Neuspeh!");
        }
    });
}