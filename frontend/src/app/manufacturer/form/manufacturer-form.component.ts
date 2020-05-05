import { Component } from "@angular/core";
import { ManufacturerService } from "../manufacturer.service";
import { FormManager } from "prime-ngx-ar";

@Component({
  selector: "manufacturer-form",
  templateUrl: "./manufacturer-form.component.html",
})
export class ManufacturerFormComponent extends FormManager {
  constructor(public service: ManufacturerService) {
    super(service);
  }
}
