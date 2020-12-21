window.onload = function() {
    authenticateUser();
    changeSelection();
    toggleTable();

    $("#select select").val("none");
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

            getGeneralPractitioner(myUser.id);
            getSpecialist(myUser.id);
        }
    });
}

function getGeneralPractitioner(id){
    $.ajax({
        url: 'http://localhost:50324/getGeneralPractitioner/' + id,
        type: 'GET',
        complete: function(data){
            var doctor = data.responseJSON;
            $("#select").append($("<option>", {
                value: doctor.id,
                text: doctor.firstName + " " + doctor.lastName + " - General Practitioner"
            }));
        }
    });
}

function getSpecialist(id){
    $.ajax({
        url: 'http://localhost:50324/getSpecialist/' + id,
        type: 'GET',
        complete: function(data){
            if(data.status != 404){
                var doctor = data.responseJSON;
                $("#select").append($("<option>", {
                value: doctor.id,
                text: doctor.firstName + " " + doctor.lastName + " - Specialist"
                }));
            }else
                return null;
        }
    });
}

function viewDoctorsWorkingHours(doctor){
    var from = getUrlVars()["from"];
    var to = getUrlVars()["to"];
   
    var d1 = from.split("/");
    var d2 = to.split("/");

    var fromDate = new Date(d1);
    var toDate = new Date(d2);

    createNewAppointment(doctor.id);
    createTable(doctor, fromDate, toDate);
    
    var rowCount = $("#table tr").length; 
    if(rowCount == 1){
        var prioDoctor = getUrlVars()["doctor"];
        if(prioDoctor == "true")
            prioritizeDoctor(doctor, fromDate, toDate);
        else
            prioritizeDate(doctor, fromDate, toDate);
    }
}

function prioritizeDoctor(doctor, fromDate, toDate){
    alert("Prio doctor!");
        ourFromDate = new Date();
        ourFromDate.setDate(fromDate.getDate() - 7);
        ourToDate = new Date();
        ourToDate.setDate(toDate.getDate() +7);

        createTable(doctor, ourFromDate, ourToDate);  
}

function prioritizeDate(doctor, fromDate, toDate){
    alert("Prio date!");

        $.ajax({
            url: 'http://localhost:50324/getDoctorByType/' + doctor.type,
            type: 'GET',
            complete: function(data){
                var list = data.responseJSON;

                var freeAppointments = new Array();
                for(var i = 0; i < list.length; i++){
                    freeAppointments.push.apply(freeAppointments, list[i].workingDays);
                }

                var table = $("#table tbody");
                table.empty();
                
                for(var i = 0; i < freeAppointments.length; i++){
                    var parts = freeAppointments[i].split(" ");
                    var date = parts[0];
                    var time = parts[1] + " " + parts[2];

                    var d3 = date.split("-");
                    var ourDate = new Date(d3);

                    if(ourDate <= toDate && ourDate >= fromDate){
                        if(doctor.type == 1){
                            table.append("<tr id='" + doctor.id + "'><td>" + doctor.firstName + " " + doctor.lastName +   
                            "</td><td>" + "General Practitioner" +
                            "</td><td>" + date +
                            "</td><td>" + time +
                            "</td><td> <button id='" + doctor.id + "'>Create Appointment</button>" +
                            "</td></tr>");

                            $("#table").append(table);
                        }else {
                            table.append("<tr><td>" + doctor.firstName + " " + doctor.lastName +   
                            "</td><td>" + "Specialist" +
                            "</td><td>" + date +
                            "</td><td>" + time +
                            "</td><td> <button id='" + doctor.id + "'>Create Appointment</button>" +
                            "</td></tr>");

                            $("#table").append(table);
                        }
                    }
                }
            }
        });
}

function createTable(doctor, ourFromDate, ourToDate){
    var lista = doctor.workingDays;
    
    var table = $("#table tbody");
    table.empty();

    for(var i = 0; i < lista.length; i++){
        var parts = lista[i].split(" ");
        var date = parts[0];
        var time = parts[1] + " " + parts[2];

        var d3 = date.split("-");
        var ourDate = new Date(d3);

        if(ourDate <= ourToDate && ourDate >= ourFromDate){
            if(doctor.type == 1){
                table.append("<tr id='" + doctor.id + "'><td>" + doctor.firstName + " " + doctor.lastName +   
                "</td><td>" + "General Practitioner" +
                "</td><td>" + date +
                "</td><td>" + time +
                "</td><td> <button id='" + doctor.id + "'>Create Appointment</button>" +
                "</td></tr>");

                $("#table").append(table);
            }else {
                table.append("<tr><td>" + doctor.firstName + " " + doctor.lastName +   
                "</td><td>" + "Specialist" +
                "</td><td>" + date +
                "</td><td>" + time +
                "</td><td> <button id='" + doctor.id + "'>Create Appointment</button>" +
                "</td></tr>");

                $("#table").append(table);
            }
        }
    }
}

function getUrlVars() {
    var vars = {};
    window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function(m,key,value) {
        vars[key] = value;
    });
    return vars;
}

function changeSelection(){
    $("#select").on("change", function(){
        var selectedDoctor = $(this).children("option:selected").val();
        getDoctorById(selectedDoctor);
        $("#table").slideDown(1000);

        if(selectedDoctor == "none")
            $("#table").hide();
    });
}

function getDoctorById(id){
    $.ajax({
        url: 'http://localhost:50324/getDoctorById/' + id,
        type: 'GET',
        complete: function(data){
            if(data != null)
                viewDoctorsWorkingHours(data.responseJSON);
            else    
                alert("Error has occurred!");
        }
    });
}

function toggleTable(){
    var selected = $('#select').find(":selected").val();
    if(selected == "none")
        $("#table").hide();
}

function createNewAppointment(doctorId){
    $("button[id='" + doctorId + "']").click(function(){
        if (!confirm("Are you sure you want to make this appointment?"))
            return null;
        else{
            var currentRow = $(this).closest("tr");

            var date = currentRow.find("td:eq(2)").text();
            var time = currentRow.find("td:eq(3)").text();
    
            $.ajax({
                url: 'http://localhost:50324/getSession',
                type: 'GET',
                complete: function(data){
                    var myUser = data.responseJSON;
    
                    var data = {
                        "date": date,
                        "time": time,
                        "appointmentStatus": 0,
                        "doctorId": doctorId,
                        "patientId": myUser.id
                }
        
                    var transformedData = JSON.stringify(data);
    
                    $.ajax({
                        url: 'http://localhost:50324/addAppointment',
                        type: 'POST',
                        data: transformedData,
                        contentType: 'application/json',
                        dataType: 'json',
                        complete: function(data) {
                            if (data.status == 200) 
                                window.location.href = "index.html";
                            else
                                alert(data.status);
                        }
                    });
                }
            });
        }    
    });
}