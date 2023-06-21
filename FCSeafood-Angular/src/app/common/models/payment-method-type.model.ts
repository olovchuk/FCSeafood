import { PaymentMethodType } from "@common-enums/payment-method.type";

export class PaymentMethodTModel {
  type: PaymentMethodType = PaymentMethodType.Unknown;
  name: string = '';
}
