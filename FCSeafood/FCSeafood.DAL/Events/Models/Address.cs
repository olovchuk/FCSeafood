namespace FCSeafood.DAL.Events.Models;

[Table("T_Address", Schema = "dbo")]
public class Address {
    [Column("PK_Address")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("Country")]
    public string Country { get; set; } = "";

    [Column("City")]
    public string City { get; set; } = "";

    [Column("Street")]
    public string Street { get; set; } = "";

    [Column("Apartment_Number")]
    public int ApartmentNumber { get; set; }

    [Column("Entrance")]
    public int? Entrance { get; set; }

    [Column("Floor")]
    public int? Floor { get; set; }

    [Column("Intercom")]
    public int? Intercom { get; set; }

    [Column("Zip_Code")]
    public string? ZipCode { get; set; }
}