import { nationalpark } from './../../models/nationalpark';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NationalparkService } from 'src/app/services/nationalpark.service';
import { trails } from 'src/app/models/trails';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  nationalparks: nationalpark[];
  trail: trails[];
  constructor(
    private nationalparkser: NationalparkService,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.loadNationalParks();
    // this.loadTrails();
  }

  loadNationalParks() {
    this.nationalparkser.getnationalparks().subscribe(
      (nationalparks: nationalpark[]) => {
        this.nationalparks = nationalparks;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  // loadTrails() {
  //   this.nationalparkser.getAlltrails().subscribe(
  //     (trail: trails[]) => {
  //       this.trail = trail;
  //       console.log(this.trail)

  //     },
  //     (error) => {
  //       console.log(error);
  //     }
  //   );
  // }
}