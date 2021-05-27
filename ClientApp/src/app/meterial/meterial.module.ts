import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';

const MeterialComponents = [
  MatToolbarModule,
  MatCardModule
];
@NgModule({
  imports: [MeterialComponents],
  exports: [MeterialComponents],
})
export class MeterialModule {}
