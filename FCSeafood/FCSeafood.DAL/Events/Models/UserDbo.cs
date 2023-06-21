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
    public int RoleTDboId { get; set; }
    public RoleTDbo? RoleTDbo { get; set; }

    [Column("FK_Gender_Type")]
    public int GenderTDboId { get; set; }
    public GenderTDbo? GenderTDbo { get; set; }

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
    public Guid? AddressDboId { get; set; }
    public AddressDbo? AddressDbo { get; set; }

    [Column("Created_Date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Column("Updated_Date")]
    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public UserDbo() { }

    public UserDbo(UserModel userModel) {
        Id = userModel.Id;
        FirstName = userModel.FirstName;
        LastName = userModel.LastName;
        RoleTDboId = (int)userModel.Role.Type;
        GenderTDboId = (int)userModel.Gender.Type;
        IsActive = userModel.IsActive;
        IsVerified = userModel.IsVerified;
        Phone = userModel.Phone;
        ImagePath = userModel.ImagePath;
        DateOfBirth = userModel.DateOfBirth;
        AddressDboId = userModel.Address?.Id;
        CreatedDate = userModel.CreatedDate;
        UpdatedDate = userModel.UpdatedDate;
    }
}