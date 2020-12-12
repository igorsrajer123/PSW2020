$(document).ready(function() {
    logout();
});

function logout(){
    $("#logout").click(function (event) {
            event.preventDefault();

            $.ajax({
                method: 'DELETE',
                url: 'http://localhost:50324/logout',
                complete: function (data) {
                    if (data.status == 200)
                        window.location.href = "index.html";
                    else
                        alert("Something went wrong, try again!");
                }
            });
        });
}