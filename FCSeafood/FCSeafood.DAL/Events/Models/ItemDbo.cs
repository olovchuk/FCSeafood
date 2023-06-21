namespace FCSeafood.DAL.Events.Models;

[Table("T_Item", Schema = "dbo")]
public class ItemDbo {
    [Column("PK_Item")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";

    [Column("Code")]
    public string Code { get; set; } = "";

    [Column("Image_Path")]
    public string ImagePath { get; set; } = "";

    [Column("Price")]
    public double Price { get; set; }

    [Column("FK_Category_Type")]
    public int CategoryTDboId { get; set; }
    public CategoryTDbo? CategoryTDbo { get; set; }

    [Column("FK_Subcategory_Type")]
    public int SubcategoryTDboId { get; set; }
    public SubcategoryTDbo? SubcategoryTDbo { get; set; }

    [Column("FK_Item_Status_Type")]
    public int ItemStatusTDboId { get; set; }
    public ItemStatusTDbo? ItemStatusTDbo { get; set; }

    [Column("Quantity_Per_Kg")]
    public double QuantityPerKg { get; set; }

    [Column("Like_Count")]
    public int LikeCount { get; set; }

    [Column("Dislike_Count")]
    public int DislikeCount { get; set; }

    [Column("Brand")]
    public string? Brand { get; set; }

    [Column("Type")]
    public string? Type { get; set; }

    [Column("Finishing")]
    public string? Finishing { get; set; }

    [Column("IsPackaging")]
    public bool IsPackaging { get; set; }

    [Column("Fats_Per_100_Gram")]
    public double? FatsPer100Gram { get; set; }

    [Column("Carbohydrates_Per_100_Gram")]
    public double? CarbohydratesPer100Gram { get; set; }

    [Column("Proteins_Per_100_Gram")]
    public double? ProteinsPer100Gram { get; set; }

    [Column("Kcal_Per_100_Gram")]
    public double? KcalPer100Gram { get; set; }

    [Column("Humidity_Per_Percent")]
    public double? HumidityPerPercent { get; set; }

    [Column("Expiration_Date")]
    public DateTime ExpirationDate { get; set; }

    [Column("Temperature_Storage")]
    public double TemperatureStorage { get; set; }

    [Column("FK_Temperature_Unit")]
    public int TemperatureUnitTDboId { get; set; }
    public TemperatureUnitTDbo? TemperatureUnitTDbo { get; set; }

    [Column("Description")]
    public string? Description { get; set; }

    public ItemDbo() { }

    public ItemDbo(ItemModel model) {
        Id = model.Id;
        Name = model.Name;
        Code = model.Code;
        ImagePath = model.ImagePath;
        Price = model.Price;
        CategoryTDboId = (int)model.Category.Type;
        SubcategoryTDboId = (int)model.Subcategory.Type;
        ItemStatusTDboId = (int)model.ItemStatus.Type;
        QuantityPerKg = model.QuantityPerKg;
        LikeCount = model.LikeCount;
        DislikeCount = model.DislikeCount;
        Brand = model.Brand;
        Type = model.Type;
        Finishing = model.Finishing;
        IsPackaging = model.IsPackaging;
        FatsPer100Gram = model.FatsPer100Gram;
        CarbohydratesPer100Gram = model.CarbohydratesPer100Gram;
        ProteinsPer100Gram = model.ProteinsPer100Gram;
        KcalPer100Gram = model.KcalPer100Gram;
        HumidityPerPercent = model.HumidityPerPercent;
        ExpirationDate = model.ExpirationDate;
        TemperatureStorage = model.TemperatureStorage;
        Description = model.Description;
    }
}