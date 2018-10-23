using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Exceptions
{
    /// <summary>
    /// Custom exception just for use with determining if the user was authed or not
    /// this does not need any custom attributes at this time, the exception name alone 
    /// will suffice for my needs.
    /// </summary>
    public class UserNotAuthenticatedException : Exception
    {
        /// <summary>
        /// UserNotAuth ctor
        /// </summary>
        public UserNotAuthenticatedException()
        {
            
        }

        /// <summary>
        /// UserNotAuth ctor with alterable message param
        /// </summary>
        /// <param name="message"></param>
        public UserNotAuthenticatedException(string message) 
            : base(message)
        {

        }
    }
}
