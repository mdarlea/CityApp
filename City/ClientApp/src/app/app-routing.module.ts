import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';

const routes: Routes = [
  { path: 'search', loadChildren: () => import('./search/search.module').then(m => m.SearchModule),  canLoad: [AuthorizeGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
