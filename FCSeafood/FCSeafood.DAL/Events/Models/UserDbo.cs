namespace FCSeafood.DAL.Events.Models;

[Table("T_User", Schema = "dbo")]
public class UserDbo {
    [Column("PK_User")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("First_Name")]
    public string FirstName { get; set; } = "";

    [Column("Last_Name")]
    public string LastName { get; set; } = "";

    [Column("FK_Role_Type")]
    public RoleType RoleType { get; set; } = RoleType.User;

    [Column("FK_Gender_Type")]
    public GenderType GenderType { get; set; }

    [Column("IsActive")]
    public bool IsActive { get; set; } = true;

    [Column("IsVerified")]
    public bool IsVerified { get; set; }

    [Column("Phone")]
    public string? Phone { get; set; }

    [Column("Image_Path")]
    public string? ImagePath { get; set; }

    [Column("Date_Of_Birth")]
    public DateTime? DateOfBirth { get; set; }

    [Column("FK_Address")]
    public Guid? AddressId { get; set; }

    [Column("Created_Date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Column("Updated_Date")]
    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public UserDbo() { }

    public UserDbo(UserModel userModel) {
        Id = userModel.Id;
        FirstName = userModel.FirstName;
        LastName = userModel.LastName;
        RoleType = userModel.Role.Type;
        GenderType = userModel.Gender.Type;
        IsActive = userModel.IsActive;
        IsVerified = userModel.IsVerified;
        Phone = userModel.Phone;
        ImagePath = userModel.ImagePath;
        DateOfBirth = userModel.DateOfBirth;
        AddressId = userModel.Address?.Id;
        CreatedDate = userModel.CreatedDate;
        UpdatedDate = userModel.UpdatedDate;
    }
}