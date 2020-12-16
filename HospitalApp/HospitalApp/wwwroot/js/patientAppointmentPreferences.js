window.onload = function(){
    authenticateUser();
    checkOnlyOne();
    validation();
    setFinalDate();
    redirect();
    $("#datepicker2").attr("disabled", true);
    $("#datepicker1").datepicker({minDate:0});
    $("#datepicker2").datepicker({minDate:0});
}

function checkOnlyOne(){
    $(".check").on("change", function(){
        $(this).siblings("input:checkbox").prop("checked", false);
    });
}

function validation(){
    if($("#datepicker2").val() == "" || $("#datepicker1").val() == "")
        $("#checkForAppointment").attr("disabled", true);
    
    if($("#datepicker1").val() != "" && $("#datepicker2").val() != "")
        $("#checkForAppointment").attr("disabled", false);
    
    $("#datepicker1").on("change", function(e){
            if($("#datepicker1").val() != "" && $("#datepicker2").val() != "")
                $("#checkForAppointment").attr("disabled", false); 
            else    
                $("#checkForAppointment").attr("disabled", true); 
    });
    
    $("#datepicker2").on("change", function(e){
            if($("#datepicker1").val() != "" && $("#datepicker2").val() != "")
                $("#checkForAppointment").attr("disabled", false);
            else    
                $("#checkForAppointment").attr("disabled", true);  
    });   
}

function setFinalDate(){
    $("#datepicker1").bind("change", function(e){
        if($("#datepicker1").val() == "")
            $("#datepicker2").attr("disabled", true);
        else {
            $("#datepicker2").attr("disabled", false); 
            $("#datepicker2").datepicker('option', 'minDate', new Date($("#datepicker1").val()));
        }
    });
}

function redirect(){
    $("#checkForAppointment").click(function(event){
        event.preventDefault();
        window.location.href="chooseAppointment.html?from=" + $("#datepicker1").val() +"&to=" + $("#datepicker2").val();
    });
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
        }
    });
}

