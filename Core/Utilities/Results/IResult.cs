using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel void'ler için başlangıç.amaç bizim uygulamaları(api) kullananları yönlendirmek.
    public interface IResult
    {
        bool Success { get; } //get : sadece okunabilir demektir. set : yazmak içindir.
        string Message { get; }
    }
}
