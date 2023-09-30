using KataDiamond;

char inputSize;

if (args.Any())
{
    var argument = args.FirstOrDefault();
    if (argument?.Length == 1)
    {
        inputSize = argument.First();
    }
    else
    {
        Console.WriteLine("The argument must be a letter of the Latin alphabet.");
        return -1;
    }
}
else
{
    inputSize = Console.ReadKey().KeyChar;
}

var diamondSize = new DiamondSize(inputSize);
var diamond = Diamond.BuildWithSize(diamondSize);

Console.WriteLine(diamond.Body);

return 0;