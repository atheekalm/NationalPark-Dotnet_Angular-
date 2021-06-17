import { trails } from './../../models/trails';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-Trails',
  templateUrl: './Trails.component.html',
  styleUrls: ['./Trails.component.css']
})
export class TrailsComponent implements OnInit {
@Input() trailInput:trails
  constructor() { }

  ngOnInit() {
  }

}
