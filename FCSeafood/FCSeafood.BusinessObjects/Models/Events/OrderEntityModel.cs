namespace FCSeafood.BusinessObjects.Models.Events;

public class OrderEntityModel {
    public Guid Id { get; set; }
    public ItemModel Item { get; set; }
    public double QuantityPerKg { get; set; }
    public double TotalPrice { get; set; }
}