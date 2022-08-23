using Newtonsoft.Json;

namespace Blog.Data.Results;

public class ApiErrorResult : ApiBaseResult
{
    public ApiErrorResult()
    {
        Error = true;
        Messages = new List<string>();
    }

    public ApiErrorResult(string message)
        : this()
    { 
        Messages?.Add(message);
    }

    public List<string>? Messages { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}