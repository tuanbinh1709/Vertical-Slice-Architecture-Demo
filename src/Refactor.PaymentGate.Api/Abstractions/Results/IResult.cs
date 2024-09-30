﻿namespace Refactor.PaymentGate.Api.Abstractions.Results;

public interface IResult<out TValue> : IResult
{
    TValue Value { get; }
}

public interface IResult
{
    bool IsSuccess { get; }

    bool IsFailure { get; }

    Error Error { get; }
}
