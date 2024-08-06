namespace AMVTravelBusiness.Helpers
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T Data { get; private set; }
        public string Message { get; private set; }
        public Enum ErrorCode { get; private set; }

        private Result(bool isSuccess, T data, Enum errorCode, string message = "")
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorCode = errorCode;
            Message = message;
        }

        public static Result<T> Success(T data, string message = "")
        {
            return new Result<T>(true, data, null, message);
        }

        public static Result<T> Failure(Enum errorCode, string message = "")
        {
            return new Result<T>(false, default, errorCode, message);
        }
    }
}
