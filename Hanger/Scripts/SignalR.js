$.connection.hub.start()
    .done(function () {
        console.log("IT WORKED!")
        $.connection.myHub.server.announce("Connected!");
    })
    .fail(function () { alert("Error!!!!") });

$.connection.myHub.client.announce = function (message) {

    $("h2").append(message);
}

