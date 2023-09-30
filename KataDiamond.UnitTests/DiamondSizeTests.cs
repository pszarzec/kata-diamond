using KataDiamond.Exceptions;

namespace KataDiamond.UnitTests;

public class DiamondSizeTests
{
    [Theory]
    [InlineData('#')]
    [InlineData('3')]
    [InlineData('a')]
    public void DiamondSize_InvalidSize_ThrowsInvalidDiamondSizeException(char invalidSize)
    {
        Assert.Throws<InvalidDiamondSizeException>(() => new DiamondSize(invalidSize));
    }
    
    [Theory]
    [InlineData('E')]
    [InlineData('X')]
    [InlineData('A')]
    public void DiamondSize_CorrectSize_ReturnsValidSize(char size)
    {
        var diamondSize = new DiamondSize(size);
        
        Assert.Equal(size, diamondSize.Size);
    }
}