var ID;
var PASS;
$(document).ready(function(){
    checkOnlyOneGender();
    toggleNewPasswordOptions();
    cancel();
    getCurrentUser();
    passwordsDoNotMatch();
    saveUserProfile();
});

function checkOnlyOneGender(){
    $(".gender-list").on("change", function(){
        $(this).siblings("input:checkbox").prop("checked", false);
    });
}

function getCheckedGender(){
    if($("#male").is(":checked")){
        alert($("#male").val());
        return $("#male").val();
    }else{
        alert($("#female").val());
        return $("#female").val();
    }
}

function toggleNewPasswordOptions(){
    $("#changePassword").click(function(event){
        event.preventDefault();

        if($("#newPassword").is(":hidden")){
            $("#newPassword").slideDown(1000);
            $("#newPassword").val("");
            $("#retypeNewPassword").slideDown(1000);
            $("#retypeNewPassword").val("");
            $("#newPassword2").slideDown(1000);
            $("#retypeNewPassword2").slideDown(1000);
            $("#changePassword").html("Cancel");
        }else {
            $("#newPassword").slideUp(1000);
            $("#newPassword").val("");
            $("#retypeNewPassword").slideUp(1000);
            $("#retypeNewPassword").val("");
            $("#newPassword2").slideUp(1000);
            $("#retypeNewPassword2").slideUp(1000);
            $("#changePassword").html("Change Password");
        }
    });
}

function cancel(){
    $("#cancel").click(function(event){
        event.preventDefault();
        window.location.href = "../index.html";
    })
}

function getCurrentUser(){
    $.ajax({
        method: 'GET',
        url: 'http://localhost:50324/getSession',
        complete: function (data) {
            if(data.responseJSON == undefined){
                alert("Please log in!");
                window.location.href = "../index.html";
            }else {
                ID = data.responseJSON.id;
                PASS = data.responseJSON.password;
                $("#username").val(data.responseJSON.username);
                $("#password").val(data.responseJSON.password);
                $("#firstName").val(data.responseJSON.firstName);
                $("#lastName").val(data.responseJSON.lastName);
                $("#address").val(data.responseJSON.address);
                $("#phone").val(data.responseJSON.phoneNumber);
            }
        }
    });
}

function passwordsDoNotMatch(){
    $("#retypeNewPassword").on("input", function(e){
        var password = $("#newPassword").val();
        var confirmedPassoword = $("#retypeNewPassword").val();

        if(confirmedPassoword != password){
            $("#retypeNewPassword").css("background-color","red");
            $("#save").attr("disabled", true);
        }
        else {
            $("#retypeNewPassword").css("background-color","white");
            $("#password").val(confirmedPassoword);
            $("#save").attr("disabled", false);
        }
    });
}

function saveUserProfile(){
    $("#save").click(function(event){
        event.preventDefault();

        var data = {
            "username": $("#username").val(),
            "password": $("#password").val(),
            "firstName": $("#firstName").val(),
            "lastName": $("#lastName").val(),
            "address": $("#address").val(),
            "phoneNumber": $("#phone").val()
        }

        var transformedData = JSON.stringify(data);

        $.ajax({
            method: 'PUT',
            url: 'http://localhost:50324/updateUser/' + ID,
            data: transformedData,
            contentType: 'application/json',
            dataType: 'json',
            headers: {
                "Authorization": "Basic " + btoa(data.username + ":" + PASS)
              },
            complete: function (data) {
                if(data.status == 200){
                    alert("Changes successful!");
                    window.location.href = "../index.html";
                }
                else
                    alert("Something went wrong...");    
            }
        });
    });
}
