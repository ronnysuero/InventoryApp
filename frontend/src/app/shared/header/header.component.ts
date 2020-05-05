import { AuthService, IAuthUser, TokenService, ClaimTypes } from "utilscore-ar";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "inventory-header",
  templateUrl: "./header.component.html",
})
export class HeaderComponent implements OnInit {
  username: string;

  constructor(
    public service: AuthService<IAuthUser>,
    public tokenService: TokenService
  ) {}

  ngOnInit() {
    this.username = this.tokenService.getValueFromClaim(ClaimTypes.Name);
  }
}
