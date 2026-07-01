namespace MyStore.Application.Messages;


public class Result
{
    public IEnumerable<string> Errors { get; } = [];
    public ResultStatus Status { get; }
    public bool IsSuccess => Status == ResultStatus.Success;

    protected Result(ResultStatus status) => Status = status;
    protected Result(IEnumerable<string> errors, ResultStatus status)
    {
        Errors = errors;
        Status = status;
    }

    public static Result Success() => new(ResultStatus.Success);
    public static Result NoContent() => new(ResultStatus.NoContent);
    public static Result NotFound(string error) => new([error], ResultStatus.NotFound);
    public static Result ValidationError(IEnumerable<string> errors) => new(errors, ResultStatus.ValidationError);
    public static Result ValidationError(string error) => new([error], ResultStatus.ValidationError);
}
public class Result<T> : Result
{
    public T? Value { get; }

    private Result(T value) : base(ResultStatus.Success) => Value = value;
    private Result(IEnumerable<string> errors, ResultStatus status) : base(errors, status) { }

    public static Result<T> Success(T value) => new(value);
    public new static Result<T> NoContent() => new([], ResultStatus.NoContent);
    public new static Result<T> NotFound(string error) => new([error], ResultStatus.NotFound);
    public new static Result<T> ValidationError(IEnumerable<string> errors) => new(errors, ResultStatus.ValidationError);
    public new static Result<T> ValidationError(string error) => new([error], ResultStatus.ValidationError);
}
