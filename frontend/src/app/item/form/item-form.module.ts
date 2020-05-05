import { NgModule, ANALYZE_FOR_ENTRY_COMPONENTS } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../../shared/shared.module";
import { ItemFormComponent } from "./item-form.component";
import { ItemService } from "../item.service";
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
  declarations: [ItemFormComponent],
  exports: [ItemFormComponent],
  providers: [ItemService]
})
export class ItemFormModule {}
