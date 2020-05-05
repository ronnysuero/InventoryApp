import { Component } from "@angular/core";
import { LocationService } from "../location.service";
import { ListManager } from "prime-ngx-ar";

@Component({
  selector: "location-list",
  templateUrl: "./location-list.component.html"
})
export class LocationListComponent extends ListManager {
  constructor(public service: LocationService) {
    super(service);
  }
}
