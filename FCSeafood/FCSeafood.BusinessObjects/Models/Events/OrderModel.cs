namespace FCSeafood.BusinessObjects.Models.Events;

public class OrderModel {
    public Guid Id { get; set; }

    public UserModel User { get; set; } = new();
    public double TotalPrice { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public List<OrderEntityModel> Orders { get; set; } = new();
}