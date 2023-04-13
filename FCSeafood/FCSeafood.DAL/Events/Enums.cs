namespace FCSeafood.DAL.Events;

public enum SortDirection {
    Ascending = 0
  , Descending = 1
}

public enum RoleType {
    Unknown = 0
  , User
  , Moderator
  , Administrator
}

public enum ItemStatus {
    Error = 0
  , Available
  , Ended
  , Deleted
}

public enum DeliveryStatus {
    Error = 0
  , Pending
  , InProcess
  , OnRoad
  , Delivered
}

public enum GenderType {
    None = 0
  , Male
  , Female
}