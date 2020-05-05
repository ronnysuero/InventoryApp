import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { AreaListComponent } from "./list/area-list.component";
import { AreaComponent } from "./area.component";
import { AreaRouting } from "./area.routing";
import { SharedModule } from "../shared/shared.module";
import { AreaFormModule } from "./form/area-form.module";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    AreaRouting,
    SharedModule,
    AreaFormModule
  ],
  declarations: [AreaComponent, AreaListComponent]
})
export class AreaModule {}
