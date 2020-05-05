import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { LocationListComponent } from "./list/location-list.component";
import { LocationComponent } from "./location.component";
import { LocationRouting } from "./location.routing";
import { SharedModule } from "../shared/shared.module";
import { LocationFormModule } from "./form/location-form.module";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    LocationRouting,
    SharedModule,
    LocationFormModule
  ],
  declarations: [LocationComponent, LocationListComponent]
})
export class LocationModule {}
