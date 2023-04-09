import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NeighborhoodsPageComponent } from './neighborhoods-page/neighborhoods-page.component';
import { NeighborhoodsRoutingModule } from './neighborhoods-routing.module';


@NgModule({
  declarations: [
    NeighborhoodsPageComponent,
  ],
  imports: [
    CommonModule,
    NeighborhoodsRoutingModule
  ]
})
export class NeighborhoodsModule { }
