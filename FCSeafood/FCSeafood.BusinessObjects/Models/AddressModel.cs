namespace FCSeafood.BusinessObjects.Models;

public class AddressModel {
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int ApartmentNumber { get; set; }
    public int Entrance { get; set; }
    public int Floor { get; set; }
    public int Intercom { get; set; }
    public string ZipCode { get; set; }
}