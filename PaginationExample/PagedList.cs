using Microsoft.EntityFrameworkCore;
namespace PaginationExample;

public class PagedList<T> {
    private PagedList(List<T> item, int page, int pageSize, int totalCount)
    {
        Item = item;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public List<T> Item {get;}
    public int Page {get;}
    public int PageSize {get;}
    public int TotalCount {get;}
    
    public bool HasNextPage => Page * PageSize < TotalCount;
    
    public bool HasPrevPage => PageSize < 1;
    
    public static async Task<PagedList<T>> CreateAsync(
        IQueryable<T> query, 
        int page,
        int pageSize,
        CancellationToken cancellationToken
    ) {
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedList<T>(items, page, pageSize, totalCount);
    }
    
    public static PagedList<T> Create(
        IQueryable<T> query, 
        int page,
        int pageSize
    ) {
        var totalCount = query.Count();
        var items =  query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new PagedList<T>(items, page, pageSize, totalCount);
    }
}