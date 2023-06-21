namespace FCSeafood.DAL.Common.Models;

[Table("E_Item_Status_Type", Schema = "enum")]
public class ItemStatusTDbo {
    [Column("PK_Item_Status_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";
}