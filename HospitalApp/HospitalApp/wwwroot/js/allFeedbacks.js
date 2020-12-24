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

            getAllFeedbacks();
        }
    });
}

function getAllFeedbacks(){
    $.ajax({
        url: 'http://localhost:50324/getAllFeedbacks',
        type: 'GET',
        complete: function(data){
            var allFeedbacks = data.responseJSON;
            $("#feedbacks").empty();

            for(var i = 0; i < allFeedbacks.length; i++){
                getFeedbackPatient(allFeedbacks[i]);
                getFeedbackVisibility(allFeedbacks[i].id);
                setFeedbackVisibility(allFeedbacks[i].id);
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

function getFeedbackVisibility(feedbackId){
    $.ajax({
        url: 'http://localhost:50324/getFeedbackById/' + feedbackId,
        type: 'GET',
        complete: function(data){
            var feedback = data.responseJSON;

            if(feedback.isVisible)
                $("#" + feedbackId).prop('checked', true);
            
            if(!feedback.isVisible)
                $("#" + feedbackId).prop('checked', false);
        }
    });
}

function setFeedbackVisibility(feedbackId){
    $("#" + feedbackId).click(function(){

        if($("#" + feedbackId).is(":checked"))
            setFeedbackVisible(feedbackId);

        if(!$("#" + feedbackId).is(":checked"))
            setFeedbackInvisible(feedbackId);
    });
}

function setFeedbackVisible(feedbackId){
    $.ajax({
        url: 'http://localhost:50324/showFeedback/' + feedbackId,
        type: 'PUT',
        complete: function(data){
            if(data.status == 404)
                alert("Something went wrong!");
        }
    });
}

function setFeedbackInvisible(feedbackId){
    $.ajax({
        url: 'http://localhost:50324/hideFeedback/' + feedbackId,
        type: 'PUT',
        complete: function(data){
            if(data.status == 404)
                alert("Something went wrong!");
        }
    });
}
