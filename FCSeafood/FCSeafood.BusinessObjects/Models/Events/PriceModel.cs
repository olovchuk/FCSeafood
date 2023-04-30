namespace FCSeafood.BusinessObjects.Models.Events;

public class PriceModel {
    public Guid Id { get; set; }
    public double Price { get; set; }
    public CurrencyCodeTModel CurrencyCode { get; set; } = new();
}