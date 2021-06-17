import { Component, Input, OnInit } from '@angular/core';
import { nationalpark } from 'src/app/models/nationalpark';
import { trails } from 'src/app/models/trails';
import { NationalparkService } from 'src/app/services/nationalpark.service';

@Component({
  selector: 'app-nationalpark',
  templateUrl: './nationalpark.component.html',
  styleUrls: ['./nationalpark.component.css'],
})
export class NationalparkComponent implements OnInit {
  @Input() nationalparkInput: nationalpark;
  traildata: trails[];
  constructor(private nationalService:NationalparkService) {}

  ngOnInit() {
  this.loadTrails()
  }

  loadTrails() {
    this.nationalService.gettrails(5).subscribe(
      (trail: trails[]) => {
        this.traildata = trail
      },
      (error) => {
        console.log(error);
      }
    );
  }



  
}