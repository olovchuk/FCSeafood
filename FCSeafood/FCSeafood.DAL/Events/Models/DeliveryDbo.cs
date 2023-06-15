namespace FCSeafood.DAL.Events.Models;

[Table("T_Delivery", Schema = "dbo")]
public class DeliveryDbo {
    [Column("PK_Delivery")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("Tracking_Number")]
    public string TrackingNumber { get; set; } = "";

    [Column("FK_User")]
    public Guid UserDboId { get; set; }
    public UserDbo? UserDbo { get; set; }

    [Column("FK_Courier")]
    public Guid? CourierDboId { get; set; }
    public UserDbo? CourierDbo { get; set; }

    [Column("FK_Order")]
    public Guid OrderDboId { get; set; }
    public OrderDbo? OrderDbo { get; set; }

    [Column("FK_Delivery_Status_Type")]
    public int DeliveryStatusTDboId { get; set; }
    public DeliveryStatusTDbo? DeliveryStatusTDbo { get; set; }

    [Column("FK_Payment_Method_Type")]
    public int PaymentMethodTDboId { get; set; }
    public PaymentMethodTDbo? PaymentMethodTDbo { get; set; }

    [Column("Notes")]
    public string? Notes { get; set; }

    [Column("Created_Date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DeliveryDbo() { }

    public DeliveryDbo(DeliveryModel model) {
        Id = model.Id;
        TrackingNumber = model.TrackingNumber;
        UserDboId = model.User.Id;
        CourierDboId = model.Courier?.Id;
        OrderDboId = model.Order.Id;
        DeliveryStatusTDboId = (int)model.DeliveryStatus.Type;
        PaymentMethodTDboId = (int)model.PaymentMethod.Type;
        Notes = model.Notes;
        CreatedDate = model.CreatedDate;
    }
}