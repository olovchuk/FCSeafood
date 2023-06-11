export class UiHelper {
  static GUID_EMPTY = '00000000-0000-0000-0000-000000000000';
  static FormatCurrency(number: number): string {
    return number.toLocaleString('en-US', {style: 'currency', currency: 'USD'})
  }
}
