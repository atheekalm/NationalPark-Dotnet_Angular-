import { LoginComponent } from './Login/Login.component';
import { TrailsComponent } from './Trails/Trails.component';
import { HomeComponent } from './home/home/home.component';
import { Routes } from '@angular/router';
import { NationalParksComponent } from './NationalParks/NationalParks.component';
export const nroots: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Trails', component: TrailsComponent },
  { path: 'NationalPark', component: NationalParksComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
