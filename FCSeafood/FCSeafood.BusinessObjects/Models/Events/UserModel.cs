namespace FCSeafood.BusinessObjects.Models.Events;

public class UserModel {
    public Guid Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public RoleTModel Role { get; set; } = new();
    public GenderTModel Gender { get; set; } = new();
    public bool IsActive { get; set; } = true;
    public bool IsVerified { get; set; }
    public string? Phone { get; set; }
    public string? ImagePath { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public AddressModel? Address { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public string GetFullName => $"{FirstName} {LastName}";
}