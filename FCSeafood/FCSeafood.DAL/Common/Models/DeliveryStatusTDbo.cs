namespace FCSeafood.DAL.Common.Models;

[Table("E_Delivery_Status_Type", Schema = "enum")]
public class DeliveryStatusTDbo {
    [Column("PK_Delivery_Status_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";
}