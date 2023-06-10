namespace FCSeafood.DAL.Events.Models;

[Table("T_Order", Schema = "dbo")]
public class OrderDbo {
    [Column("PK_Order")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("FK_User")]
    public Guid UserDboId { get; set; }

    public UserDbo? UserDbo { get; set; }

    [Column("Total_Price")]
    public double TotalPrice { get; set; }

    [Column("Created_Date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public List<OrderEntityDbo> Orders { get; set; } = new();

    public OrderDbo() { }

    public OrderDbo(OrderModel model) {
        Id = model.Id;
        UserDboId = model.User.Id;
        CreatedDate = model.CreatedDate;
        TotalPrice = model.TotalPrice;
    }
}