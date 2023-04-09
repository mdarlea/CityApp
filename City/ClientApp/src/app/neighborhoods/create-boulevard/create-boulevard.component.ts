import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ActivatedRoute } from '@angular/router';
import { map, Observable, of } from 'rxjs';
import { InputErrorStateMatcher } from 'src/app/shared/input-error-state-matcher';
import { Neighborhood } from '../models/neighborhood';
import { NeighborhoodsComponent } from '../neighborhoods/neighborhoods.component';

@Component({
  selector: 'app-create-boulevard',
  templateUrl: './create-boulevard.component.html',
  styleUrls: ['./create-boulevard.component.scss'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatButtonModule, MatFormFieldModule, NeighborhoodsComponent],
  providers: [{
    provide: ErrorStateMatcher, useClass: InputErrorStateMatcher
  }],
})
export class CreateBoulevardComponent implements OnInit {
  neighborhoods: Observable<Neighborhood[]> = of([]);

  createBoulevardForm: FormGroup = new FormGroup({});

  constructor(private route: ActivatedRoute, private fb: FormBuilder) { }

  get selectedNeighborhood() {
    return this.createBoulevardForm.get('selectedNeighborhood');
  }

  ngOnInit(): void {
    // this.createBoulevardForm = this.fb.group({
    //   'boulevard': this.fb.group({
    //     'id': [0, [Validators.required]],
    //     'name': ['', [Validators.required]],
    //   }),
    //   'selectedNeighborhood': [null, [Validators.required]]
    // });
    this.createBoulevardForm = new FormGroup({
      boulevard: new FormGroup({
        id: new FormControl(null, [Validators.required]),
        name: new FormControl('', [Validators.required])
      }),
      selectedNeighborhood: new FormControl(null, [Validators.required])
    });

    this.neighborhoods = this.route.data.pipe(map(d => d['neighborhoods']));
  }

  onSubmit() {
    const data = this.createBoulevardForm.value;
  }

}
