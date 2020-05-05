import { Component } from "@angular/core";
import { AreaService } from "../area.service";
import { FormManager } from "prime-ngx-ar";

@Component({
  selector: "area-form",
  templateUrl: "./area-form.component.html",
})
export class AreaFormComponent extends FormManager {
  constructor(public service: AreaService) {
    super(service);
  }
}
