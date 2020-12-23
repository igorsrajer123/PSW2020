window.onload = function(){
    getCurrentUser();
}

function welcomeMessage(user){
    if (user == undefined) {
        $("#currentUser").hide();
        $("#user").hide();
    } else {
        $("#logo").append("<label id='currentUser'>Current user: </label><label id='user'></label>");
        $("#currentUser").show();
        $("#user").text(user.username);
    }
}

function userOptions(user){
    if(user == undefined){
        $("#appointment").show();
        $("#login").show();
        $("#register").show();
        $("#logout").hide();
        $("#profile").hide();
        $("#users").hide();
        $("#pickPractitioner").hide();
        $("#viewAppointments").hide();
        $("#giveFeedback").hide();
        $("#feedbacks").hide();
    }else if(user.role == "Patient"){
        $("#appointment").show();
        $("#logout").show();
        $("#users").hide();
        $("#login").hide();
        $("#register").hide();
        $("#pickPractitioner").show();
        $("#viewAppointments").show();
        $("#giveFeedback").hide();
        $("#feedbacks").hide();
    }else {
        $("#pickPractitioner").hide();
        $("#appointment").hide();
        $("#logout").show();
        $("#users").show();
        $("#login").hide();
        $("#register").hide();
        $("#viewAppointments").hide();
        $("#giveFeedback").hide();
        $("#feedbacks").show();
    }
}

function redirectUser(user){
    $("#appointment").click(function(event){
        event.preventDefault();

        if(user == undefined){
            alert("Please login first!");
            window.location.href = "login.html";
        }
        if(user.role == "Patient")
            window.location.href = "patientAppointmentPreferences.html"; 
    });

    $("#pickPractitioner").click(function(event){
        event.preventDefault();

        window.location.href="chooseDoctor.html";
    });

    $("#viewAppointments").click(function(event){
        event.preventDefault();

        window.location.href="patientAppointments.html";
    });

    $("#giveFeedback").click(function(event){
        event.preventDefault();

        window.location.href="giveFeedback.html";
    });
}

function getCurrentUser(){
    $.ajax({
        method: 'GET',
        url: 'http://localhost:50324/getSession',
        complete: function (data) {
            welcomeMessage(data.responseJSON);
            userOptions(data.responseJSON);
            redirectUser(data.responseJSON);
            checkForUserFeedbackOption(data.responseJSON);
        }
    });
}

function checkForUserFeedbackOption(user){
    $.ajax({
        method: 'GET',
        url: 'http://localhost:50324/getPatientAppointments/' + user.id,
        complete: function (data) {
            var appointments = data.responseJSON;

            for(var i = 0; i < appointments.length; i++){
                if(appointments[i].status == 0){
                    $("#giveFeedback").show();
                    break;
                }

            }
        }
    });
}