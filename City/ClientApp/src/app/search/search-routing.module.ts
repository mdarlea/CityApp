import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { NeighborhoodsComponent } from './neighborhoods/neighborhoods.component';
import { SearchAddressComponent } from './search-address/search-address.component';
import { SearchComponent } from './search.component';

const routes: Routes = [
  {
    path: '', component: SearchComponent,
    children: [
      { path: '', redirectTo: 'address', pathMatch: 'full' },
      { path: 'address', component: SearchAddressComponent, canActivate: [AuthorizeGuard]},
      { path: 'neighboorhoods', component: NeighborhoodsComponent, canActivate: [AuthorizeGuard]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SearchRoutingModule { }
