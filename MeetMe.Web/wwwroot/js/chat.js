"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var time = new Date();
    
    var date =" " +  time.getDate() + "/" + time.getMonth() + " " + time.getHours() + ":" + time.getMinutes() + ":" + time.getSeconds() + " ";
    var dateSpan = document.createElement("SPAN");
   
    dateSpan.textContent = date;
    $(dateSpan).css({ "color": "grey", "font-size": "10px", "font-family": "sans-serif" });
    var userName = document.createElement("SPAN");
    userName.textContent =" " +  user + ": ";
    $(userName).css({ "font-size": "17px", "font-family": "sans-serif"});
    var div = document.createElement("div");
    $(div).addClass("message");
    $(div).addClass("col-12");

    var messageContent = document .createElement("SPAN");
    messageContent.textContent = msg;
    $(messageContent).css({"color":"blue"})
   
    div.appendChild(dateSpan);
    div.appendChild(userName);
    div.appendChild(messageContent);
    
    document.getElementById("messagesList").prepend(div);
  
   
    var messageInput = document.getElementById("messageInput");
    messageInput.value = "";

});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    
    var message = document.getElementById("messageInput").value;
    if (message !== "") {
        connection.invoke("SendMessage", message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    }
});

window.addEventListener("keydown", event => {
    if (event.keyCode === 13) {
        var message = document.getElementById("messageInput").value;
        
        if (message !== "") {
            connection.invoke("SendMessage", message).catch(function (err) {
                return console.error(err.toString());
            });
            event.preventDefault();
        }
    }
});


