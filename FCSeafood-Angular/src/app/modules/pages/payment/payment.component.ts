import { Component, OnInit } from '@angular/core';
import { OrderStateService } from "@common-services/order-state/order-state.service";
import { UiHelper } from "@common-helpers/ui.helper";
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from "@angular/forms";
import { PaymentType, PaymentTypeValues } from "@common-enums/payment-type";
import { RouteHelper } from "@common-helpers/route.helper";

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {
  protected readonly UiHelper = UiHelper;
  protected readonly PaymentType = PaymentType;

  paymentSystem: { id: PaymentType, value: string }[] = PaymentTypeValues;
  isShowErrors: boolean = false;

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
    selectedPaymentType: new FormControl(this.paymentSystem[0].id),
    numberCard: new FormControl(''),
    monthYear: new FormControl(''),
    cvv: new FormControl('')
  }, {validators: this.cardInformationValidator});

  constructor(public routeHelper: RouteHelper,
              public orderStateService: OrderStateService) {
  }

  ngOnInit(): void {

  }

  confirm() {
    if (this.orderFormGroup.status !== 'VALID') {
      this.isShowErrors = true;
      return;
    }
  }

  cardInformationValidator(control: AbstractControl): ValidationErrors | null {
    const selectedPaymentType = control.get('selectedPaymentType')?.value;
    const numberCard = control.get('numberCard')?.value;
    const monthYear = control.get('monthYear')?.value;
    const cvv = control.get('cvv')?.value;

    if (selectedPaymentType === PaymentType.Card) {
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
