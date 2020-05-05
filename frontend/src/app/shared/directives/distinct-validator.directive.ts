import { Directive, Input } from "@angular/core";
import {
  NG_VALIDATORS,
  AbstractControl,
  ValidationErrors,
  Validator
} from "@angular/forms";
// ,
@Directive({
  selector:
    "[distinct][formControlName],[distinct][formControl],[distinct][ngModel]",
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: DistinctValidatorDirective,
      multi: true
    }
  ]
})
export class DistinctValidatorDirective implements Validator {
  //
  @Input("distinct") validateControl: string;
  @Input() pivot: boolean;

  validate(control: AbstractControl): ValidationErrors | null {
    console.log(control);
    const value = control.value;
    const rightControl = control.root.get(this.validateControl);

    if (rightControl && value == rightControl.value && !this.pivot) {
      return { distinct: false };
    }

    // if (rightControl && value == rightControl.value && this.pivot) {
    //   return { distinct: false };
    // }

    // if (rightControl && value != rightControl.value && rightControl.errors) {
    // 	delete rightControl.errors['distinct'];
    // 	if (!Object.keys(rightControl.errors).length) {
    // 		rightControl.setErrors(null);
    // 	}

    // }

    // if (rightControl && value != rightControl.value && this.pivot && rightControl.errors) {
    //   delete rightControl.errors['distinct'];
    // 	if (!Object.keys(rightControl.errors).length) {
    // 		rightControl.setErrors(null);
    // 	}
    // }

    // if (rightControl && value == rightControl.value && this.pivot) {
    //   rightControl.setErrors({ distinct: false });
    // }

    return null;
  }
}
