import { PaymentMethodTModel } from "@common-models/payment-method-type.model";

export class PaymentMethodTListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  paymentMethodTListModel: PaymentMethodTModel[] = [];
}
