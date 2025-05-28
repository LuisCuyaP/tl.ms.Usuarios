using System.Diagnostics.CodeAnalysis;

namespace Usuarios.Domain.Abstractions;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new ArgumentException("Error must be None when the result is successful.", nameof(error));
        if (!isSuccess && error == Error.None)
            throw new ArgumentException("Error must not be None when the result is a failure.", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
    }
   
    public bool IsSuccess { get; }
    public Error Error { get; }
    public bool IsFailure => !IsSuccess;
    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    public static Result<TValue> Create<TValue>(TValue value)
    => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}

public class Result<TValue> : Result
{
    public readonly TValue? _value;
    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    [NotNull]
    public TValue Value => IsSuccess ? 
        _value! : throw new InvalidOperationException("Cannot access Value when the result is a failure.");

    public static implicit operator Result<TValue>(TValue value) => Create(value);
}

