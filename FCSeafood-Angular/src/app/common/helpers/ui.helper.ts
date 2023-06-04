export class UiHelper {
  static FormatCurrency(number: number): string {
    return number.toLocaleString('en-US', {style: 'currency', currency: 'USD'})
  }
}
