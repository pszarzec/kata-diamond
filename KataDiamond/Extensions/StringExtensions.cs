namespace KataDiamond.Extensions;

public static class StringExtensions
{
    public const char WhiteSpace = ' ';
    
    public static IEnumerable<string> AllLines(this string input) 
        => input.Split(Environment.NewLine);
    
    public static string TrimNewLines(this string input) 
        => input.Replace(Environment.NewLine, string.Empty);
    
    public static string TrimAllWhiteCharacters(this string input) 
        => input.Replace(WhiteSpace.ToString(), string.Empty);
}