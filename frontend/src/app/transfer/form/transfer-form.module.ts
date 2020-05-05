import { NgModule, ANALYZE_FOR_ENTRY_COMPONENTS } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../../shared/shared.module";
import { TransferFormComponent } from "./transfer-form.component";
import { TransferService } from "../transfer.service";
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
  declarations: [TransferFormComponent],
  exports: [TransferFormComponent],
  providers: [TransferService]
})
export class TransferFormModule {}
