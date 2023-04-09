import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NeighborhoodsRoutingModule } from '../neighborhoods-routing.module';

@Component({
  selector: 'app-neighborhoods-page',
  templateUrl: './neighborhoods-page.component.html',
  styleUrls: ['./neighborhoods-page.component.scss'],
})
export class NeighborhoodsPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
