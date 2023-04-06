namespace Blog.Net.Core.Utilities.Result.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
