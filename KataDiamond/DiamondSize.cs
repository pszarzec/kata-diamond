using KataDiamond.Exceptions;

namespace KataDiamond;

public class DiamondSize
{
    public static char MinDiamondSize => 'A';
    public static char MaxDiamondSize => 'Z';
    
    public char Size { get; }

    public DiamondSize(char size)
    {
        if (size < MinDiamondSize || size > MaxDiamondSize)
        {
            throw new InvalidDiamondSizeException(size);
        }

        Size = size;
    }
}