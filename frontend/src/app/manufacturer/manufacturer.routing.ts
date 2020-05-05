import { Routes, RouterModule } from "@angular/router";
import { ManufacturerComponent } from "./manufacturer.component";
import { ManufacturerListComponent } from "./list/manufacturer-list.component";
import { ManufacturerFormComponent } from "./form/manufacturer-form.component";

const APP_ROUTES: Routes = [
  {
    path: "",
    component: ManufacturerComponent,
    data: { title: "" },
    children: [
      { path: "", component: ManufacturerListComponent },
      {
        path: "edit",
        component: ManufacturerFormComponent,
        data: { title: "Editar" },
      },
      {
        path: "add",
        component: ManufacturerFormComponent,
        data: { title: "Agregar nuevo" },
      },
    ],
  },
];

export const ManufacturerRouting = RouterModule.forChild(APP_ROUTES);
