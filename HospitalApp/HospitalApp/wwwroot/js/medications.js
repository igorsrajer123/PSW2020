window.onload = function(){
    getAllMedications();
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
                medsTable.append("<tr><td>" + allMedications[i].name +   
                "</td><td>" + allMedications[i].quantity +
                "</td></tr>");

                $("#table").append(medsTable);
            }
        }
    });
}
