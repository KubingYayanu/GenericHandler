namespace GenericHandler.Core.Models
{
    public class Result : IResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }

    public class Result<T> : Result, IResult<T>
    {
        public T Data { get; set; }
    }
}