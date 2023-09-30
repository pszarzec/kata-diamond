using System.Text;

namespace KataDiamond;

public class Diamond
{
    private readonly StringBuilder _body;
    
    public string Body => _body.ToString();
    
    public static Diamond BuildWithSize(DiamondSize diamondSize)
    {
        var diamond = new Diamond(diamondSize);
        return diamond;
    }

    private Diamond(DiamondSize diamondSize)
    {
        _body = new StringBuilder();
        GenerateBody(diamondSize.Size);
    }

    private void GenerateBody(char targetSize)
    {
        _body.Append("A");
    }
}