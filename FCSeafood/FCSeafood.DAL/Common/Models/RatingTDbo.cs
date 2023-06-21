namespace FCSeafood.DAL.Common.Models;

[Table("E_Rating_Type", Schema = "enum")]
public class RatingTDbo {
    [Column("PK_Rating_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";
}