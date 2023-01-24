import { ReactiveFormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table'
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from "@angular/material/button";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchAddressComponent } from './search-address.component';

@NgModule({
  declarations: [
    SearchAddressComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatPaginatorModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
  ],
  exports: [ SearchAddressComponent ],
})
export class SearchAddressModule { }
