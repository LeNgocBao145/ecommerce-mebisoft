namespace ProductService.Domain.Exceptions
{
    public class InvalidParamsException(string message) : Exception(message)
    {
    }
}
