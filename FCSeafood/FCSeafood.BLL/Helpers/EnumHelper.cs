namespace FCSeafood.BLL.Helpers;

public static class EnumHelper {
    public static CategoryTypeModel GetCategoryType(CategoryType categoryType) {
        var result = new CategoryTypeModel {
            Type = categoryType
          , Text = categoryType switch {
                CategoryType.Fish       => "Fish"
              , CategoryType.Caviar     => "Caviar"
              , CategoryType.Seafood    => "Seafood"
              , CategoryType.CannedFood => "CannedFood"
              , _                       => string.Empty
            }
        };
        return result;
    }

    public static SubCategoryTypeModel GetSubCategoryType(SubCategoryType subCategoryType) {
        var result = new SubCategoryTypeModel {
            Type = subCategoryType
          , Text = subCategoryType switch {
                // Fish
                SubCategoryType.SeaFish   => "Fish"
              , SubCategoryType.RiverFish => "Caviar"
              , SubCategoryType.LakeFish  => "Seafood"

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
}