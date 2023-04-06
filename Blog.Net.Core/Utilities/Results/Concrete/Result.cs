using Blog.Net.Core.Utilities.Result.Abstract;

namespace Blog.Net.Core.Utilities.Result.Concrete
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
