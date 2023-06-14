namespace FCSeafood.BusinessObjects;

#region Enumeration from database

/// <summary>
/// When changing these objects, you need to change them in the database.
/// </summary>

// E_Role_Type
public enum RoleType {
    Unknown = 0
  , Guest = 1
  , User = 2
  , Courier = 3
  , Moderator = 4
  , Administrator = 5
}

// E_Temperature_Unit
public enum TemperatureUnitType {
    Unknown = 0
  , Celsius = 1
  , Fahrenheit = 2
}

// E_Gender_Type
public enum GenderType {
    Unknown = 0
  , Male = 1
  , Female = 2
  , Other = 3
}

// E_Category_Type
public enum CategoryType {
    Unknown = 0
  , Fish = 1
  , Caviar = 2
  , Seafood = 3
  , CrabsСrayfish = 4
}

// E_Sub_Category_Type
public enum SubcategoryType {
    Unknown = 0

    // Fish
  , SeaFish = 1
  , RiverFish = 2
  , LakeFish = 3

    // Cavier
  , RedCaviar = 4
  , BlackSturgeonCaviar = 5
  , CodCaviar = 6
  , PikeCaviar = 7

    // Seafood
  , Mussels = 8
  , Squid = 9
  , Octopus = 10
  , Rapani = 11
  , SeafoodCocktail = 12
  , Shrimp = 13
  , LiveOyster = 14
  , Pectinida = 15

    // Crabs crayfish
  , Crabs = 16
  , Crayfish = 17
  , Lobster = 18
  , Omar = 19
}

// E_Currency_Code_Type
public enum CurrencyCodeType {
    Unknown = 0
  , UAH = 1
  , USD = 2
}

// E_Item_Status
public enum ItemStatusType {
    Unknown = 0
  , Available = 1
  , Ended = 2
  , Deleted = 3
}

public enum SortDirectionType {
    NoSort = 0
  , Ascending = 1
  , Descending = 2
}

// E_Rating_Type
public enum RatingType {
    Unknown = 0
  , Like = 1
  , Dislike = 2
}

// E_Delivery_Status_Type
public enum DeliveryStatusType {
    Unknown = 0
  , Pending = 1
  , InProcess = 2
  , Delivered = 3
  , Undelivered = 4
  , Rejected = 5
  , Return = 6
  , Delayed = 7
  , Cancelled = 8
}

// E_Payment_Method_Type
public enum PaymentMethodType {
    Unknown = 0
  , Cash = 1
  , Card = 2
  , PayPal = 3
}

#endregion