import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { tap } from 'rxjs';
import { GetNeighborhoodsClient } from 'src/app/autogenerated/clients';

@Component({
  selector: 'app-neighborhoods',
  templateUrl: './neighborhoods.component.html',
  styleUrls: ['./neighborhoods.component.scss'],
  standalone: true,
  imports: [CommonModule, MatTableModule,  MatPaginatorModule ],
})
export class NeighborhoodsComponent implements OnInit {
  public dataSource = new MatTableDataSource();;

  // paginator
  public length = 50;
  public pageSize = 10;
  public pageIndex = 0;
  public pageSizeOptions = [5, 10, 25];

  public displayColumns: string[] = ['neighborhood', 'type', 'numberOfAddressType'];

  public constructor(private readonly client: GetNeighborhoodsClient) { }

  public ngOnInit(): void {
    this.search();
  }

  public handlePageEvent(e: PageEvent) {
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;

    this.search();
  }

  private search(): void {
    this.client.getNeighborhoods(this.pageIndex + 1, this.pageSize).pipe(tap((result) => {
      this.dataSource.data = result.items ?? [];
    })).subscribe();
  }
}
