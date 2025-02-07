using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.CQS.Commands
{
    public class CommandResult
    {
        public static CommandResult Success()
        {
            return new CommandResult(true);
        }

        public static CommandResult Failure(string errorMessage, Exception? exception = null)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            return new CommandResult(false, errorMessage, exception);
        }

        public bool IsSuccess { get; }
        public bool IsFailure { get { return !IsSuccess; } }
        public string? ErrorMessage { get; }
        public Exception? Exception { get; }

        private CommandResult(bool isSuccess, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
