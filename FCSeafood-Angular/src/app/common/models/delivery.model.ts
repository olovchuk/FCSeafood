import { UserModel } from "@common-models/user.model";
import { OrderModel } from "@common-models/order.model";
import { DeliveryStatusTModel } from "@common-models/delivery-status-type.model";
import { PaymentMethodTModel } from "@common-models/payment-method-type.model";

export class DeliveryModel {
  id: string = ''; // guid
  trackingNumber: string = '';
  user: UserModel = new UserModel();
  courier: UserModel = new UserModel();
  order: OrderModel = new OrderModel();
  deliveryStatus: DeliveryStatusTModel = new DeliveryStatusTModel();
  paymentMethod: PaymentMethodTModel = new PaymentMethodTModel();
  deliveryFee: number = 0.0;
  notes: string | null = null;
  createdDate: Date = new Date();
}
