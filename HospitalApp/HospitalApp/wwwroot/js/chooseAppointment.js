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
    
    var table = $("#table tbody");
    table.empty();

    var from = getUrlVars()["from"];
    var to = getUrlVars()["to"];
   
    var d1 = from.split("/");
    var d2 = to.split("/");
    var fromDate = new Date(d1);
    var toDate = new Date(d2);

    for(var i = 0; i < lista.length; i++){
        var parts = lista[i].split(" ");
        var date = parts[0];
        var time = parts[1] + " " + parts[2];

        var d3 = date.split("-");
        var ourDate = new Date(d3);

        if(doctor.type == 1 && ourDate <= toDate && ourDate >= fromDate){
           
                table.append("<tr><td>" + doctor.firstName + " " + doctor.lastName +   
                "</td><td>" + "General Practitioner" +
                "</td><td>" + date +
                "</td><td>" + time +
                "</td><td> <button>Create Appointment</button>" +
                "</td></tr>");

                $("#table").append(table);
           
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