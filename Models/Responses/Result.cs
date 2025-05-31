namespace QueroNotaFiscal.Models.Response
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Value { get; set; }

        private Result(bool isSuccess, T value, string errorMessage = null)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, default, errorMessage);
        }
    }
}
