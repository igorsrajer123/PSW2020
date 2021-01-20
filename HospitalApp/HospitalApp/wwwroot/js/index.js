window.onload = function(){
    getCurrentUser();
    getVisibleFeedbacks();
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
    if(user == undefined)
        showUnidentifiedUserOptions();
    else if(user.role == "Patient")
        showPatientOptions();
    else if(user.role == "Administrator")
        showAdministratorOptions();
    else if(user.role == "Doctor")
        showDoctorOptions();
}

function showUnidentifiedUserOptions(){
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
    $("#doctorsAppointments").hide();
    $("#orderMedications").hide();
    $("#medications").hide();
}

function showPatientOptions(){
    $("#appointment").show();
    $("#logout").show();
    $("#users").hide();
    $("#login").hide();
    $("#register").hide();
    $("#pickPractitioner").show();
    $("#viewAppointments").show();
    $("#giveFeedback").hide();
    $("#feedbacks").hide();
    $("#doctorsAppointments").hide();
    $("#orderMedications").hide();
    $("#medications").hide();
}

function showAdministratorOptions(){
    $("#pickPractitioner").hide();
    $("#appointment").hide();
    $("#logout").show();
    $("#users").show();
    $("#login").hide();
    $("#register").hide();
    $("#viewAppointments").hide();
    $("#giveFeedback").hide();
    $("#feedbacks").show();
    $("#doctorsAppointments").hide();
    $("#orderMedications").show();
    $("#medications").show();
}

function showDoctorOptions(){
    $("#pickPractitioner").hide();
    $("#appointment").hide();
    $("#logout").show();
    $("#users").hide();
    $("#login").hide();
    $("#register").hide();
    $("#viewAppointments").hide();
    $("#giveFeedback").hide();
    $("#feedbacks").hide();
    $("#doctorsAppointments").show();
    $("#orderMedications").hide();
    $("#medications").show();
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
        window.location.href = "chooseDoctor.html";
    });

    $("#viewAppointments").click(function(event){
        event.preventDefault();
        window.location.href = "patientAppointments.html";
    });

    $("#giveFeedback").click(function(event){
        event.preventDefault();
        window.location.href = "giveFeedback.html";
    });

    $("#doctorsAppointments").click(function(event){
        event.preventDefault();
        window.location.href = "doctorAppointments.html";
    });

    $("#orderMedications").click(function(event){
        event.preventDefault();
        window.location.href = "orderMedications.html";
    });

    $("#medications").click(function(event){
        event.preventDefault();
        window.location.href = "medications.html";
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
         if(data.responseJSON.role == "Patient")
            checkForUserFeedbackOption(data.responseJSON);
        }
    });
}

function checkForUserFeedbackOption(user){
    $.ajax({
        method: 'GET',
        url: 'http://localhost:50324/getPatientAppointments/' + user.id,
        headers: {
            "Authorization": "Basic " + btoa(user.username + ":" + user.password)
          },
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

function getVisibleFeedbacks(){
    $.ajax({
        url: 'http://localhost:50324/getVisibleFeedbacks',
        type: 'GET',
        complete: function(data){
            var allFeedbacks = data.responseJSON;
            $("#visibleFeedbacks").empty();
            
            for(var i = 0; i < allFeedbacks.length; i++){
                getFeedbackPatient(allFeedbacks[i]);
            }
        }
    });
}

function getFeedbackPatient(feedback){
    $.ajax({
        url: 'http://localhost:50324/getPatientById/' + feedback.patientId,
        type: 'GET',
        complete: function(data){
            var patient = data.responseJSON;

            var newDiv = document.createElement("div");
            newDiv.innerHTML = "<p>" + patient.firstName + " " + patient.lastName + "</p>" +
                                "<p>" + feedback.date + "</p>" + 
                                "<textarea disabled='true'>" + feedback.text + "</textarea>";
                
            $("#visibleFeedbacks").append(newDiv);
        }
    });
}
