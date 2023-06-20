import { PaymentMethodType } from "@common-enums/payment-method.type";

export class InsertDeliveryRequest {
  userId: string = ''; // Guid
  orderId: string = ''; // Guid
  paymentMethodType: PaymentMethodType = PaymentMethodType.Unknown;
  notes: string | null = null;
}
