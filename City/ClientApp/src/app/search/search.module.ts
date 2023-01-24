import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SearchRoutingModule } from './search-routing.module';
import { SearchComponent } from './search.component';
import { SearchAddressModule } from './search-address/search-address.module';
import { NeighborhoodsComponent } from './neighborhoods/neighborhoods.component';


@NgModule({
  declarations: [
    SearchComponent

  ],
  imports: [
    CommonModule,
    SearchAddressModule,
    NeighborhoodsComponent,
    SearchRoutingModule
  ]
})
export class SearchModule { }
