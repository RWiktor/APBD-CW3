using System.Runtime.Serialization;

namespace APBD_CW3;

public class OverfillException : Exception
{
    public OverfillException() : base("Przekroczono maksymalna ladownosc")
    {
    }
    

    public OverfillException(string? message) : base(message)
    {
    }

    public OverfillException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}