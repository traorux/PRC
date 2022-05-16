

const signalrConnection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5000/signalr", {
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    })
    .configureLogging(signalR.LogLevel.Information)
    .build();

signalrConnection.start().then(function () {
    console.log("SignalR Hub Connected");
}).catch(function (err) {
    return console.error(err.toString());
});

signalrConnection.on("onMessageReceived", function (eventMessage) {
  var ev = JSON.parse(eventMessage);
    console.log(ev);
    console.log(ev.CallerNumber);
});

let messageCount = 0;

signalrConnection.on("onMessageReceived", function (eventMessage) {
    messageCount++;
    var ev = JSON.parse(eventMessage);

    //const msgCountH4 = document.getElementById("messageCount");
    //msgCountH4.innerText = "Messages: " + messageCount.toString();
    const ul = document.getElementById("messages");
    const li = document.createElement("li");
    //li.innerText = messageCount.toString();
    for (const property in ev) {
        const newDiv = document.createElement("div");
        const classAttrib = document.createAttribute("style");
        classAttrib.value = "font-size: 80%;";
        newDiv.setAttributeNode(classAttrib);
        const newContent = document.createTextNode(`${property}: ${ev[property]}`);
        newDiv.appendChild(newContent);
        li.appendChild(newDiv);
    }
    ul.appendChild(li);
    //window.scrollTo(0, document.body.scrollHeight);
});


