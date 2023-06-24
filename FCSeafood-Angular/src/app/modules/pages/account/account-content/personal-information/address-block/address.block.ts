import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AddressModel } from "@common-models/address.model";

@Component({
  selector: 'personal-address-block',
  templateUrl: './address.block.html',
  styleUrls: ['../personal-information.component.scss']
})
export class AddressBlock implements OnInit {
  @Input("address") address!: AddressModel;
  @Output('saveChanges') saveChanges: EventEmitter<AddressModel> = new EventEmitter<AddressModel>();

  isShowErrors: boolean = false;
  addressFormGroup: FormGroup = new FormGroup({
    isEdit: new FormControl(false),
    country: new FormControl('', [Validators.required, Validators.minLength(2)]),
    city: new FormControl('', [Validators.required, Validators.minLength(2)]),
    street: new FormControl('', [Validators.required, Validators.minLength(2)]),
    apartmentNumber: new FormControl('', [Validators.required]),
    floor: new FormControl(''),
    entrance: new FormControl(''),
    intercom: new FormControl(''),
    zipCode: new FormControl('', [Validators.required]),
  });

  ngOnInit() {
    this.addressFormGroup.controls['country'].setValue(this.address?.country);
    this.addressFormGroup.controls['city'].setValue(this.address?.city);
    this.addressFormGroup.controls['street'].setValue(this.address?.street);
    this.addressFormGroup.controls['apartmentNumber'].setValue(this.address?.apartmentNumber);
    this.addressFormGroup.controls['entrance'].setValue(this.address?.entrance);
    this.addressFormGroup.controls['floor'].setValue(this.address?.floor);
    this.addressFormGroup.controls['intercom'].setValue(this.address?.intercom);
    this.addressFormGroup.controls['zipCode'].setValue(this.address?.zipCode);
  }

  async confirm(): Promise<void> {
    if (this.addressFormGroup.status !== 'VALID') {
      this.isShowErrors = true;
      return;
    }

    if (!this.isAddressChanged()) {
      this.addressFormGroup.controls['isEdit'].setValue(false);
      this.isShowErrors = false;
      return;
    }

    this.address.country = this.addressFormGroup.get('country')?.value;
    this.address.city = this.addressFormGroup.get('city')?.value;
    this.address.street = this.addressFormGroup.get('street')?.value;
    this.address.apartmentNumber = this.addressFormGroup.get('apartmentNumber')?.value;
    this.address.entrance = this.addressFormGroup.get('entrance')?.value;
    this.address.floor = this.addressFormGroup.get('floor')?.value;
    this.address.intercom = this.addressFormGroup.get('intercom')?.value;
    this.address.zipCode = this.addressFormGroup.get('zipCode')?.value;

    this.addressFormGroup.controls['isEdit'].setValue(false);
    this.isShowErrors = false;
    this.saveChanges.emit();
  }

  isAddressChanged(): boolean {
    return this.addressFormGroup.get('country')?.value !== this.address.country ||
      this.addressFormGroup.get('city')?.value !== this.address.city ||
      this.addressFormGroup.get('street')?.value !== this.address.street ||
      this.addressFormGroup.get('apartmentNumber')?.value !== this.address.apartmentNumber ||
      this.addressFormGroup.get('entrance')?.value !== this.address.entrance ||
      this.addressFormGroup.get('floor')?.value !== this.address.floor ||
      this.addressFormGroup.get('intercom')?.value !== this.address.intercom ||
      this.addressFormGroup.get('zipCode')?.value !== this.address.zipCode;
  }
}
