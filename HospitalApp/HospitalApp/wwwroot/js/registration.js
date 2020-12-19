$(document).ready(function(){
    passwordsDoNotMatch();
    checkOnlyOneGender();
    validateUsername();
    validatePassword();

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
        "address": $("#address").val(),
        "phoneNumber": $("#phone").val(),
        "isDeleted": false,
        "age": parseInt($("#age").val()),
        "gender": getCheckedGender()
    }

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
            if(data["status"] == 400 && $("#username").val() != "")
                $("#error1").show();
            if(data["status"] == 400 && $("#username").val() == "")
                $("#error2").show();
            if(data["status"] == 400 && $("#password").val() == "")
                $("#error3").show();
        }
    });
}

function passwordsDoNotMatch(){
    $("#confirmPassword").on("input", function(e){
        var password = $("#password").val();
        var confirmedPassoword = $("#confirmPassword").val();

        if(confirmedPassoword != password){
            $("#confirmPassword").css("background-color","red");
            $("#register").attr("disabled", true);
        }
        else {
            $("#confirmPassword").css("background-color","white");
            $("#register").attr("disabled", false);
        }
    });
}

function checkOnlyOneGender(){
    $(".gender-list").on("change", function(){
        $(this).siblings("input:checkbox").prop("checked", false);
    });
}

function getCheckedGender(){
    if($("#male").is(":checked")){
        return $("#male").val();
    }else{
        return $("#female").val();
    }
}

function validateUsername(){
    $("#username").on("input", function(e){
        if(!$("#error1").is(":hidden") ||  !$("#error2").is(":hidden")){
            $("#error1").hide();
            $("#error2").hide();
        }
    });
}

function validatePassword(){
    $("#password").on("input", function(e){
        if(!$("#error3").is(":hidden"))
            $("#error3").hide();
    });
}