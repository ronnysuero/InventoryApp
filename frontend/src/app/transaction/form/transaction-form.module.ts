import { NgModule, ANALYZE_FOR_ENTRY_COMPONENTS } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../../shared/shared.module";
import { TransactionFormComponent } from "./transaction-form.component";
import { TransactionService } from "../transaction.service";
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
  declarations: [TransactionFormComponent],
  exports: [TransactionFormComponent],
  providers: [TransactionService]
})
export class TransactionFormModule {}
