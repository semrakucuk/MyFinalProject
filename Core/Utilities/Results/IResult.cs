using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{        
    //get:sadece okunabilir  
    //temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
