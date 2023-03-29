namespace Library.BusinessLayer.Exceptions;

public class NotFoundException : Exception
{ 
    /// <summary>
    /// Initalizes a new instance of <see cref="NotFoundException"/>
    /// </summary>
    /// <param name="message"></param>
    public NotFoundException(string? message) : base(message)
    {

    }
}
