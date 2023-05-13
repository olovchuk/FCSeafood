namespace FCSeafood.BusinessObjects.Models.Events;

public class ItemModel {
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public string Code { get; set; } = "";

    public PriceModel Price { get; set; } = new();

    public CategoryTModel Category { get; set; } = new();

    public SubcategoryTModel Subcategory { get; set; } = new();

    public ItemStatusTModel ItemStatus { get; set; } = new();

    public double QuantityPerKg { get; set; }

    public string? Brand { get; set; }

    public string? Type { get; set; }

    public string? Finishing { get; set; }

    public bool IsPackaging { get; set; }

    public double? FatsPer100Gram { get; set; }

    public double? CarbohydratesPer100Gram { get; set; }

    public double? ProteinsPer100Gram { get; set; }

    public double? KcalPer100Gram { get; set; }

    public double? HumidityPerPercent { get; set; }

    public DateTime ExpirationDate { get; set; }

    public double TemperatureStorage { get; set; }

    public TemperatureUnitTModel TemperatureUnit { get; set; } = new();

    public string? Description { get; set; }
}