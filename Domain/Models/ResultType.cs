namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

public class ResultType
{
    public bool IsError { get; }

    public string Message { get; }

    private ResultType(bool isError, string message)
    {
        IsError = isError;
        Message = message;
    }

    public static ResultType Error(string message)
    {
        return new ResultType(true, message);
    }

    public static ResultType Success(string message)
    {
        return new ResultType(false, message);
    }
}