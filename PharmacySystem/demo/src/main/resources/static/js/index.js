window.onload = function(){
	redirect();
}

function redirect(){
	$("#recipes").click(function(event){
		event.preventDefault();
		window.location.href = "recipes.html"
	});
	
	$("#orders").click(function(event){
		event.preventDefault();
		window.location.href = "orders.html"
	});
}