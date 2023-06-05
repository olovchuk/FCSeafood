namespace FCSeafood.DAL.Events.Models;

[Table("T_Order_Entity", Schema = "dbo")]
public class OrderEntityDbo {
    [Column("PK_Order_Entity")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("FK_Order")]
    public Guid OrderDboId { get; set; }

    [Column("FK_Item")]
    public Guid ItemDboId { get; set; }

    public ItemDbo? ItemDbo { get; set; }

    [Column("Quantity_Per_Kg")]
    public double QuantityPerKg { get; set; }

    [Column("Total_Price")]
    public double TotalPrice { get; set; }

    public OrderEntityDbo() { }

    public OrderEntityDbo(OrderEntityModel model) {
        Id = model.Id;
        ItemDboId = model.Item.Id;
        QuantityPerKg = model.QuantityPerKg;
        TotalPrice = model.TotalPrice;
    }
}