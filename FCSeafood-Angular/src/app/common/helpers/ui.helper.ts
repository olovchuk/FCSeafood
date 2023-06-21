export class UiHelper {
  static GUID_EMPTY = '00000000-0000-0000-0000-000000000000';

  static FormatCurrency(number: number): string {
    return number.toLocaleString('en-US', {style: 'currency', currency: 'USD'})
  }

  static FormatData(date: Date): string {
    const options: Intl.DateTimeFormatOptions = {
      month: 'long',
      day: 'numeric',
      year: 'numeric'
    };
    return new Date(date).toLocaleDateString('en-US', options);
  }
}
