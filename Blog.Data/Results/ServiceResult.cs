﻿namespace Blog.Data.Results;

public class ServiceResult<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Result { get; set; }
}