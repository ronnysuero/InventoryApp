import {
  LoginManager,
  AuthService,
  ConfigService,
  TokenService,
  IAuthUser
} from "utilscore-ar";
import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

@Component({
  templateUrl: "./login.component.html"
})
export class LoginComponent extends LoginManager<IAuthUser> {
  constructor(
    service: AuthService<IAuthUser>,
    tokenService: TokenService,
    route: ActivatedRoute,
    router: Router,
    toastr: ToastrService,
    public configService: ConfigService
  ) {
    super(service, router, route, tokenService, toastr);
  }
}
