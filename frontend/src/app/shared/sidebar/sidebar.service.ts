import { Injectable } from "@angular/core";
import { HttpBaseService, TokenService, ConfigService } from "utilscore-ar";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { ToastrService } from "ngx-toastr";

@Injectable({
  providedIn: "root"
})
export class SidebarService extends HttpBaseService {
  menus = [];

  public constructor(
    configService: ConfigService,
    tokenService: TokenService,
    router: Router,
    http: HttpClient,
    toastr?: ToastrService
  ) {
    super(configService, tokenService, router, http, toastr);
    this.validateChangePassword();
  }

  getMenuByUserId(callback?: Function) {
    this.getMethod("api/Menu/GetMenuByUser", response => {
      this.menus = response.DataSource;

      if (callback) {
        callback(response);
      }
    });
  }
}
