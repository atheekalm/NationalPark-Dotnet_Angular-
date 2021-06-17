import { trails } from './../models/trails';
import { nationalpark } from './../models/nationalpark';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class NationalparkService {
  APIUrl = environment.baseUrl;
  constructor(private http: HttpClient) {}
  getnationalparks(): Observable<nationalpark[]> {
    return this.http.get<nationalpark[]>(this.APIUrl+'NationalPark');
  }
  getnationalpark(id:number):Observable<nationalpark>{
    return this.http.get<nationalpark>(this.APIUrl+'NationalPark/'+id);
  }
  gettrails(id:number):Observable<trails[]>{
    return this.http.get<trails[]>(this.APIUrl+'NationalPark/'+id);
  }
}
