namespace FCSeafood.DAL.Common.Models;

[Table("E_Temperature_Unit", Schema = "enum")]
public class TemperatureUnitTDbo {
    [Column("PK_Temperature_Unit")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";

    [Column("Sign")]
    public string Sign { get; set; } = "";
}