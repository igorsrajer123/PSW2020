$(document).ready(function(){

    $.ajax({
        method: 'GET',
        url: 'http://localhost:50324/getUser',
        complete: function (data) {
            welcomeMessage(data.responseJSON);
            userOptions(data.responseJSON);
        }
    });
});

function welcomeMessage(user){
    if (user == undefined) {
        $("#currentUser").hide();
        $("#user").hide();
    } else {
        $("#logo").append("<label id='currentUser'>Current user: </label><label id='user'></label>");
        $("#currentUser").show();
        $("#user").text(user.username);
    }
}

function userOptions(user){
    if(user == undefined){
        $("#login").show();
        $("#register").show();
        $("#logout").hide();
        $("#profile").hide();
        $("#users").hide();
    }else {
        $("#login").hide();
        $("#register").hide();
    }
}