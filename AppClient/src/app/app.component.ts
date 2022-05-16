import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { CallService } from './services/call.service';
import { SignalrService } from './services/signalr.service';
import { Call } from './models/call.model';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'AppClient';
  calls: Call[] = [];
  call: Call = {
    id: '',
    AgentNumber: '',
    CustomNumber: ''
  }

  constructor(private callService: CallService){

  }
  ngOnInit(): void {

   }

   onCall(){
    this.callService.call( )
    .subscribe(
      response => {
        console.log(response)
      }
    )
  }

  onAnswer(){
    this.callService.answerCall()
    .subscribe(
      response => {
        console.log(response)
      }
    )
  }

  onDropMe(){
    this.callService.dropMeCall()
    .subscribe(
      response => {
        console.log(response)
      }
    )
  }

 getAllCards(){
     this.callService.getAllCards()
     .subscribe(
       response => {
         this.calls = response;
       }
     )
   }

  onSubmit(){
    this.callService.makeCall(this.call)
    .subscribe(
      response => {
        console.log(response);
      }
    )
   }
}




//SignalR connection
/*const signalrConnection = new signalR.HubConnectionBuilder()
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
 // var ev = JSON.parse(eventMessage);
  console.log(eventMessage);
});

let messageCount = 0;

signalrConnection.on("onMessageReceived", function (eventMessage) {
    messageCount++;
    //var ev = JSON.parse(eventMessage);

    const msgCountH4 = document.getElementById("messageCount");
    msgCountH4.innerText = "Messages: " + messageCount.toString();
    const ul = document.getElementById("messages");
    const li = document.createElement("li");
    li.innerText = messageCount.toString();
    for (const property in eventMessage) {
        const newDiv = document.createElement("div");
        const classAttrib = document.createAttribute("style");
        classAttrib.value = "font-size: 80%;";
        newDiv.setAttributeNode(classAttrib);
        const newContent = document.createTextNode(`${property}: ${eventMessage[property]}`);
        newDiv.appendChild(newContent);
        li.appendChild(newDiv);
    }
    ul.appendChild(li);
});*/











