namespace Blog.Data.Results;

public class ApiResult<T> : ApiBaseResult
{
    public T Result { get; set; }
}