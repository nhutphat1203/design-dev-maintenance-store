using System;
using System.Collections.Generic;
using System.Text;

namespace CuahangNongduoc.Utils.Logger
{
    public interface ILogger
    {
        void Info(string message);
        void Error(string message, Exception ex);
        void Debug(string message);

    }
}
