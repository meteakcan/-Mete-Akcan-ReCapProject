using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) //base:Result(yukarıdaki)
        {

        }
        public SuccessResult() : base(true) //base'nin tek parametreli olanını çalıştır.(true'yi default değer gönderdik.)
        {

        }
    }
}
