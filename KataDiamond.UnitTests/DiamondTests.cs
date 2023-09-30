using KataDiamond.Extensions;

namespace KataDiamond.UnitTests;

public class DiamondTests
{
    [Fact]
    public void BuildWithSize_SpecificSize_CreatesValidDiamond()
    {
        var diamondSize = new DiamondSize('C');
        
        var diamond = Diamond.BuildWithSize(diamondSize);

        const char space = StringExtensions.WhiteSpace;
        var expectedBody =
            $"{space}{space}A{space}{space}{Environment.NewLine}" +
            $"{space}B{space}B{space}{Environment.NewLine}" +
            $"C{space}{space}{space}C{Environment.NewLine}" +
            $"{space}B{space}B{space}{Environment.NewLine}" +
            $"{space}{space}A{space}{space}";
        
        Assert.Equal(expectedBody, diamond.Body);
    }
    
    [Theory]
    [InlineData('A')]
    [InlineData('D')]
    [InlineData('W')]
    public void BuildWithSize_AnySize_NoNewLineAtEnd(char size)
    {
        var diamondSize = new DiamondSize(size);
        
        var diamond = Diamond.BuildWithSize(diamondSize);
        
        Assert.False(diamond.Body.EndsWith(Environment.NewLine));
    }

    [Fact]
    public void BuildWithSize_SmallestSize_CreatesValidDiamond()
    {
        var diamondSize = new DiamondSize('A');
        
        var diamond = Diamond.BuildWithSize(diamondSize);
        
        Assert.Equal("A", diamond.Body);
    }

    [Theory]
    [InlineData('A')]
    [InlineData('E')]
    public void Diamond_ValidBody_HaveAtLeastOneSegment(char size)
    {
        var diamondSize = new DiamondSize(size);
        
        var diamond = Diamond.BuildWithSize(diamondSize);

        var diamondSegments = diamond.Body.AllLines();
        Assert.True(diamondSegments.Any());
    }
    
    [Fact]
    public void Diamond_ValidBody_StartsWithApex()
    {
        var diamondSize = new DiamondSize('C');
        
        var diamond = Diamond.BuildWithSize(diamondSize);

        var diamondSegments = diamond.Body.AllLines();
        Assert.Contains("A", diamondSegments.FirstOrDefault() ?? string.Empty);
    }
    
    [Fact]
    public void Diamond_ValidBody_EndsWithApex()
    {
        var diamondSize = new DiamondSize('T');
        
        var diamond = Diamond.BuildWithSize(diamondSize);

        var diamondSegments = diamond.Body.AllLines();
        Assert.Contains("A", diamondSegments.LastOrDefault() ?? string.Empty);
    }
    
    [Fact]
    public void Diamond_ValidBody_DiamondIsSymmetrical()
    {
        var diamondSize = new DiamondSize('T');
        
        var diamond = Diamond.BuildWithSize(diamondSize);

        var diamondSegments = diamond.Body.AllLines();
        var diamondHeight = diamondSegments.Count();
        var diamondWidth = diamondSegments.FirstOrDefault().Length;
        
        Assert.Equal(diamondHeight, diamondWidth);
    }
    
    [Fact]
    public void Diamond_ValidBody_LettersHaveCorrectOrder()
    {
        var diamondSize = new DiamondSize('E');
        
        var diamond = Diamond.BuildWithSize(diamondSize);

        const string correctOrder = "ABBCCDDEEDDCCBBA";
        var actualOrder = diamond.Body.TrimNewLines().TrimAllWhiteCharacters();
        
        Assert.Equal(correctOrder, actualOrder);
    }
    
    [Fact]
    public void Diamond_ValidBody_ContainsSpaceCharacter()
    {
        var diamondSize = new DiamondSize('E');
        
        var diamond = Diamond.BuildWithSize(diamondSize);

        var diamondSegments = diamond.Body.AllLines();
        Assert.All(diamondSegments, segment => Assert.Contains(StringExtensions.WhiteSpace, segment));
    }
}