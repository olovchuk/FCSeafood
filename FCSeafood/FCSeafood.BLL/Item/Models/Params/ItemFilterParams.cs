namespace FCSeafood.BLL.Item.Models.Params;

public record ItemFilterParams(CategoryType CategoryType
                             , SubcategoryType SubcategoryType
                             , double PriceFrom
                             , double PriceTo);