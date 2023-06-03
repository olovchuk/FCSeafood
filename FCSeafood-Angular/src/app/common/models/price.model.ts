import { CurrencyCodeTModel } from "@common-models/currency-code-type.model";

export class PriceModel {
  id: string = ''; // guid
  price: number = 0.0;
  currencyCodeTModel: CurrencyCodeTModel = new CurrencyCodeTModel();
}
