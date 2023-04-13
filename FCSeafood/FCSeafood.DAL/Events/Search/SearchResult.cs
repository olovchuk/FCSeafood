namespace FCSeafood.DAL.Events.Search;

public record SearchResult<T>(IReadOnlyCollection<T> Result, int TotalCount);