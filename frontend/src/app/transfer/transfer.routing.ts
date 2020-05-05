import { Routes, RouterModule } from "@angular/router";
import { TransferComponent } from "./transfer.component";
import { TransferButtonComponent } from "./button/transfer-button.component";
import { TransferFormComponent } from "./form/transfer-form.component";

const APP_ROUTES: Routes = [
  {
    path: "",
    component: TransferComponent,
    data: { title: "" },
    children: [
      { path: "", component: TransferButtonComponent },
      {
        path: "edit",
        component: TransferFormComponent,
        data: { title: "Editar" },
      },
      {
        path: "add",
        component: TransferFormComponent,
        data: { title: "Agregar nuevo" },
      },
    ],
  },
];

export const TransferRouting = RouterModule.forChild(APP_ROUTES);
