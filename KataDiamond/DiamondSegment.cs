using System.Text;

namespace KataDiamond;

public class DiamondSegment
{
    private readonly StringBuilder _body;
    private readonly char _filling;

    public DiamondSegment(char segmentLetter, int paddingSize, char filling)
    {
        if (paddingSize < 0)
        {
            throw new ArgumentException("Padding size cannot be a negative number.");
        }
        
        _body = new StringBuilder();
        _filling = filling;
        
        GenerateSegment(segmentLetter, paddingSize);
    }

    public override string ToString()
    {
        return _body.ToString();
    }

    private void GenerateSegment(char segmentLetter, int padding)
    {
        // Leading 
        AddFilling(padding);

        // Segment character
        _body.Append(segmentLetter);

        if (IsSegmentBetweenApexes(segmentLetter))
        {
            // Inner
            AddFilling(InnerFillingSize(segmentLetter));
            _body.Append(segmentLetter);
        }

        // Trailing
        AddFilling(padding);
    }

    private void AddFilling(int padding)
    {
        _body.Append(new string(_filling, padding));
    }

    private bool IsSegmentBetweenApexes(char letter) => letter != 'A';
    
    private int InnerFillingSize(char letter)
    {
        const int innerSpaceMultiplier = 2;
        return (letter - 'A') * innerSpaceMultiplier - 1;
    }
}