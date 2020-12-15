var USERNAME;
var PASS;
var ID;
var DOCTOR;

window.onload = function() {
    authenticateUser();
}

function getAllGeneralPractitioners(){
    $.ajax({
        url: 'http://localhost:50324/getDoctorByType/' + 1,
        type: 'GET',
        async: false,
        complete: function(data){

            var doctors = data.responseJSON;

            var doctorsTable = $("#table tbody");
            doctorsTable.empty();

            for(var i = 0; i < doctors.length; i++){
             
                doctorsTable.append("<tr id='" + doctors[i].id + "'><td>" + doctors[i].firstName +
                                    "</td><td>" + doctors[i].lastName +
                                    "</td><td>" + "General Practitioner" +
                                    "</td></tr>");

                $("#table").append(doctorsTable);
                chooseDoctor(doctors[i].id);
            }
        }
    });
}

function chooseDoctor(doctorId){
    $("tr[id='" + doctorId + "'").click(function(event){
        $("tbody tr").css("background-color", "white");
        $("tr[id='" + doctorId + "'").css("background-color", "Green");
        $.ajax({
            url: 'http://localhost:50324/setGeneralPractitioner/' + ID + '/' + doctorId,
            type: 'PUT',
            headers: {
                "Authorization": "Basic " + btoa(USERNAME + ":" + PASS)
              },
            complete: function(data){
                if(data.status == 200)
                    alert("General Practitioner Successfully Picked!");
                else    
                    alert("Error!");
            }
        });
    });
}

function authenticateUser(){
    $.ajax({
        url: 'http://localhost:50324/getSession',
        type: 'GET',
        complete: function(data){
            var myUser = data.responseJSON;
            if(myUser == undefined || myUser.role == "Administrator"){
                alert("Cannot access this page!");
                window.location.href = "../index.html";
            }

            USERNAME = myUser.username;
            PASS = myUser.password;
            ID = myUser.id;
            getAllGeneralPractitioners();
            getDoctor();
        }
    });
}

function getDoctor(){
    $.ajax({
        url: 'http://localhost:50324/getGeneralPractitioner/' + ID,
        type: 'GET',
        complete: function(data){
            var doctor = data.responseJSON;
            var DOCTOR = doctor.id;
            color(DOCTOR);
        }
    });
}

function color(id){
    $("tr[id='" + id + "'").css("background-color", "Green");
}
