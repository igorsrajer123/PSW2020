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

            if(myUser == undefined || myUser.role == "Administrator" || myUser.role == "Doctor"){
                alert("Cannot access this page!");
                window.location.href = "../index.html";
            }

            if(myUser.feedback != null){
                alert("You have already left your feedback!");
                window.location.href = "index.html";
            }
            
            addFeedback(myUser.id, myUser);
        }
    });
}

function addFeedback(userId, user){
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
            headers: {
                "Authorization": "Basic " + btoa(user.username + ":" + user.password)
              },
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

function cancelFeedback(){
    $("#cancel").click(function(event){
        event.preventDefault();

        window.location.href = "index.html";
    });
}