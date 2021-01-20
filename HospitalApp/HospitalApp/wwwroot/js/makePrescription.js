window.onload = function(){
    getAllMedications();
}

function makePrescription(){
    $("#sendPrescription").click(function(event){
        event.preventDefault();
        var firstName = getUrlVars()["firstName"];
        var lastName = getUrlVars()["lastName"];
        var medications = [];

        $('#table [type="checkbox"]').each(function(i, check){
            if(check.checked){
                var medName = $(this).closest('td').next().text();
                var quantity = $(this).closest('td').siblings().eq(1).find('input').val();      
                var medicationFullName = medName + "(" + quantity + ")";       
                medications.push(medicationFullName);
            }
        });
        
        var data = {
            "id": 3,
            "patientName": firstName + " " + lastName,
            "medications": medications,
            "used": false
        }
        
        alert(data);
        var transformedData = JSON.stringify(data);

        $.ajax({
            url: 'https://localhost:8080/api/createPrescription',
            type: 'POST',
            crossDomain: true,
            data: transformedData,
            contentType: 'application/json',
            dataType: 'json',
            complete: function(data) {
                if (data.status == 201) 
                    window.location.href = "index.html";
                else
                    alert(data.status);
            }
        });
    });
}  

function getUrlVars() {
    var vars = {};
    window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function(m,key,value) {
        vars[key] = value;
    });
    return vars;
}

function getAllMedications(){
    $.ajax({
        url: 'http://localhost:50324/getAllMedications',
        type: 'GET',
        complete: function(data){
            var allMedications = data.responseJSON;

            var medsTable = $("#table tbody");
            medsTable.empty();

            for(var i = 0; i < allMedications.length; i++){
                medsTable.append("<tr><td><input type='checkbox'></td>" +
                "<td>" + allMedications[i].name +   
                "</td><td><input type='text'>" +
                "</td></tr>");

                $("#table").append(medsTable);
            }

            medsTable.append("<tr><td><button id='sendPrescription'>Send</button></td></tr>");
            $("#table").append(medsTable);
            makePrescription();
        }
    });
}