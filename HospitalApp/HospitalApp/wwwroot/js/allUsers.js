$(document).ready(function(){
    authenticateUser();
});

function getAllUsers(user){
    $.ajax({
        url: 'http://localhost:50324/getAllUsers',
        type: 'GET',
        headers: {
            "Authorization": "Basic " + btoa(user.username + ":" + user.password)
          },
        complete: function(data){

            var allUsers = data.responseJSON;

            var usersTable = $("#table tbody");
            usersTable.empty();

            for(var i = 0; i < allUsers.length; i++){
             
                    usersTable.append("<tr><td>" + allUsers[i].username +   
                                    "</td><td>" + allUsers[i].firstName +
                                    "</td><td>" + allUsers[i].lastName +
                                    "</td><td>" + allUsers[i].address +
                                    "</td><td>" + allUsers[i].phoneNumber +
                                    "</td><td>" + allUsers[i].role +
                                    "</td><td>" + allUsers[i].isDeleted + 
                                    "</td></tr>");

                    $("#table").append(usersTable);
            }
        }
    });
}

function authenticateUser(){
    $.ajax({
        url: 'http://localhost:50324/getSession',
        type: 'GET',
        complete: function(data){
            var myUser = data.responseJSON;
            if(myUser == undefined){
                alert("Cannot access this page!");
                window.location.href = "../index.html";
            }

            getAllUsers(myUser);
        }
    });
}