$(document).ready(function(){

    getAllUsers();

});

function getAllUsers(){

    $.ajax({
        url: 'http://localhost:50324/getAllUsers',
        type: 'GET',
        complete: function(data){

            var allUsers = data.responseJSON;

            var usersTable = $("#table tbody");
            usersTable.empty();

            for(var i = 0; i < allUsers.length; i++){
                if(allUsers[i].type == 0)
                    usersTable.append("<tr><td>" + allUsers[i].username +  
                                    "</td><td>" + allUsers[i].password + 
                                    "</td><td>" + allUsers[i].firstName +
                                    "</td><td>" + allUsers[i].lastName +
                                    "</td><td>" + "Administrator" +
                                    "</td><td>" + allUsers[i].isDeleted + 
                                    "</td></tr>");
                else
                    usersTable.append("<tr><td>" + allUsers[i].username +  
                                    "</td><td>" + allUsers[i].password + 
                                    "</td><td>" + allUsers[i].firstName +
                                    "</td><td>" + allUsers[i].lastName +
                                    "</td><td>" + "Patient" +
                                    "</td><td>" + allUsers[i].isDeleted + 
                                    "</td></tr>");

                $("#table").append(usersTable);
            }
        }
    });
}