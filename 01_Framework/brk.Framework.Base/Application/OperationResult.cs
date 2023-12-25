namespace brk.Framework.Base.Application
{
    public class OperationResult<T>
    {
        #region properties
        public string Message { get; private set; }
        public bool IsSuccess { get; private set; }
        public OperationResultStatusCode StatusCode { get; private set; }
        public T Data { get; set; }

        #endregion

        #region constructors

        private OperationResult(bool isSuccess, string message, OperationResultStatusCode statusCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }

        public OperationResult(bool isSuccess, string message, OperationResultStatusCode statusCode, T date) : this(isSuccess, message, statusCode)
        {
            Data = date;
        }

        #endregion

        #region methods

        public static OperationResult<T> Success(T data,string message="عملیات با موفقیت انجام شد") => new(true, message,OperationResultStatusCode.Success,data);
        public static OperationResult<T> Info(string message) => new(true, message,OperationResultStatusCode.Info);

        public static OperationResult<T> Error(string message)=>new(false, message,OperationResultStatusCode.Error);
        public static OperationResult<T> Warning(string message) => new(false, message, OperationResultStatusCode.Error);
        
        #endregion
    }

    public class OperationResult
    {
        #region properties

        public string Message { get; private set; }
        public bool IsSuccess { get; private set; }
        public OperationResultStatusCode StatusCode { get; private set; }

        #endregion
     
        public OperationResult(bool isSuccess, string message, OperationResultStatusCode statusCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }

        #region methods

        public static OperationResult Success(string message) => new(true, message, OperationResultStatusCode.Success);
        public static OperationResult Info(string message) => new(true, message, OperationResultStatusCode.Info);

        public static OperationResult Warning(string message) => new(false, message, OperationResultStatusCode.Warning);

        public static OperationResult Error(string message) => new(false, message, OperationResultStatusCode.Error);

        #endregion
    }


    public enum OperationResultStatusCode
    {
        Success = 1,
        Info,
        Warning,
        Error,
        ValidationFailed,
        NotFound
    }
}
