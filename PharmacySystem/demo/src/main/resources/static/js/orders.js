window.onload = function(){
	getAllOrders();
}

function getAllOrders(){
    $.ajax({
        url: 'https://localhost:8080/api/orders',
        type: 'GET',
        complete: function(data){
            var allOrders = data.responseJSON;
            
            for(var i = 0; i < allOrders.length; i++){
                var newDiv = document.createElement("div");
                newDiv.innerHTML = "<p style='color:white'><b>Order Id:</b></p>" +
                                    "<p>" + allOrders[i].id + "</p><br/>" +
                                    "<p style='color:white'><b>" + "Medications:" + "</b></p>" + 
                                    "<p>" + allOrders[i].medications + "</p><br/>" +
                                    "<p style='color:white'><b>" + "Urgent?:" + "</b></p>" + 
                                    "<p>" + allOrders[i].urgent + "</p><br/>" + 
                                    "<p style='color:white'><b>Order delivered:</b><input type='checkbox' id='" + allOrders[i].id + "'></p>";
                
            $("#orders").append(newDiv);
            getCheckboxStatus(allOrders[i]);
            setOrderUsed(allOrders[i]);
            }
        }
    });
}

function getCheckboxStatus(order){
    if(order.used){
        $("#" + order.id).prop('checked', true);
        $("#" + order.id).attr("disabled", true);
    }
    else
    $("#" + order.id).prop('checked', false);
}

function setOrderUsed(order){
    $("#" + order.id).click(function(event){
        $.ajax({
            url: 'https://localhost:8080/api/setOrderUsed/' + order.id,
            type: 'PUT',
            complete: function(data){
                if(data.status == 200)
                    alert("Success!")
                else    
                    alert(data.status);
            }
       });
    });
}
