namespace FCSeafood.BusinessObjects.Models.Events;

public class ResetPasswordLModel {
    public int Id { get; set; }
    public Guid UserDboId { get; set; }
    public int Code { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ExpirationDate { get; set; } = DateTime.Now;
}