namespace SleekFlow.TODOs.Result
{
    public class StandardResult<T>
    {
        public T? Result { get; set; }

        public int StatusCode { get; set; }

        public string? ErrorMessage { get; set; }

        public StandardResult
            (
            T? result,
            int statusCode,
            string? errorMessage
            )
        {
            Result = result;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
