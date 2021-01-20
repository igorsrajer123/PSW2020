window.onload = function(){
    getAllMedications();
}

function makeOrder(){
    $("#sendOrder").click(function(event){
        event.preventDefault();

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
            "id": 12321,
            "medications": medications,
            "used": false,
            "urgent": false
        }
        
        var transformedData = JSON.stringify(data);
        var meds = JSON.stringify({"medications" : medications});

        $.ajax({
            url: 'https://localhost:8080/api/createOrder',
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

            medsTable.append("<tr><td><button id='sendOrder'>Send</button></td></tr>");
            $("#table").append(medsTable);
            makeOrder();
        }
    });
}
