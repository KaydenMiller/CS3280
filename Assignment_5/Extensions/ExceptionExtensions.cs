using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5.Extensions
{
    /// <summary>
    /// Extention methods for use with exception handleing
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// This function will extend the Exeption class in C# and write to a log file.
        /// This will write the full inner stack trace to the log file.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception Log(this Exception ex)
        {
            File.AppendAllText("CoughtExceptions" + DateTime.Now.ToString("yyyy-MM-dd") + ".log",
                               DateTime.Now.ToString("HH:mm:ss") + ": " + ex.Message + "\n" + ex.ToString() + "\n");
            return ex;
        }
    }
}
