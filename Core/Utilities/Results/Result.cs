using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success) //this:bu class
        {
            //aşağıdaki Message'yi message olarak set et.(get'ler Constructor'da set edilebilir.)
            Message = message;
        }
        public Result(bool success) //Mesaj yazma işini yukarı,success'i aşağı veriyoruz.
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
