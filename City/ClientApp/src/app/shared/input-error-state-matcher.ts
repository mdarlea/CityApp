import { FormControl, FormGroupDirective, NgForm } from "@angular/forms";
import { ErrorStateMatcher } from "@angular/material/core";

export class InputErrorStateMatcher implements ErrorStateMatcher {
  public isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean
  {
    return !!(form?.invalid && (form?.dirty || form?.touched) && control?.invalid && (control?.dirty || control?.touched))
  }
}
