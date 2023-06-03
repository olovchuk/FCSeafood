import { CurrencyCodeType } from "@common-enums/currency-code.type";

export class CurrencyCodeTModel {
  type: CurrencyCodeType = CurrencyCodeType.Unknown;
  name: string = '';
}
