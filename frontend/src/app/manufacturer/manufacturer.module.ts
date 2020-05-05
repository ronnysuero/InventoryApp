import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { ManufacturerListComponent } from "./list/manufacturer-list.component";
import { ManufacturerComponent } from "./manufacturer.component";
import { ManufacturerRouting } from "./manufacturer.routing";
import { SharedModule } from "../shared/shared.module";
import { ManufacturerFormModule } from "./form/manufacturer-form.module";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ManufacturerRouting,
    SharedModule,
    ManufacturerFormModule
  ],
  declarations: [ManufacturerComponent, ManufacturerListComponent]
})
export class ManufacturerModule {}
