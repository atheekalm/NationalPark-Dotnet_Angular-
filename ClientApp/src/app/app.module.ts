import { CreateTrailComponent } from './forms/CreateTrail/CreateTrail.component';
import { CreateNationalParkComponent } from './forms/CreateNationalPark/CreateNationalPark.component';
import { RouterModule } from '@angular/router';
import { NavComponent } from './home/nav/nav.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MeterialModule } from './meterial/meterial.module';
import { HomeComponent } from './home/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { NationalparkComponent } from './home/nationalpark/nationalpark.component';
import { LoginComponent } from './Login/Login.component';
import { nroots } from './routes';
import { NationalParksComponent } from './NationalParks/NationalParks.component';
import { TrailsComponent } from './Trails/Trails.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    NationalparkComponent,
    LoginComponent,
    NationalParksComponent,
    TrailsComponent,
    CreateNationalParkComponent,
    CreateTrailComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MeterialModule,
    HttpClientModule,
    RouterModule.forRoot(nroots),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
