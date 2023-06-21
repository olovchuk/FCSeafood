namespace FCSeafood.BusinessObjects.Models.Events;

public class UserCredentialModel {
    public Guid Id { get; set; }
    public string Email { get; set; } = "";

    public string Password { get; set; } = "";

    public DateTime? LastLoginDate { get; set; }

    public DateTime? LastPasswordChangedDate { get; set; }
}