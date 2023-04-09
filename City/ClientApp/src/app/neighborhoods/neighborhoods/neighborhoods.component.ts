import { FocusMonitor } from '@angular/cdk/a11y';
import { CommonModule } from '@angular/common';
import { Component, ElementRef, Host, HostBinding, Input, OnDestroy, OnInit, SkipSelf } from '@angular/core';
import { AbstractControl, ControlContainer, ControlValueAccessor, FormBuilder, FormControl, FormControlName, FormGroup, FormGroupDirective, FormsModule, NgControl, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { MatFormFieldModule, MatFormFieldControl } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { Subject } from 'rxjs';
import { parentFormGroupProvider } from 'src/app/shared/form-group-container';
import { Neighborhood } from '../models/neighborhood';
import { ValidationConfig } from '../models/validation-config';

@Component({
  selector: 'app-neighborhoods',
  templateUrl: './neighborhoods.component.html',
  styleUrls: ['./neighborhoods.component.scss'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatSelectModule, MatFormFieldModule],
  providers: [{provide: MatFormFieldControl, useExisting: NeighborhoodsComponent}],
})
export class NeighborhoodsComponent extends MatFormFieldControl<number> implements OnInit, ControlValueAccessor, OnDestroy  {
  @Input() neighborhoods: Neighborhood[] | null = [];
  @Input() validationConfigs: ValidationConfig[] = [];

  onChange: any = () => {}
  onTouch: any = () => {}

  @HostBinding() override id = `neighborhoods-${ NeighborhoodsComponent.nextId++ }`;

  formControl: FormControl = new FormControl();

  override stateChanges = new Subject<void>();

  private static nextId = 0;

  constructor(public override ngControl: NgControl,
    private readonly focusMonitor: FocusMonitor,
    private readonly elementRef: ElementRef)
  {
    super();
    ngControl.valueAccessor = this;
  }

  ngOnInit(): void {
    this.focusMonitor
    .monitor(this.elementRef.nativeElement, true)
    .subscribe(origin => {
      this.focused = !!origin;
      this.stateChanges.next();
    });

    if(this.ngControl instanceof FormControlName) {
      this.formControl = this.ngControl.control;
    }
  }

  ngOnDestroy(): void {
    this.stateChanges.complete();
  }

  writeValue(obj: any): void {
    this.setValue(obj);
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouch = fn;
  }

  setDescribedByIds(ids: string[]): void {
    throw new Error('Method not implemented.');
  }
  onContainerClick(event: MouseEvent): void {
    throw new Error('Method not implemented.');
  }

  private setValue(value: number | null) {
    this.value = value;
    this.stateChanges.next();
  }
}
