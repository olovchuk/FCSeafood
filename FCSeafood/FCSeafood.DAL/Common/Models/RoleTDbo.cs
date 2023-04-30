namespace FCSeafood.DAL.Common.Models;

[Table("E_Role_Type", Schema = "enum")]
public class RoleTDbo {
    [Column("PK_Role_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";
}