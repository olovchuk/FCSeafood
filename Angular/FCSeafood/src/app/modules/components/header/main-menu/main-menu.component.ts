import {Component, OnInit} from '@angular/core';
import {UserInformationState} from "@common-states/user-information.state";
import {CommonDataState} from "@common-states/common-data.state";
import {CommonDataStateService} from "@common-services/common-data-state/common-data-state.service";
import {MainSitemapState} from "@common-states/main-sitemap.state";

@Component({
  selector: 'header-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss']
})
export class MainMenuComponent implements OnInit {
  constructor(private userInformationState: UserInformationState,
              private commonDataState: CommonDataState,
              private commonDataStateService: CommonDataStateService,
              public mainSitemapState: MainSitemapState) {
  }

  async ngOnInit(): Promise<void> {
    await this.userInformationState.Init;
    await this.commonDataState.Init;
    this.commonDataStateService.initMainMenu();
  }
}
