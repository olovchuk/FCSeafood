export enum PaymentType {
  Unknown = 0,
  Card = 1,
  PayPal = 2
}

export const PaymentTypeValues: { id: PaymentType, value: string }[] = [
  {id: PaymentType.Card, value: "Card (Vise/Mastercard)"},
  {id: PaymentType.PayPal, value: "PayPal"},
]
