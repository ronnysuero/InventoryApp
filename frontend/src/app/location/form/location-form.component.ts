import { Component } from "@angular/core";
import { LocationService } from "../location.service";
import { FormManager } from "prime-ngx-ar";

@Component({
  selector: "location-form",
  templateUrl: "./location-form.component.html",
})
export class LocationFormComponent extends FormManager {
  constructor(public service: LocationService) {
    super(service);
  }
}
