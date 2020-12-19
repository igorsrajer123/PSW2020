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
            
            getPatientAppointments(myUser.id);
        }
    });
}

function getPatientAppointments(patientId){
    $.ajax({
        url: 'http://localhost:50324/getPatientAppointments/' + patientId,
        type: 'GET',
        complete: function(data){
            var appointments = data.responseJSON;

            var appointmentsTable = $("#table tbody");
            appointmentsTable.empty();

            for(var i = 0; i < appointments.length; i++){
                if(appointments[i].status == 0){
                    appointmentsTable.append("<tr><td>" + appointments[i].date +   
                                    "</td><td>" + appointments[i].time +
                                    "</td><td>" + appointments[i].doctorId +
                                    "</td><td>" + "Done" +
                                    "</td><td>" + 
                                    "</td></tr>");

                    $("#table").append(appointmentsTable);

                }else if(appointments[i].status == 1){
                    appointmentsTable.append("<tr><td>" + appointments[i].date +   
                                    "</td><td>" + appointments[i].time +
                                    "</td><td>" + appointments[i].doctorId +
                                    "</td><td>" + "Active" +
                                    "</td><td><button id='" + appointments[i].id + "'> Cancel Appointment</button>" + 
                                    "</td></tr>");

                    $("#table").append(appointmentsTable);

                }else{
                    appointmentsTable.append("<tr><td>" + appointments[i].date +   
                                    "</td><td>" + appointments[i].time +
                                    "</td><td>" + appointments[i].doctorId +
                                    "</td><td>" + "Cancelled" +
                                    "</td><td>" + 
                                    "</td></tr>");

                    $("#table").append(appointmentsTable);
                }
            }
            setDoctorName();
        }
    });
}

function setDoctorName(){
    for(var i = 1; i < $("#table tr").length; i++){
        var doctorIdRow = $("#table").find("tr").eq(i);
        var doctorId = doctorIdRow.find("td").eq(2).text();
        
        $.ajax({
            url: 'http://localhost:50324/getDoctorById/' + doctorId,
            type: 'GET',
            async: false,
            complete: function(data){
                var doctor = data.responseJSON;

                if(doctor.type == 0) 
                    doctorIdRow.find("td").eq(2).text(doctor.firstName + " " + doctor.lastName + " - "  + "Specialist");
                else    
                    doctorIdRow.find("td").eq(2).text(doctor.firstName + " " + doctor.lastName + " - " + "General Practitioner");
            }
        });
    }
}