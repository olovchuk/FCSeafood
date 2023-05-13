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

    public static SubCategoryTModel GetSubCategoryType(SubCategoryType subCategoryType) {
        var result = new SubCategoryTModel {
            Type = subCategoryType
          , Name = subCategoryType switch {
                SubCategoryType.Unknown => "N/A"

                // Fish
              , SubCategoryType.SeaFish   => "Sea fish"
              , SubCategoryType.RiverFish => "River fish"
              , SubCategoryType.LakeFish  => "Lake fish"

                // Cavier
              , SubCategoryType.RedCaviar           => "Red caviar"
              , SubCategoryType.BlackSturgeonCaviar => "Black sturgeon caviar"
              , SubCategoryType.CodCaviar           => "Cod caviar"
              , SubCategoryType.PikeCaviar          => "Pike caviar"

                // Seafood
              , SubCategoryType.Mussels         => "Mussels"
              , SubCategoryType.Squid           => "Squid"
              , SubCategoryType.Octopus         => "Octopus"
              , SubCategoryType.Rapani          => "Rapani"
              , SubCategoryType.SeafoodCocktail => "Seafood cocktail"
              , SubCategoryType.Shrimp          => "Shrimp"
              , SubCategoryType.LiveOyster      => "Live oyster"
              , SubCategoryType.CrabAndLobster  => "Crab and lobster"
              , SubCategoryType.Pectinida       => "Pectinida"
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