import { Component } from "@angular/core";
import { AreaService } from "../area.service";
import { ListManager } from "prime-ngx-ar";

@Component({
  selector: "area-list",
  templateUrl: "./area-list.component.html"
})
export class AreaListComponent extends ListManager {
  constructor(public service: AreaService) {
    super(service);
  }
}
