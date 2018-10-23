using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Utilities
{
    /// <summary>
    /// Allows for failed operation checking without throwing an exception as that is bad practice.
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Status of the operation, Success or Failue
        /// </summary>
        public OperationStatus Status { get; set; } = OperationStatus.Success;
        /// <summary>
        /// Any messages associated with the operation 
        /// </summary>
        public List<string> Messages { get; private set; } = new List<string>();

        /// <summary>
        /// Add a message to the result
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
