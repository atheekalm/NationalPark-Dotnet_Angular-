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
  @Input() trailsInput:trails;
  trails: trails[];
  constructor(private nationalService: NationalparkService) {}

  ngOnInit() {
    // this.loadTrails();
  }

  loadTrails() {
    this.nationalService.getAlltrails().subscribe(
      (trail: trails[]) => {
        this.trails = trail;
        console.log(this.trails)
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
