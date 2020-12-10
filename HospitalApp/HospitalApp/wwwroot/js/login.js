$(document).ready(function(){
    $("#error").hide();
    $('#login').click(function (event) {
        event.preventDefault();
        login();
    });

    redirectUser();
});

function login() {
    var username = $("#username").val();
    var password = $("#password").val();
   
    $.ajax({
        url: 'http://localhost:50324/login/' + username + '/' + password,
        type: 'POST',
        headers: {
            "Authorization": "Basic " + btoa(username + ":" + password)
          },
        complete: function (data) {
            if (data.status == 200) {
                alert("Log In Successful!");
                window.location.href = "../index.html";
                $("#error").hide();
            }else
                validateFields();
                validateIfUsernameEmpty();
                validateIfPasswordEmpty();
        }
    });
}

function redirectUser(){
    $("#registration").click(function(event){
        event.preventDefault();
        window.location.href = "registration.html";
    });
}

function validateIfUsernameEmpty(){
    $("#username").on("input",function(e){
        var username = $("#username").val();

        if(username != "")
            $("#username").css("background-color","white");
        else
            $("#username").css("background-color","red");
    });
}

function validateIfPasswordEmpty(){
    $("#password").on("input", function(e){
        var password = $("#password").val();

        if(password != "")
            $("#password").css("background-color","white");
        else
            $("#password").css("background-color","red");
    })
}

function validateFields(){
    var username = $("#username").val();
    var password = $("#password").val();

    if(password == ""){
        $("#error").hide();
        $("#password").css("background-color","red");
    }   
        
    if(username == ""){
        $("#error").hide();
        $("#username").css("background-color","red");
    }
        
    if(username == "" && password == ""){
        $("#error").hide();
        $("#password").css("background-color","red");
        $("#username").css("background-color","red");
    }

    if(username != "" && password != "")
        $("#error").show();
}