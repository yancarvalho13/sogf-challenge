namespace SOGF.Shared.Result;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set;}
    public bool isSucces { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public long TotalRecords { get; set; }
    public long TotalPages { get; set; }

    public PagedResult(IEnumerable<T> items, bool isSucces, int page, int pageSize, long totalRecords, long totalPages)
    {
        Items = items;
        this.isSucces = isSucces;
        Page = page;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        TotalPages = totalPages;
    }
    
    public static PagedResult<T> EmptyResult() => new (new List<T>(),
        true,
        0,
        0,0,0);

    public static PagedResult<T> Success(List<T> values,
        int page,
        int pageSize,
        long totalRecords,
        long totalPages) => 
        new(values, true, page, pageSize,
            totalRecords, totalPages);
}