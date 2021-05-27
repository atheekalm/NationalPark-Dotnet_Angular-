import { Component, Input, OnInit } from '@angular/core';
import { nationalpark } from 'src/app/models/nationalpark';

@Component({
  selector: 'app-nationalpark',
  templateUrl: './nationalpark.component.html',
  styleUrls: ['./nationalpark.component.css']
})
export class NationalparkComponent implements OnInit {
@Input() nationalparkInput:nationalpark;
  constructor() { }

  ngOnInit() {
  }

}
