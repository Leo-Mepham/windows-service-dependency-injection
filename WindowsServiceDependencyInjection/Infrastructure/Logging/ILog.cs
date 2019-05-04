using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public interface ILog
    {
        void Log(LogLevel logLevel, string logEntry);
    }
}
