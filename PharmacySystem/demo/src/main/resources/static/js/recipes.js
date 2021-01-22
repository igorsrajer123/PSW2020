window.onload = function(){
    getAllRecipes();
}

function getAllRecipes(){
    $.ajax({
        url: 'https://localhost:8080/api/prescriptions',
        type: 'GET',
        complete: function(data){
            var allPrescriptions = data.responseJSON;
            
            for(var i = 0; i < allPrescriptions.length; i++){
                var newDiv = document.createElement("div");
                newDiv.innerHTML = "<p style='color:white'><b>Patient Name:</b></p>" +
                                    "<p>" + allPrescriptions[i].patientName + "</p><br/>" +
                                    "<p style='color:white'><b>" + "Medications:" + "</b></p>" + 
                                    "<p>" + allPrescriptions[i].medications + "</p><br/>" + 
                                    "<p style='color:white'><b>Prescription used:</b><input type='checkbox' id='" + allPrescriptions[i].id + "'></p>";
                
            $("#recipes").append(newDiv);
            getCheckboxStatus(allPrescriptions[i]);
            setPrescriptionUsed(allPrescriptions[i]);
            }
        }
    });
}

function getCheckboxStatus(prescription){
    if(prescription.used){
        $("#" + prescription.id).prop('checked', true);
        $("#" + prescription.id).attr("disabled", true);
    }
    else
    $("#" + prescription.id).prop('checked', false);
}

function setPrescriptionUsed(prescription){
    $("#" + prescription.id).click(function(event){
        $.ajax({
            url: 'https://localhost:8080/api/setPrescriptionUsed/' + prescription.id,
            type: 'PUT',
            complete: function(data){
                if(data.status == 200)
                    alert("Success!")
                else    
                    alert(data.status);
            }
       });
    });
}
