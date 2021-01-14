window.onload = function(){
    authenticateUser();
}

function authenticateUser(){
    $.ajax({
        url: 'http://localhost:50324/getSession',
        type: 'GET',
        complete: function(data){
            var myUser = data.responseJSON;
            if(myUser == undefined){
                alert("Cannot access this page!");
                window.location.href = "../index.html";
            }
            
            getDoctorAppointments(myUser);
            
        }
    });
}

function getDoctorAppointments(doctor){
    $.ajax({
        url: 'http://localhost:50324/getDoctorAppointments/' + doctor.id,
        type: 'GET',
        headers: {
            "Authorization": "Basic " + btoa(doctor.username + ":" + doctor.password)
          },
        complete: function(data){
            var appointments = data.responseJSON;

            var appointmentsTable = $("#table tbody");
            appointmentsTable.empty();
 
            for(var i = 0; i < appointments.length; i++){
                if(appointments[i].status == 0)
                    getDoneAppointmentPatient(appointmentsTable, appointments[i], doctor);
                else if(appointments[i].status == 1)
                    getActiveAppointmentPatient(appointmentsTable, appointments[i], doctor);
                else
                    getCancelledAppointmentPatient(appointmentsTable, appointments[i]);
            }
        }
    });
}

function generateDoneAppointments(table, appointment, patient, doctor){
    table.append("<tr><td>" + patient.firstName + " " + patient.lastName +
                "</td><td>" + appointment.date +   
                "</td><td>" + appointment.time +
                "</td><td>" + "Done" +
                "</td><td><button class='" + appointment.id + "'> Give Patient a Specialist </button>" +
                "</td><td><button> Make Prescription </button>" +
                "</td></tr>");

    $("#table").append(table);

    $("." + appointment.id).click(function(event){
        $.ajax({
            url: 'http://localhost:50324/getDoctorByType/' + 0,
            type: 'GET',
            complete: function(data){
                var allSpecialists = data.responseJSON;
                var mySpecialist = allSpecialists[Math.floor(Math.random() * allSpecialists.length)];
                
                var data = {
                    "patientId": patient.id,
                    "specialistId": mySpecialist.id,
                    "isDeleted": false
                }
        
                var transformedData = JSON.stringify(data);
                addReferral(transformedData, appointment, doctor);
            }
        });
    });
}

function generateCancelledAppointments(table, appointment, patient){
    table.append("<tr><td>" + patient.firstName  + " " + patient.lastName +
                "</td><td>" + appointment.date +   
                "</td><td>" + appointment.time +
                "</td><td>" + "Cancelled" +
                "</td><td>" +
                "</td><td>" +
                "</td></tr>");

    $("#table").append(table);
}

function generateActiveAppointments(table, appointment, patient, doctor){
    table.append("<tr><td>" + patient.firstName + " " + patient.lastName + 
                "</td><td>" + appointment.date +   
                "</td><td>" + appointment.time +
                "</td><td>" + "Active" +
                "</td><td><button id='" + appointment.id + "'> Appointment Done! </button>" + 
                "</td><td>" +
                "</td></tr>");

    $("#table").append(table);

    $("#" + appointment.id).click(function(event){
        event.preventDefault();
        appointmentDone(appointment.id, doctor);
    });

}

function appointmentDone(appointmentId, doctor){
    $.ajax({
        url: 'http://localhost:50324/finishAppointment/' + appointmentId,
        type: 'PUT',
        headers: {
            "Authorization": "Basic " + btoa(doctor.username + ":" + doctor.password)
          },
        complete: function(data){
            if(data.status == 200){
                alert("Appointment done!");
                window.location.href = "../doctorAppointments.html";
            }
        }
    });
}

function getDoneAppointmentPatient(table, appointment, doctor){
    $.ajax({
        url: 'http://localhost:50324/getAppointmentPatient/' + appointment.id,
        type: 'GET',
        complete: function(data){
            var myPatient = data.responseJSON;
            generateDoneAppointments(table, appointment, myPatient, doctor);
            checkPatientReferral(myPatient, appointment);
        }
    });
}

function getActiveAppointmentPatient(table, appointment, doctor){
    $.ajax({
        url: 'http://localhost:50324/getAppointmentPatient/' + appointment.id,
        type: 'GET',
        complete: function(data){
            var myPatient = data.responseJSON;
            generateActiveAppointments(table, appointment, myPatient, doctor);
        }
    });
}

function getCancelledAppointmentPatient(table, appointment){
    $.ajax({
        url: 'http://localhost:50324/getAppointmentPatient/' + appointment.id,
        type: 'GET',
        complete: function(data){
            var myPatient = data.responseJSON;
            generateCancelledAppointments(table, appointment, myPatient);
        }
    });
}

function addReferral(data, appointment, doctor){
    $.ajax({
        url: 'http://localhost:50324/addReferral',
        type: 'POST',
        headers: {
            "Authorization": "Basic " + btoa(doctor.username + ":" + doctor.password)
          },
        data: data,
        contentType: 'application/json',
        dataType: 'json',
        complete: function(data) {
            if (data.status == 200) {
                $("." + appointment.id).attr("disabled", true);
                $("." + appointment.id).css("background-color", "gray");
                $("." + appointment.id).css("color", "red");
                alert("Success!");
            }
            else
                alert(data.status);
        }
    });
}

function checkPatientReferral(patient, appointment){
    $.ajax({
        url: 'http://localhost:50324/getAllReferrals/',
        type: 'GET',
        complete: function(data){
            var allReferrals = data.responseJSON;
            
            for(var i = 0; i < allReferrals.length; i++)
            {
                if(allReferrals[i].patientId == patient.id){
                    if(!allReferrals[i].isDeleted){
                        $("." + appointment.id).attr("disabled", true);
                        $("." + appointment.id).css("background-color", "gray");
                        $("." + appointment.id).css("color", "red");
                    }
                    break;
                }
            }
        }
    });
}

