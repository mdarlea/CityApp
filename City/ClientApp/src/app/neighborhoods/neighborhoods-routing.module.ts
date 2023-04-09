import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthorizeGuard } from "src/api-authorization/authorize.guard";
import { CreateBoulevardComponent } from "./create-boulevard/create-boulevard.component";
import { NeighborhoodsPageComponent } from "./neighborhoods-page/neighborhoods-page.component";
import { NeighborhoodsResolver } from "./neighborhoods-resolver";

const routes: Routes = [
  {
    path: '', component: NeighborhoodsPageComponent,
    children: [
      { path: '', redirectTo: 'create/boulevard', pathMatch: 'full' },
      {
        path: 'create/boulevard',
        component: CreateBoulevardComponent,
        canActivate: [AuthorizeGuard],
        resolve: {
          neighborhoods: NeighborhoodsResolver
        }
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NeighborhoodsRoutingModule { }
