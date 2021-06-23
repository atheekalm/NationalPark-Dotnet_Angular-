import { nationalpark } from './../models/nationalpark';
import { CreateNationalParkComponent } from './../forms/CreateNationalPark/CreateNationalPark.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NationalparkService } from '../services/nationalpark.service';

@Component({
  selector: 'app-NationalParks',
  templateUrl: './NationalParks.component.html',
  styleUrls: ['./NationalParks.component.css'],
})
export class NationalParksComponent implements OnInit {
  nationalparks: nationalpark[];

  constructor(public dialog: MatDialog,
    private nationalparkser: NationalparkService,
    ) {}
  ngOnInit() {
    this.loadNationalPark();
  }

  openModal() {
    this.dialog.open(CreateNationalParkComponent);
  }


  loadNationalPark() {
    this.nationalparkser.getnationalparks().subscribe(
      (trail: nationalpark[]) => {
        this.nationalparks = trail;
        console.log(this.nationalparks);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
