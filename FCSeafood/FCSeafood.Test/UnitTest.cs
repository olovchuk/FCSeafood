using System.Text.Json;
using FCSeafood.BusinessObjects;
using FCSeafood.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace FCSeafood.Test;

public class Tests {
    private const string ConnectionString = "Data Source=localhost;Initial Catalog=Test;User ID=FCS_User;Password=s1c@r8;TrustServerCertificate=True";
    private EventFCSeafoodContext _eventFcSeafoodContext = null!;

    [SetUp]
    public void Setup() {
        var dbEventOptions = new DbContextOptionsBuilder<EventFCSeafoodContext>();
        dbEventOptions.UseSqlServer(ConnectionString);
        _eventFcSeafoodContext = new EventFCSeafoodContext(dbEventOptions.Options);
    }

    [Test]
    public void Test1() {
        Assert.That(_eventFcSeafoodContext, Is.Not.Null);
        Assert.That(_eventFcSeafoodContext.Items, Is.Not.Null);

        var itemDbos = _eventFcSeafoodContext.Items.Where(x => x.CategoryType == CategoryType.Fish && x.SubCategoryType == SubCategoryType.SeaFish);
        Assert.That(itemDbos, Is.Not.Null);
        var oprions = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(itemDbos, oprions);
        Console.WriteLine(json);
    }
}