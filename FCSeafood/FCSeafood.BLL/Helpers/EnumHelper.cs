namespace FCSeafood.BLL.Helpers;

public static class EnumHelper {
    public static CategoryTModel GetCategoryType(CategoryType categoryType) {
        var result = new CategoryTModel {
            Type = categoryType
          , Name = categoryType switch {
                CategoryType.Unknown       => "N/A"
              , CategoryType.Fish          => "Fish"
              , CategoryType.Caviar        => "Caviar"
              , CategoryType.Seafood       => "Seafood"
              , CategoryType.CrabsСrayfish => "Crabs/Сrayfish"
              , _                          => string.Empty
            }
        };
        return result;
    }

    public static SubcategoryTModel GetSubcategoryType(SubcategoryType subcategoryType) {
        var result = new SubcategoryTModel {
            Type = subcategoryType
          , Name = subcategoryType switch {
                SubcategoryType.Unknown => "N/A"

                // Fish
              , SubcategoryType.SeaFish   => "Sea fish"
              , SubcategoryType.RiverFish => "River fish"
              , SubcategoryType.LakeFish  => "Lake fish"

                // Cavier
              , SubcategoryType.RedCaviar           => "Red caviar"
              , SubcategoryType.BlackSturgeonCaviar => "Black sturgeon caviar"
              , SubcategoryType.CodCaviar           => "Cod caviar"
              , SubcategoryType.PikeCaviar          => "Pike caviar"

                // Seafood
              , SubcategoryType.Mussels         => "Mussels"
              , SubcategoryType.Squid           => "Squid"
              , SubcategoryType.Octopus         => "Octopus"
              , SubcategoryType.Rapani          => "Rapani"
              , SubcategoryType.SeafoodCocktail => "Seafood cocktail"
              , SubcategoryType.Shrimp          => "Shrimp"
              , SubcategoryType.LiveOyster      => "Live oyster"
              , SubcategoryType.CrabAndLobster  => "Crab and lobster"
              , SubcategoryType.Pectinida       => "Pectinida"
              , _                               => string.Empty
            }
        };
        return result;
    }

    public static ItemStatusTModel GetItemStatusType(ItemStatusType itemStatusType) {
        var result = new ItemStatusTModel {
            Type = itemStatusType
          , Name = itemStatusType switch {
                ItemStatusType.Unknown   => "N/A"
              , ItemStatusType.Available => "Available"
              , ItemStatusType.Ended     => "Ended"
              , ItemStatusType.Deleted   => "Deleted"
              , _                        => string.Empty
            }
        };
        return result;
    }

    public static TemperatureUnitTModel GetTemperatureUnitType(TemperatureUnitType temperatureUnitType) {
        var result = new TemperatureUnitTModel { Type = temperatureUnitType };
        switch (temperatureUnitType) {
            case TemperatureUnitType.Unknown:
                result.Name = "N/A";
                result.Sign = "";
                break;
            case TemperatureUnitType.Celsius:
                result.Name = "Celsius";
                result.Sign = "C";
                break;
            case TemperatureUnitType.Fahrenheit:
                result.Name = "Fahrenheit";
                result.Sign = "F";
                break;
            default:
                result.Name = string.Empty;
                result.Sign = string.Empty;
                break;
        }

        return result;
    }

    public static CurrencyCodeTModel GetCurrencyCodeType(CurrencyCodeType currencyCodeType) {
        var result = new CurrencyCodeTModel {
            Type = currencyCodeType
          , Name = currencyCodeType switch {
                CurrencyCodeType.Unknown => "N/A"
              , CurrencyCodeType.UAH     => "UAH"
              , CurrencyCodeType.USD     => "USD"
              , _                        => string.Empty
            }
        };

        return result;
    }
}