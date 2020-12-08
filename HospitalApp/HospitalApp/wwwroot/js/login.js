$(document).ready(function(){

    alert("AAAA");

    $('#login').click(function (event) {
        event.preventDefault();
        Login();
    });
});

function Login() {

    var username = $("#username").val();
    var password = $("#password").val();
   

   // var transformedData = JSON.stringify(data);
    alert(username);

    $.ajax({
        url: 'http://localhost:50324/login/' + username + '/' + password,
        type: 'POST',
        complete: function (data) {
            if (data.status == 200) {
                alert("Uspeh!");
                window.location.href = "../index.html";
            }
            else
                alert(data.message);
        }
    });
}