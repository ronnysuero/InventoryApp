import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { TransferButtonComponent } from "./button/transfer-button.component";
import { TransferComponent } from "./transfer.component";
import { SharedModule } from "../shared/shared.module";
import { TransferFormModule } from "./form/transfer-form.module";

@NgModule({
  imports: [CommonModule, FormsModule, SharedModule, TransferFormModule],
  declarations: [TransferComponent, TransferButtonComponent],
  exports: [TransferComponent, TransferButtonComponent],
})
export class TransferModule {}
