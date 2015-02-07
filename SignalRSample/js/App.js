var chatHub = $.connection.chatHub;

var demohub = $.connection.demoHub;

chatHub.client.writeMessage = function (fromUser, message) {
    var template = "<div class=\"panel panel-default\">" +
                            "<div class=\"panel-heading\">" +
                                "<h3 class=\"panel-title\">" + fromUser + " says:</h3>" +
                            "</div>" +
                            "<div class=\"panel-body\">" + message + "</div></div>";

    $("#messageList").prepend(template);
};

chatHub.client.alertMe = function () { console.log("Send Data") }

demohub.client.SendMsg = function (msg) {
    var template = "<div class=\"panel panel-default\">" +
                              "<div class=\"panel-heading\">" +
                                  "<h3 class=\"panel-title\">" + "From Demo Hub" + " says:</h3>" +
                              "</div>" +
                              "<div class=\"panel-body\">" + msg + "</div></div>";

    $("#messageList").prepend(template);
}


$("#sendMessage").on("click", function () {
    var fromUser = $("#personName").val();
    var message = $("#personMessage").val();

    chatHub.server.broadcastMessage(fromUser, message);
});

$("#btnMyMethod").on("click", function () {
    chatHub.server.myMethod(
        {
            id: "sample"
        }).done(function(message){console.log(message)})
})

$("#btnMyMethodParameter").on("click", function () {
    demohub.server.sendMessage("Sending Sample").done(function (msg) { console.log(msg) })
})

$.connection.hub.connectionSlow(function () {
    console.log("Slow detection detected");
});

$.connection.hub.stateChanged(function (state) {
    if (state.newState == 0)
        console.log("STATE: Connecting...");
    else if (state.newState == 1)
        console.log("STATE: Connected...");
    else if (state.newState == 2)
        console.log("STATE: Reconnecting...");
    else if (state.newState == 3)
        console.log("STATE: Disconnected...");
    else
        console.log("STATE: Unknown");
});


var options = {
    transport:['webSockets','longPolling']
}

$.connection.hub.logging = true;

//var deferredStart = $.connection.hub.start(options);

var deferredStart = $.connection.hub.start();

//Done is used when we Expect some return value

deferredStart.done(function () {
    console.log("My connection id is " + $.connection.hub.id);
});
deferredStart.fail(function () {
    // error
});