using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Utilities
{
    public class OperationResult
    {
        public OperationStatus Status { get; set; } = OperationStatus.Success;
        public List<string> Messages { get; private set; } = new List<string>();

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
