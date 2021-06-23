import { LoginComponent } from './../../Login/Login.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(
    public dialog:MatDialog
  ) {}
  openModal(){
    this.dialog.open(LoginComponent,{
      height: '310px',
      width: '500px',
    })
  }
  ngOnInit() {
  }

}
