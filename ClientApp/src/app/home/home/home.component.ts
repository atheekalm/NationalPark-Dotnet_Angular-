import { nationalpark } from './../../models/nationalpark';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NationalparkService } from 'src/app/services/nationalpark.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
nationalparks:nationalpark[];
  constructor(private nationalparkser:NationalparkService,private http:HttpClient) { }

  ngOnInit() {
   this.loadNationalParks()
  }
loadNationalParks(){
  this.nationalparkser.getnationalparks().subscribe(
    (nationalparks:nationalpark[])=>{
      this.nationalparks=nationalparks;
    },(error)=>{
      console.log(error)
    }
  )
}
}
