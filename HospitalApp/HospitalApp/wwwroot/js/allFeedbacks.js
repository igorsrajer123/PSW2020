window.onload = function(){
    authenticateUser();
}

function authenticateUser(){
    $.ajax({
        url: 'http://localhost:50324/getSession',
        type: 'GET',
        complete: function(data){
            var myUser = data.responseJSON;

            if(myUser == undefined || myUser.role == "Patient"){
                alert("Cannot access this page!");
                window.location.href = "../index.html";
            }

            getAllFeedbacks(myUser);
        }
    });
}

function getAllFeedbacks(user){
    $.ajax({
        url: 'http://localhost:50324/getAllFeedbacks',
        type: 'GET',
        headers: {
            "Authorization": "Basic " + btoa(user.username + ":" + user.password)
        },
        complete: function(data){
            var allFeedbacks = data.responseJSON;

            $("#feedbacks").empty();
            for(var i = 0; i < allFeedbacks.length; i++){
                getFeedbackPatient(allFeedbacks[i]);
                getFeedbackVisibility(allFeedbacks[i].id, user);    
            }
        }
    });
}

function getFeedbackPatient(feedback){
    $.ajax({
        url: 'http://localhost:50324/getPatientById/' + feedback.patientId,
        type: 'GET',
        complete: function(data){
            var patient = data.responseJSON;

            var newDiv = document.createElement("div");
            newDiv.innerHTML = "<p>Feedback by:" + patient.firstName + " " + patient.lastName + "</p>" +
                                    "<p>" + feedback.date + "</p>" + 
                                    "<textarea disabled='true'>" + feedback.text + "</textarea>" +
                                    "<p>Show Feedback:<input type='checkbox' id='" + feedback.id + "'></p>";
                
            $("#feedbacks").append(newDiv);
        }
    });
}

function getFeedbackVisibility(feedbackId, user){
    $.ajax({
        url: 'http://localhost:50324/getFeedbackById/' + feedbackId,
        type: 'GET',
        async: true,
        complete: function(data){
            var feedback = data.responseJSON;

            if(feedback.isVisible)
                $("#" + feedbackId).prop('checked', true);
            
            if(!feedback.isVisible)
                $("#" + feedbackId).prop('checked', false);

            setFeedbackVisibility(feedbackId, user);
        }
    });
}

function setFeedbackVisibility(feedbackId, user){
    $("#" + feedbackId).click(function(){

        if($("#" + feedbackId).is(":checked"))
            setFeedbackVisible(feedbackId, user);

        if(!$("#" + feedbackId).is(":checked"))
            setFeedbackInvisible(feedbackId, user);
    });
}

function setFeedbackVisible(feedbackId, user){
    alert("Visible!");
    $.ajax({
        url: 'http://localhost:50324/showFeedback/' + feedbackId,
        type: 'PUT',
        headers: {
            "Authorization": "Basic " + btoa(user.username + ":" + user.password)
          },
        complete: function(data){
            if(data.status == 404)
                alert("Something went wrong!");
        }
    });
}

function setFeedbackInvisible(feedbackId, user){
    alert("Invisible!");
    $.ajax({
        url: 'http://localhost:50324/hideFeedback/' + feedbackId,
        type: 'PUT',
        headers: {
            "Authorization": "Basic " + btoa(user.username + ":" + user.password)
          },
        complete: function(data){
            if(data.status == 404)
                alert("Something went wrong!");
        }
    });
}
