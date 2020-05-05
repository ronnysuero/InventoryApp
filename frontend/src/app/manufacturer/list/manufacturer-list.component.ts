import { Component } from "@angular/core";
import { ManufacturerService } from "../manufacturer.service";
import { ListManager } from "prime-ngx-ar";

@Component({
  selector: "manufacturer-list",
  templateUrl: "./manufacturer-list.component.html"
})
export class ManufacturerListComponent extends ListManager {
  constructor(public service: ManufacturerService) {
    super(service);
  }
}
