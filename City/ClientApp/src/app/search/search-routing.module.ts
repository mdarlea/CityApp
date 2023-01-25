import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AddressesComponent } from './addresses/addresses.component';
import { NeighborhoodsComponent } from './neighborhoods/neighborhoods.component';
import { SearchAddressComponent } from './search-address/search-address.component';
import { SearchComponent } from './search.component';

const routes: Routes = [
  {
    path: '', component: SearchComponent,
    children: [
      { path: '', redirectTo: 'search-address', pathMatch: 'full' },
      { path: 'search-address', component: SearchAddressComponent, canActivate: [AuthorizeGuard]},
      { path: 'addresses', component: AddressesComponent, canActivate: [AuthorizeGuard]},
      { path: 'neighboorhoods', component: NeighborhoodsComponent, canActivate: [AuthorizeGuard]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SearchRoutingModule { }
