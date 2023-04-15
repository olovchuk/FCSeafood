namespace FCSeafood.BusinessObjects.Models;

public class UserModel {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RoleType { get; set; }
    public string GenderType { get; set; }
    public bool IsActive { get; set; }
    public bool IsVerified { get; set; }
    public string Phone { get; set; }
    public string ImagePath { get; set; }
    public DateTime DateOfBirth { get; set; }
    public AddressModel Address { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}