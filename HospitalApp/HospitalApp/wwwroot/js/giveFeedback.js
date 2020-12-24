window.onload = function(){
    authenticateUser();
    cancelFeedback();
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

            getAllFeedbacks(myUser.id);
            addFeedback(myUser.id);
        }
    });
}

function addFeedback(userId){
    $("#confirm").click(function(event){
        event.preventDefault();

        var data = {
            "date": new Date().toLocaleString(),
            "patientId": userId,
            "text": $("#text").val(),
            "isVisible": false,
            "isDeleted": false
        }

        var transformedData = JSON.stringify(data);

        $.ajax({
            url: 'http://localhost:50324/addFeedback',
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
    });
}

function getAllFeedbacks(userId){
    $.ajax({
        url: 'http://localhost:50324/getAllFeedbacks',
        type: 'GET',
        complete: function(data){
            var allFeedbacks = data.responseJSON;

            for(var i = 0; i < allFeedbacks.length; i++){
                if(allFeedbacks[i].patientId == userId){
                    alert("You have already left your feedback!");
                    window.location.href = "index.html";
                }
            }
        }
    });
}

function cancelFeedback(){
    $("#cancel").click(function(event){
        event.preventDefault();

        window.location.href = "index.html";
    });
}