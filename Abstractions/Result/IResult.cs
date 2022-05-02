﻿namespace Abstractions.Results;

public interface IResult
{
    bool Failed { get; }

    string Message { get; }

    bool Succeeded { get; }

    public int HttpResponseCode { get; }
}

public interface IResult<out T> : IResult
{
    T? Data { get; }
}