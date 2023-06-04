namespace FCSeafood.BLL.Item.Models.Params;

public record ItemFilterParams(
    CategoryType CategoryType
  , SubcategoryType SubcategoryType
  , SortDirectionType SortDirectionType
  , double PriceFrom
  , double PriceTo
);