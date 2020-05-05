import { AsideToggleDirective } from "./directives/aside.directive";
import { BsDropdownModule, TabsModule } from "ngx-bootstrap";
import { CommonModule } from "@angular/common";
import { NAV_DROPDOWN_DIRECTIVES } from "./directives/nav-dropdown.directive";
import { NgModule } from "@angular/core";
import { NotFoundComponent } from "./not-found/not-found.component";
import { RouterModule } from "@angular/router";
import { SIDEBAR_TOGGLE_DIRECTIVES } from "./directives/sidebar.directive";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { HeaderComponent } from "./header/header.component";
import { FormsModule } from "@angular/forms";
import { NgxMaskModule } from "ngx-mask";
import { NgSelectModule } from "@ng-select/ng-select";
import {
  NgbDatepickerConfig,
  NgbDateParserFormatter,
  NgbDatepickerI18n,
  NgbDateAdapter,
  NgbDatepickerModule,
  NgbTimepickerConfig,
  NgbTimeAdapter
} from "@ng-bootstrap/ng-bootstrap";
import {
  BlockUIModule,
  ConfirmDialogModule,
  ConfirmationService,
  TableModule
} from "primeng";
import {
  ButtonGoToModule,
  SwitchModule,
  PipeModule,
  DirectiveModule,
  CrudModule,
  InputWrapperModule,
  SearchService,
  ValidatorModule,
  FormTemplateModule,
  CurrencyMaskConfig,
  CurrencyMaskModule,
  CURRENCY_MASK_CONFIG
} from "utilscore-ar";
import { LaddaModule } from "angular2-ladda";
import {
  ModalFormModule,
  MsgBoxModule,
  PaginationModule,
  ListTemplateModule
} from "prime-ngx-ar";
import {
  DateAdapter,
  DatepickerI18nService,
  DateParserFormatter,
  TimeAdapter
} from "ng-bootstrap-ar";
import { SidebarComponent } from "./sidebar/sidebar.component";
import { MainComponent } from "./main/main.component";

export const CustomCurrencyMaskConfig: CurrencyMaskConfig = {
  align: "left",
  allowNegative: true,
  decimal: ".",
  precision: 2,
  prefix: "",
  suffix: "",
  thousands: ","
};

@NgModule({
  imports: [
    RouterModule,
    CommonModule,
    BlockUIModule,
    FormsModule,
    PaginationModule,
    InputWrapperModule,
    ButtonGoToModule,
    ConfirmDialogModule,
    PipeModule,
    DirectiveModule,
    SwitchModule,
    CurrencyMaskModule,
    ValidatorModule,
    TableModule,
    NgSelectModule,
    LaddaModule,
    CrudModule,
    ModalFormModule,
    ListTemplateModule,
    FormTemplateModule,
    NgbDatepickerModule,
    NgxMaskModule.forRoot(),
    TabsModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalFormModule.forRoot()
  ],
  declarations: [
    MainComponent,
    SidebarComponent,
    NotFoundComponent,
    AsideToggleDirective,
    HeaderComponent,
    NAV_DROPDOWN_DIRECTIVES,
    SIDEBAR_TOGGLE_DIRECTIVES
  ],
  providers: [
    ConfirmationService,
    NgbDatepickerConfig,
    {
      provide: NgbDateAdapter,
      useClass: DateAdapter
    },
    {
      provide: NgbDatepickerI18n,
      useClass: DatepickerI18nService
    },
    {
      provide: NgbDateParserFormatter,
      useClass: DateParserFormatter
    },
    {
      provide: CURRENCY_MASK_CONFIG,
      useValue: CustomCurrencyMaskConfig
    },
    NgbTimepickerConfig,
    {
      provide: NgbTimeAdapter,
      useClass: TimeAdapter
    },
    SearchService
  ],
  exports: [
    PaginationModule,
    InputWrapperModule,
    PipeModule,
    DirectiveModule,
    SwitchModule,
    CurrencyMaskModule,
    ValidatorModule,
    NgbDatepickerModule,
    ListTemplateModule,
    FormTemplateModule,
    TableModule,
    NgxMaskModule,
    NgSelectModule,
    TabsModule,
    TooltipModule,
    LaddaModule,
    MsgBoxModule,
    CrudModule
  ]
})
export class SharedModule {}
