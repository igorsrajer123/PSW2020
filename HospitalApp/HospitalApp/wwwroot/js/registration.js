$(document).ready(function(){
    passwordsDoNotMatch();

    $("#register").click(function(event){
        event.preventDefault();

        registration();
    });
});

function registration(){

    var data = {
        "username": $("#username").val(),
        "password": $("#password").val(),
        "firstName": $("#firstname").val(),
        "lastName": $("#lastname").val(),
        "isDeleted": false,
        "age": parseInt($("#age").val()),
        "gender": "male"
    }

    console.log($("#age").val());

    var transformedData = JSON.stringify(data);

    $.ajax({
        url: 'http://localhost:50324/addPatient',
        type: 'POST',
        data: transformedData,
        contentType: 'application/json',
        dataType: 'json',
        complete: function(data) {
            if (data["status"] == 200) 
                window.location.href = "index.html";
            else 
                alert(data["status"]);
        }
    });
}

function passwordsDoNotMatch(){
    $("#confirmPassword").on("input", function(e){
        var password = $("#password").val();
        var confirmedPassoword = $("#confirmPassword").val();

        if(confirmedPassoword != password)
            $("#confirmPassword").css("background-color","red");
        else
            $("#confirmPassword").css("background-color","white");
    });
}