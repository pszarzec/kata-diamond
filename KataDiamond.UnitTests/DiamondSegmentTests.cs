using KataDiamond.Extensions;

namespace KataDiamond.UnitTests;

public class DiamondSegmentTests
{
    [Fact]
    public void DiamondSegment_InvalidPaddingSize_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new DiamondSegment('C', -2, StringExtensions.WhiteSpace));
    }
    
    [Fact]
    public void DiamondSegment_CorrectPadding_ReturnsValidSegment()
    {
        var segment = new DiamondSegment('C', 2, '*');
        
        Assert.Equal("**C***C**", segment.ToString());
    }
    
    [Fact]
    public void DiamondSegment_PaddingIsZero_ReturnsValidSegment()
    {
        var segment = new DiamondSegment('A', 0, '*');
        
        Assert.Equal("A", segment.ToString());
    }
}