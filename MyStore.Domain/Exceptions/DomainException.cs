using System.Net;

namespace MyStore.Domain.Exceptions;

public class DomainException(string message) : Exception(message)
{
    public int StatusCode { get; init; } = (int)HttpStatusCode.BadRequest;
}