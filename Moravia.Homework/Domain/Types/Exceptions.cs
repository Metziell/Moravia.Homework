namespace Moravia.Homework.Domain.Types;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
}