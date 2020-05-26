using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class OperationResult
    {
        public static OperationResult Success => new OperationResult();
        public static OperationResult Fail(string error) => new OperationResult(error);

        public OperationResult(string error = null)
        {
            if (!(error is null)) Errors.Add(error);
        }

        public OperationResult(List<string> errors)
        {
            this.Errors = errors;
        }

        public bool IsSuccessful => Errors.Count == 0;

        public List<string> Errors { get; } = new List<string>();
    }

    public class OperationResult<T> : OperationResult
    {
        public OperationResult(T result)
        {
            Result = result;
        }

        public OperationResult(T result, OperationResult baseOperationResult) : base(baseOperationResult.Errors)
        {
            Result = result;
        }

        public OperationResult(OperationResult baseOperationResult) : base (baseOperationResult.Errors)
        {

        }

        public T Result { get; set; }
    }
}
