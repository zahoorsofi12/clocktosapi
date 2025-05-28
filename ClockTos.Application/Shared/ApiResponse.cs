using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockTos.Application.Shared
{
    public class ApiResponse<T>
    {

        public readonly bool _IsSuccess;

        private readonly string _Message = string.Empty;

        private readonly int _Status;

        private readonly T? _Result;

        public bool IsSuccess => _IsSuccess;

        public string Message => _Message;

        public int Status => _Status;

        public T? Result => _Result;


        public ApiResponse(T result, string message, int status)
        {

            if (status < 100 && status > 600)
            {
                throw new ArgumentException("Invalid Code");
            }
            this._Result = result;
            this._Message = message;
            this._Status = status;
            this._IsSuccess = true;

        }

        public ApiResponse(string message, int status)
        {
            if (status < 100 && status > 600)
            {
                throw new ArgumentException("Invalid Code");
            }
            this._IsSuccess = false;
            this._Message = message;
            this._Status = status;
            this._IsSuccess = false;
        }


        public static ApiResponse<T> SuccessResponse(T? result = default, string message = "Success", int status = ApiStatusCodes.OK)
        {
            return new ApiResponse<T>(result, message, status);
        }

        public static ApiResponse<T> ErrorResponse(string message, int status = 500)
        {
            return new ApiResponse<T>(message, status);
        }
    }
}
