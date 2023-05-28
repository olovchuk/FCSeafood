using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Common;
using FCSeafood.BLL.Item.Models.Params;
using FCSeafood.BusinessObjects;
using FCSeafood.DAL.Context;
using Microsoft.EntityFrameworkCore;

BenchmarkRunner.Run<ItemBenchmark>();

[MemoryDiagnoser]
[RankColumn]
public class ItemBenchmark {
    private const string ConnectionString = "Data Source=localhost;Initial Catalog=Test;User ID=FCS_User;Password=s1c@r8;TrustServerCertificate=True";

    public ItemBenchmark() {
        var dbEventOptions = new DbContextOptionsBuilder<EventFCSeafoodContext>();
        dbEventOptions.UseSqlServer(ConnectionString);
        var eventFcSeafoodContext = new EventFCSeafoodContext(dbEventOptions.Options);
    }

    [Benchmark]
    public void Benchmark() { }
}