namespace FCSeafood.DAL.Events.Models;

[Table("L_Rating", Schema = "lnk")]
public class RatingLDbo {
    [Column("PK_Rating")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("FK_User")]
    public Guid UserDboId { get; set; }

    [Column("FK_Item")]
    public Guid ItemDboId { get; set; }

    [Column("FK_Rating_Type")]
    public int RatingTDboId { get; set; }

    public RatingLDbo() { }

    public RatingLDbo(RatingLModel model) {
        Id = model.Id;
        UserDboId = model.UserDboId;
        ItemDboId = model.ItemDboId;
        RatingTDboId = (int)model.Rating;
    }
}