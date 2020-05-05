import { NgModule, ANALYZE_FOR_ENTRY_COMPONENTS } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../../shared/shared.module";
import { LocationFormComponent } from "./location-form.component";
import { LocationService } from "../location.service";
import { FormTemplateModule } from "utilscore-ar";
import { ModalFormModule } from "prime-ngx-ar";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    FormTemplateModule,
    ModalFormModule
  ],
  declarations: [LocationFormComponent],
  exports: [LocationFormComponent],
  providers: [LocationService]
})
export class LocationFormModule {}
