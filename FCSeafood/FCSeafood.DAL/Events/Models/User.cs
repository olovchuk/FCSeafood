using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCSeafood.DAL.Events.Models;

[Table("T_User")]
public class User {
    [Column("PK_User")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("First_Name")]
    public string FirstName { get; set; }

    [Column("Last_Name")]
    public string LastName { get; set; }

    [Column("Phone")]
    public string? Phone { get; set; }

    [Column("FK_Gender_Type")]
    public GenderType? GenderType { get; set; }

    [Column("Date_Of_Birth")]
    public DateTime? DateOfBirth { get; set; }

    [Column("Image_Path")]
    public string? ImagePath { get; set; }

    [Column("IsActive")]
    public bool IsActive { get; set; }

    [Column("IsVerified")]
    public bool IsVerified { get; set; }

    [Column("FK_Role_Type")]
    public RoleType RoleType { get; set; }

    [Column("FK_Address")]
    public Guid? AddressId { get; set; }

    [Column("Created_At")]
    public DateTime CreatedAt { get; set; }

    [Column("Updated_At")]
    public DateTime UpdatedAt { get; set; }
}