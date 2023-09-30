namespace KataDiamond.Exceptions;

public class InvalidDiamondSizeException : Exception
{
    public InvalidDiamondSizeException(char size) 
        : base($"\"{size}\" is invalid size of the diamond. Allowed characters are upper case Latin letters.")
    {
    }
}