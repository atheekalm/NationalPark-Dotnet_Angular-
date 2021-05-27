import { trails } from './../models/trails';
import { nationalpark } from './../models/nationalpark';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NationalparkService {
  constructor(private http: HttpClient) {}
  getnationalparks(): Observable<nationalpark[]> {
    return this.http.get<nationalpark[]>('https://localhost:5001/NationalPark');
  }
  getnationalpark(id:number):Observable<nationalpark>{
    return this.http.get<nationalpark>('https://localhost:5001/NationalPark/'+id);
  }
  gettrails(id:number):Observable<trails>{
    return this.http.get<trails>('https://localhost:5001/NationalPark/'+id);
  }
}
