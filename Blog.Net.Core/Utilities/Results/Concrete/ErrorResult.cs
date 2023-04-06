namespace Blog.Net.Core.Utilities.Result.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
