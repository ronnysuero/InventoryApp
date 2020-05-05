import { Component, OnInit } from "@angular/core";
import { ComponentManager, ModalFormService } from "prime-ngx-ar";
import { AreaModel } from "./area.model";
import { AreaService } from "./area.service";
import { AreaFormComponent } from "./form/area-form.component";

@Component({
  selector: "area",
  templateUrl: "./area.component.html"
})
export class AreaComponent extends ComponentManager<AreaModel>
  implements OnInit {
  constructor(
    public service: AreaService,
    public modalFormService: ModalFormService
  ) {
    super(service);
  }

  ngOnInit() {
    super.ngOnInit();
    this.modalContent = AreaFormComponent;
  }
}
