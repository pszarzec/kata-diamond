using System.Text;
using KataDiamond.Extensions;

namespace KataDiamond;

public class Diamond
{
    private readonly StringBuilder _body;
    private readonly char _fillingChar;
    
    public string Body => _body.ToString();
    
    public static Diamond BuildWithSize(DiamondSize diamondSize)
    {
        var diamond = new Diamond(diamondSize);
        return diamond;
    }

    private Diamond(DiamondSize diamondSize)
    {
        _body = new StringBuilder();
        _fillingChar = StringExtensions.WhiteSpace;
        
        GenerateBody(DiamondSize.MinDiamondSize, diamondSize.Size);
    }

    private void GenerateBody(char currentSize, char targetSize)
    {
        if (IsMinimalSize(targetSize))
        {
            _body.Append(currentSize);
            return;    
        }
        
        if (IsUpperPartReady(currentSize, targetSize))
        {
            return;
        }

        GenerateSegment(currentSize, targetSize);
        _body.AppendLine();
        
        // Recursive call
        GenerateBody((char)(currentSize + 1), targetSize);
        
        if (IsBottomPartReady(currentSize, targetSize))
        {
            return;
        }
        
        GenerateSegment(currentSize, targetSize);

        if (currentSize != DiamondSize.MinDiamondSize)
        {
            _body.AppendLine();
        }
    }

    private void GenerateSegment(char currentSize, char targetSize)
    {
        var paddingSize = targetSize - currentSize;
        _body.Append(new DiamondSegment(currentSize, paddingSize, _fillingChar));
    }

    private bool IsUpperPartReady(char currentSize, char targetSize)
        => currentSize > targetSize;
    
    private bool IsBottomPartReady(char currentSize, char targetSize)
        => currentSize >= targetSize;

    private bool IsMinimalSize(char targetSize)
        => targetSize == DiamondSize.MinDiamondSize;
}