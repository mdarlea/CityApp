import { Component, OnInit } from '@angular/core';
import { WeatherForecastClient } from './autogenerated/clients';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'City';

  public constructor(private readonly client: WeatherForecastClient) {

  }

  public ngOnInit(): void {
    this.client.get().subscribe();
  }

}
