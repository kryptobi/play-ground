using FluentAssertions;
using Xunit;

namespace PaginationExample;
public class PagedListTests
{
    [Fact]
    public void CreateAsync_ReturnsPagedList_FirstItems()
    {
        // Arrange
        var data = new List<string> { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
        var queryableData = data.AsQueryable();

        var page = 1;
        var pageSize = 2;

        // Act
        var pagedList = PagedList<string>.Create(queryableData, page, pageSize);

        // Assert
        pagedList.Should().NotBeNull();
        pagedList.Item.Count.Should().Be(2);
        pagedList.TotalCount.Should().Be(data.Count);
        pagedList.HasPrevPage.Should().BeFalse();
    }
    
    [Fact]
    public void CreateAsync_ReturnsPagedListMixedItems_withNextPage()
    {
        // Arrange
        var data = new List<string> { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
        var queryableData = data.AsQueryable();

        var page = 2;
        var pageSize = 2;

        // Act
        var pagedList = PagedList<string>.Create(queryableData, page, pageSize);

        // Assert
        pagedList.Should().NotBeNull();
        pagedList.Item[0].Should().Be("Item 3");
        pagedList.Item[1].Should().Be("Item 4");
        pagedList.HasNextPage.Should().BeTrue();
    }
    
    [Fact]
    public void CreateAsync_ReturnsPagedListMixedItems_withoutNextPage()
    {
        // Arrange
        var data = new List<string> { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
        var queryableData = data.AsQueryable();

        var page = 3;
        var pageSize = 2;

        // Act
        var pagedList = PagedList<string>.Create(queryableData, page, pageSize);

        // Assert
        pagedList.Should().NotBeNull();
        pagedList.Item.First().Should().Be("Item 5");
        pagedList.Item.Count.Should().Be(1);
        pagedList.HasNextPage.Should().BeFalse();
    }
}
