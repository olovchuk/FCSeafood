import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { UiHelper } from "@common-helpers/ui.helper";
import { UserInformation } from "@modules-pages/account/account-content/personal-information/personal-information.component";
import { CommonService } from "@common-services/common.service";
import { GenderTModel } from "@common-models/gender-type.model";

@Component({
  selector: 'personal-information-block',
  templateUrl: './information.block.html',
  styleUrls: ['../personal-information.component.scss']
})
export class InformationBlock implements OnInit {
  protected readonly UiHelper = UiHelper;

  @Input("userInformation") userInformation!: UserInformation;
  @Output('saveChanges') saveChanges: EventEmitter<UserInformation> = new EventEmitter<UserInformation>();

  gendersTList: GenderTModel[] = [];

  isShowErrors: boolean = false;
  informationFormGroup: FormGroup = new FormGroup({
    isEdit: new FormControl(false),
    firstName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    genderType: new FormControl('', [Validators.required]),
    phone: new FormControl(''),
    dateOfBirth: new FormControl(new Date())
  });

  constructor(private commonService: CommonService) {
  }

  async ngOnInit(): Promise<void> {
    this.gendersTList = await this.commonService.getGenderTList();
    this.informationFormGroup.controls['firstName'].setValue(this.userInformation.firstName);
    this.informationFormGroup.controls['lastName'].setValue(this.userInformation.lastName);
    this.informationFormGroup.controls['genderType'].setValue(this.userInformation.genderType);
    this.informationFormGroup.controls['phone'].setValue(this.userInformation.phone);
    this.informationFormGroup.controls['dateOfBirth'].setValue(new Date(this.userInformation.dateOfBirth));
  }

  async confirm(): Promise<void> {
    if (this.informationFormGroup.status !== 'VALID') {
      this.isShowErrors = true;
      return;
    }

    if (!this.isInformationChanged()) {
      this.informationFormGroup.controls['isEdit'].setValue(false);
      this.isShowErrors = false;
      return;
    }

    this.userInformation.firstName = this.informationFormGroup.get('firstName')?.value;
    this.userInformation.lastName = this.informationFormGroup.get('lastName')?.value;
    this.userInformation.genderType = this.informationFormGroup.get('genderType')?.value;
    this.userInformation.phone = this.informationFormGroup.get('phone')?.value;
    this.userInformation.dateOfBirth = this.informationFormGroup.get('dateOfBirth')?.value;
    this.userInformation.dateOfBirth.setHours(12);

    this.informationFormGroup.controls['isEdit'].setValue(false);
    this.isShowErrors = false;
    this.saveChanges.emit();
  }

  isInformationChanged(): boolean {
    return this.informationFormGroup.get('firstName')?.value !== this.userInformation.firstName ||
      this.informationFormGroup.get('lastName')?.value !== this.userInformation.lastName ||
      this.informationFormGroup.get('genderType')?.value !== this.userInformation.genderType ||
      this.informationFormGroup.get('phone')?.value !== this.userInformation.phone ||
      this.informationFormGroup.get('dateOfBirth')?.value !== this.userInformation.dateOfBirth;
  }
}
