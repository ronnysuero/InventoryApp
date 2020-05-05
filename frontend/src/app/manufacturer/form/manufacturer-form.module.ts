import { NgModule, ANALYZE_FOR_ENTRY_COMPONENTS } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../../shared/shared.module";
import { ManufacturerFormComponent } from "./manufacturer-form.component";
import { ManufacturerService } from "../manufacturer.service";
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
  declarations: [ManufacturerFormComponent],
  exports: [ManufacturerFormComponent],
  providers: [ManufacturerService]
})
export class ManufacturerFormModule {}
