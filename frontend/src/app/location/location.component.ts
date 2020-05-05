import { Component, OnInit } from "@angular/core";
import { ComponentManager, ModalFormService } from "prime-ngx-ar";
import { LocationModel } from "./location.model";
import { LocationService } from "./location.service";
import { LocationFormComponent } from "./form/location-form.component";

@Component({
  selector: "location",
  templateUrl: "./location.component.html",
})
export class LocationComponent extends ComponentManager<LocationModel>
  implements OnInit {
  constructor(
    public service: LocationService,
    public modalFormService: ModalFormService
  ) {
    super(service);
  }

  ngOnInit() {
    super.ngOnInit();
    this.modalContent = LocationFormComponent;
  }

  onAdd(args: any) {
    const { CountryId, StateId } = {
      ...this.service.cacheData.defaultData.List,
    } as any;

    this.service.model = <any>{
      CountryId: CountryId,
      StateId: StateId,
    };

    super.onAdd(args);
  }
}
