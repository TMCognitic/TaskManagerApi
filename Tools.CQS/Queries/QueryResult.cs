using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.CQS.Queries
{
    public class QueryResult<TResult>
    {
        public static QueryResult<TResult> Success(TResult result)
        {
            return new QueryResult<TResult>(true, result);
        }

        public static QueryResult<TResult> Failure(string errorMessage, Exception? exception = null)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            return new QueryResult<TResult>(false, default!, errorMessage, exception);
        }

        private readonly TResult _result;

        public bool IsSuccess { get; }
        public bool IsFailure { get { return !IsSuccess; } }
        public string? ErrorMessage { get; }
        public Exception? Exception { get; }

        public TResult Result
        {
            get
            {
                if (IsFailure)
                    throw new InvalidOperationException();

                return _result;
            }
        }

        private QueryResult(bool isSuccess, TResult result, string? errorMessage = null, Exception? exception = null)
        {
            _result = result;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
