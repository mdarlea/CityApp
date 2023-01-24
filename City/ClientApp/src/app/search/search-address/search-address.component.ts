import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn } from '@angular/forms';
import { tap } from 'rxjs';
import { SearchAddressClient } from 'src/app/autogenerated/clients';
import { PageEvent} from '@angular/material/paginator';
import { FormErrorStateMatcher } from 'src/app/shared/form-error-state-matcher';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-search-address',
  templateUrl: './search-address.component.html',
  styleUrls: ['./search-address.component.scss'],
  providers: [{
    provide: ErrorStateMatcher, useClass: FormErrorStateMatcher
  }],
})
export class SearchAddressComponent implements OnInit {
  public searchForm: FormGroup = new FormGroup({});
  public dataSource = new MatTableDataSource();;

  // paginator
  public length = 50;
  public pageSize = 10;
  public pageIndex = 0;
  public pageSizeOptions = [5, 10, 25];

  public addressColumns = ['neighborhoodEntityType', 'postalCode', 'name', 'numberOfBlockOfFlats', 'numberOfHouses'];

  constructor(private fb: FormBuilder, private readonly client: SearchAddressClient) {}

  public ngOnInit(): void {
    this.searchForm = this.fb.group({
      name: '',
      postalCode: '',
    }, {
      validators: [this.searchFormsValidator]
    });
  }

  public handlePageEvent(e: PageEvent) {
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
  }

  public onSubmit(): void {
    if (this.searchForm.valid) {
      const value = this.searchForm.value;

      this.client.searchAddress(value.name, value.postalCode, this.pageIndex + 1, this.pageSize).pipe(tap((results) => {
        this.dataSource.data = results.items ?? [];
      })).subscribe();
    }
  }

  private searchFormsValidator(g: AbstractControl): { [key: string]: any; } | null  {
    if (!g.get('name')?.value && !g.get('postalCode')?.value) {
      return {
        invalidSearch: true
      };
    }

    return null;
  }
}