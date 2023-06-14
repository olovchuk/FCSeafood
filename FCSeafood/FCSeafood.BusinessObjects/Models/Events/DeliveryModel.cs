namespace FCSeafood.BusinessObjects.Models.Events;

public class DeliveryModel {
    public Guid Id { get; set; }
    public string TrackingNumber { get; set; } = "";
    public UserModel User { get; set; } = new();
    public UserModel Courier { get; set; } = new();
    public OrderModel Order { get; set; } = new();
    public DeliveryStatusTModel DeliveryStatus { get; set; } = new();
    public PaymentMethodTModel PaymentMethod { get; set; } = new();
    public double DeliveryFee { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}