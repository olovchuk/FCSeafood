import { Component, OnInit } from '@angular/core';
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { RouteHelper } from "@common-helpers/route.helper";
import { UserService } from "@common-services/user.service";
import { UserModel } from "@common-models/user.model";
import { CommonService } from "@common-services/common.service";
import { MessageHelper } from "@common-helpers/message.helper";
import { UiHelper } from "@common-helpers/ui.helper";
import { GenderType } from "@common-enums/gender.type";
import { AddressModel } from "@common-models/address.model";

@Component({
  selector: 'account-personal-information',
  templateUrl: './personal-information.component.html',
  styleUrls: ['./personal-information.component.scss']
})
export class PersonalInformationComponent implements OnInit {
  protected readonly UiHelper = UiHelper;

  user: UserModel = new UserModel();

  userInformation!: UserInformation;
  address!: AddressModel;

  constructor(private routeHelper: RouteHelper,
              private authStateService: AuthStateService,
              private userService: UserService,
              private commonService: CommonService,
              private messageHelper: MessageHelper) {
  }

  async ngOnInit(): Promise<void> {
    if (!this.authStateService.token.UserId) {
      await this.routeHelper.goToError();
      return;
    }

    let userModel = await this.userService.getUser({userId: this.authStateService.token.UserId});
    if (!userModel) {
      await this.routeHelper.goToError();
      return;
    }

    this.user = userModel;
    this.userInformation = {
      firstName: this.user.firstName,
      lastName: this.user.lastName,
      genderType: this.user.gender.type,
      phone: this.user.phone,
      dateOfBirth: this.user.dateOfBirth ?? new Date()
    };

    if (this.user.address)
      this.address = this.user.address;
  }

  async saveUserInformation(): Promise<void> {
    await this.userService.updateUserInformation({
      userId: this.user.id,
      firstName: this.userInformation.firstName,
      lastName: this.userInformation.lastName,
      genderType: this.userInformation.genderType,
      phone: this.userInformation.phone,
      dateOfBirth: this.userInformation.dateOfBirth,
    });
    this.messageHelper.success("The data was successfully saved.");
  }

  async saveUserAddress(): Promise<void> {
    await this.userService.updateUserAddress({
      userId: this.user.id,
      addressModel: this.address
    });
    this.messageHelper.success("The data was successfully saved.");
  }
}

export class UserInformation {
  firstName: string = '';
  lastName: string = '';
  genderType: GenderType = GenderType.Unknown;
  phone: string | null = null;
  dateOfBirth: Date = new Date();
}
