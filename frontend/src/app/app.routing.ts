import { LoginComponent } from "./login/login.component";
import { NgModule, APP_INITIALIZER } from "@angular/core";
import { NotFoundComponent } from "./shared/not-found/not-found.component";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { LaddaModule } from "angular2-ladda";
import { Routes, RouterModule } from "@angular/router";
import {
  AuthGuard,
  AuthModule,
  ConfigService,
  ValidatorModule,
} from "utilscore-ar";
import { environment } from "../environments/environment";
import { HttpClientModule } from "@angular/common/http";
import { I18nEsService } from "ng-bootstrap-ar";
import { ToastrModule } from "ngx-toastr";
import { MainComponent } from "./shared/main/main.component";

export const routes: Routes = [
  { path: "login", component: LoginComponent },
  {
    path: "",
    redirectTo: "items",
    pathMatch: "full",
    canActivate: [AuthGuard],
  },
  {
    path: "",
    component: MainComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: "areas",
        loadChildren: () =>
          import("./area/area.module").then((m) => m.AreaModule),
        data: { title: "Areas" },
      },
      {
        path: "manufacturers",
        loadChildren: () =>
          import("./manufacturer/manufacturer.module").then(
            (m) => m.ManufacturerModule
          ),
        data: { title: "Manufacturers" },
      },
      {
        path: "locations",
        loadChildren: () =>
          import("./location/location.module").then((m) => m.LocationModule),
        data: { title: "Locations" },
      },
      {
        path: "items",
        loadChildren: () =>
          import("./item/item.module").then((m) => m.ItemModule),
        data: { title: "Items" },
      },
      {
        path: "reports",
        loadChildren: () =>
          import("./report/report.module").then((m) => m.ReportModule),
        data: { title: "Reports" },
      },
    ],
  },
  { path: "**", redirectTo: "/404" },
  { path: "404", component: NotFoundComponent },
];

export function ConfigLoader(configService: ConfigService): () => Promise<any> {
  return () => configService.load(environment.configFile);
}

@NgModule({
  imports: [
    CommonModule,
    ValidatorModule,
    FormsModule,
    LaddaModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    AuthModule.forRoot(),
    ToastrModule.forRoot(),
  ],
  exports: [
    RouterModule,
    ValidatorModule,
    FormsModule,
    LaddaModule,
    AuthModule,
  ],
  declarations: [LoginComponent],
  providers: [
    ConfigService,
    I18nEsService,
    {
      provide: APP_INITIALIZER,
      useFactory: ConfigLoader,
      deps: [ConfigService],
      multi: true,
    },
  ],
})
export class AppRoutingModule {}
