import { Component, OnInit } from '@angular/core';
import { OrderStateService } from "@common-services/order-state/order-state.service";
import { UiHelper } from "@common-helpers/ui.helper";
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from "@angular/forms";
import { RouteHelper } from "@common-helpers/route.helper";
import { CommonService } from "@common-services/common.service";
import { PaymentMethodType } from "@common-enums/payment-method.type";
import { PaymentMethodTModel } from "@common-models/payment-method-type.model";
import { AddressModel } from "@common-models/address.model";
import { UserService } from "@common-services/user.service";
import { UserModel } from "@common-models/user.model";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { InsertDeliveryRequest } from "@common-data/delivery/http/request/insert-delivery.request";
import { RoleType } from "@common-enums/role.type";
import { MatDialog } from "@angular/material/dialog";
import { InputTextAreaPopup } from "@modules-components/popups/input-text-area/input-text-area.popup";
import { DeliveryService } from "@common-services/delivery.service";

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {
  protected readonly UiHelper = UiHelper;
  protected readonly PaymentMethodType = PaymentMethodType;

  user!: UserModel;
  paymentMethodTList: PaymentMethodTModel[] = [];
  isShowErrors: boolean = false;
  note!: string;

  orderFormGroup: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.min(2)]),
    surname: new FormControl('', [Validators.required, Validators.min(2)]),
    phone: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    country: new FormControl('', [Validators.required, Validators.min(2)]),
    city: new FormControl('', [Validators.required, Validators.min(2)]),
    street: new FormControl('', [Validators.required, Validators.min(2)]),
    apartmentNumber: new FormControl('', [Validators.required]),
    floor: new FormControl(''),
    entrance: new FormControl(''),
    intercom: new FormControl(''),
    zipCode: new FormControl('', [Validators.required]),
    paymentMethodType: new FormControl(''),
    numberCard: new FormControl(''),
    monthYear: new FormControl(''),
    cvv: new FormControl('')
  }, {validators: this.cardInformationValidator});

  constructor(public routeHelper: RouteHelper,
              public orderStateService: OrderStateService,
              private authStateService: AuthStateService,
              private commonService: CommonService,
              private userService: UserService,
              private deliveryService: DeliveryService,
              private dialog: MatDialog) {
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
    this.paymentMethodTList = await this.commonService.getPaymentMethodTList();
    this.initData();
  }

  initData() {
    if (this.user.role.type !== RoleType.Guest) {
      this.orderFormGroup.controls['name'].setValue(this.user.firstName);
      this.orderFormGroup.controls['surname'].setValue(this.user.lastName);
      this.orderFormGroup.controls['phone'].setValue(this.user.phone);
      this.orderFormGroup.controls['email'].setValue(this.user.email);
    }

    this.orderFormGroup.controls['country'].setValue(this.user.address?.country);
    this.orderFormGroup.controls['city'].setValue(this.user.address?.city);
    this.orderFormGroup.controls['street'].setValue(this.user.address?.street);
    this.orderFormGroup.controls['apartmentNumber'].setValue(this.user.address?.apartmentNumber);
    this.orderFormGroup.controls['entrance'].setValue(this.user.address?.entrance);
    this.orderFormGroup.controls['floor'].setValue(this.user.address?.floor);
    this.orderFormGroup.controls['intercom'].setValue(this.user.address?.intercom);
    this.orderFormGroup.controls['zipCode'].setValue(this.user.address?.zipCode);
  }

  addNote() {
    const inputTextAreaPopup = this.dialog.open(InputTextAreaPopup, {
      panelClass: ['animate__animated', 'animate__slideInUp', 'border-primary']
    });
    inputTextAreaPopup.componentInstance.title = 'Note:';
    inputTextAreaPopup.componentInstance.maxLength = 500;

    inputTextAreaPopup.afterClosed().subscribe(result => {
      if (!result || result.trim() === '')
        return;

      this.note = result;
    })
  }

  isAddressChanged(): boolean {
    return !(this.orderFormGroup.get('country')?.value !== this.user.address?.country ||
      this.orderFormGroup.get('city')?.value !== this.user.address?.city ||
      this.orderFormGroup.get('street')?.value !== this.user.address?.street ||
      this.orderFormGroup.get('apartmentNumber')?.value !== this.user.address?.apartmentNumber ||
      this.orderFormGroup.get('entrance')?.value !== this.user.address?.entrance ||
      this.orderFormGroup.get('floor')?.value !== this.user.address?.floor ||
      this.orderFormGroup.get('intercom')?.value !== this.user.address?.intercom ||
      this.orderFormGroup.get('zipCode')?.value !== this.user.address?.zipCode);
  }

  async confirm(): Promise<void> {
    if (this.orderFormGroup.status !== 'VALID') {
      this.isShowErrors = true;
      return;
    }

    if (this.isAddressChanged()) {
      let address: AddressModel = {
        id: this.UiHelper.GUID_EMPTY,
        country: this.orderFormGroup.get('country')?.value,
        city: this.orderFormGroup.get('city')?.value,
        street: this.orderFormGroup.get('street')?.value,
        apartmentNumber: this.orderFormGroup.get('apartmentNumber')?.value,
        entrance: this.orderFormGroup.get('entrance')?.value,
        floor: this.orderFormGroup.get('floor')?.value,
        intercom: this.orderFormGroup.get('intercom')?.value,
        zipCode: this.orderFormGroup.get('zipCode')?.value
      };
      this.userService.updateUserAddress({userId: this.authStateService.token.UserId, addressModel: address});
    }

    let insertDeliveryRequest: InsertDeliveryRequest = {
      userModel: this.user.id,
      orderModel: this.orderStateService.state.order.id,
      paymentMethodType: this.orderFormGroup.get('paymentMethodType')?.value,
      notes: this.note
    };
    const trackingNumber = await this.deliveryService.insertDelivery(insertDeliveryRequest);
    if (!trackingNumber)
      return;

    //TODO: Redirect to thank u for order (with show trackingNumber)
  }

  cardInformationValidator(control: AbstractControl): ValidationErrors | null {
    const paymentMethodType = control.get('paymentMethodType')?.value;
    const numberCard = control.get('numberCard')?.value;
    const monthYear = control.get('monthYear')?.value;
    const cvv = control.get('cvv')?.value;

    if (paymentMethodType === PaymentMethodType.Card) {
      let cardPattern = /^\d{4}-\d{4}-\d{4}-\d{4}$/;
      let monthYearPattern = /^(0[1-9]|1[0-2])\/([0-9]{2})$/;
      let cvvPattern = /^\d{3}$/; // Припустимий формат: 999
      let isValidCard = cardPattern.test(numberCard);
      let isValidMonthYear = monthYearPattern.test(monthYear);
      let isValidCvv = cvvPattern.test(cvv);

      if (!isValidCard) {
        control.get("numberCard")?.setErrors({invalid: true});
      }
      if (!isValidMonthYear) {
        control.get("monthYear")?.setErrors({invalid: true});
      }
      if (!isValidCvv) {
        control.get("cvv")?.setErrors({invalid: true});
      }

      if (!isValidCard || !isValidMonthYear || !isValidCvv) {
        return {invalid: true};
      }
    }

    control.get("numberCard")?.setErrors(null);
    control.get("monthYear")?.setErrors(null);
    control.get("cvv")?.setErrors(null);
    return null;
  };
}
