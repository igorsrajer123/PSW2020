var ID;
window.onload = function() {
    authenticateUser();
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

            getDoctor(myUser.id);
        }
    });
}

function getDoctor(id){
    $.ajax({
        url: 'http://localhost:50324/getGeneralPractitioner/' + id,
        type: 'GET',
        complete: function(data){
            var doctor = data.responseJSON;
            viewDoctorsWorkingHours(doctor);
        }
    });
}

function viewDoctorsWorkingHours(doctor){
    var lista = doctor.workingDays;
    alert(lista);

    var table = $("#table tbody");
    table.empty();

    for(var i = 0; i < lista.length; i++){
        var parts = lista[i].split(" ");
        var date = parts[0];
        var time = parts[1] + " " + parts[2];

        if(doctor.type == 1){
            table.append("<tr><td>" + doctor.firstName + " " + doctor.lastName +   
            "</td><td>" + "General Practitioner" +
            "</td><td>" + date +
            "</td><td>" + time +
            "</td><td> <button> Create Appointment</button>" +
            "</td></tr>");

            $("#table").append(table);
        }
    }
}