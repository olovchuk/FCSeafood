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

    [Column("FK_Price")]
    public Guid PriceId { get; set; }

    [Column("FK_Category_Type")]
    public CategoryType CategoryType { get; set; }

    [Column("FK_Sub_Category_Type")]
    public SubCategoryType SubCategoryType { get; set; }

    [Column("FK_Item_Status_Type")]
    public ItemStatusType ItemStatusType { get; set; }

    [Column("Quantity_Per_Kg")]
    public double QuantityPerKg { get; set; }

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
    public TemperatureUnit TemperatureUnit { get; set; }

    [Column("Description")]
    public string? Description { get; set; }
}