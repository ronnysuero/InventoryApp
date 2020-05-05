import { Component, OnInit } from "@angular/core";
import { ComponentManager, ModalFormService } from "prime-ngx-ar";
import { ManufacturerModel } from "./manufacturer.model";
import { ManufacturerService } from "./manufacturer.service";
import { ManufacturerFormComponent } from "./form/manufacturer-form.component";

@Component({
  selector: "manufacturer",
  templateUrl: "./manufacturer.component.html"
})
export class ManufacturerComponent extends ComponentManager<ManufacturerModel>
  implements OnInit {
  constructor(
    public service: ManufacturerService,
    public modalFormService: ModalFormService
  ) {
    super(service);
  }

  ngOnInit() {
    super.ngOnInit();
    this.modalContent = ManufacturerFormComponent;
  }
}
