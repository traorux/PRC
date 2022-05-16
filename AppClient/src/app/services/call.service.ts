import { Injectable } from '@angular/core';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Call } from '../models/call.model';


@Injectable({
  providedIn: 'root'
})

export class CallService {
  baseUrl = 'http://localhost:5000/api/call/';


  constructor(private http: HttpClient) { }


  getAllCards(): Observable<Call[]>{
    return this.http.get<Call[]>(this.baseUrl);
  }

  makeCall(call: Call):Observable<Call[]>{

    return this.http.post<Call[]>(this.baseUrl + "MakeCall", call)
  }
  answerCall(){
    return this.http.get(this.baseUrl + "AnswerCall")
  }
  dropMeCall(){
    return this.http.get(this.baseUrl + "DropMeCall")
  }

  call(){
    return this.http.get(this.baseUrl)
  }
}
