import { PaymentMethodType } from "@common-enums/payment-method.type";

export class InsertDeliveryRequest {
  userModel: string = ''; // Guid
  orderModel: string = ''; // Guid
  paymentMethodType: PaymentMethodType = PaymentMethodType.Unknown;
  notes: string | null = null;
}
