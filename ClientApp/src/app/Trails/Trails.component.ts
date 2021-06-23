import { CreateTrailComponent } from './../forms/CreateTrail/CreateTrail.component';
import { LoginComponent } from './../Login/Login.component';
import { Component, OnInit } from '@angular/core';
import { trails } from '../models/trails';
import { NationalparkService } from '../services/nationalpark.service';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-Trails',
  templateUrl: './Trails.component.html',
  styleUrls: ['./Trails.component.css'],
})
export class TrailsComponent implements OnInit {
  trails: trails[];
  constructor(
    private nationalparkser: NationalparkService,
    public dialog:MatDialog
  ) {}



  ngOnInit() {
    this.loadTrails();
  }

  openModal(){
    this.dialog.open(CreateTrailComponent)
  }

  loadTrails() {
    this.nationalparkser.getAlltrails().subscribe(
      (trail: trails[]) => {
        this.trails = trail;
        console.log(this.trails);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
