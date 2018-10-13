using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Models
{
    class User
    {
        public uint ID { get; set; }
        public string Username { get; set; }
        public uint Age { get; set; }
        public Level Addition { get; set; }
        public Level Subtraction { get; set; }
        public Level Multiplication { get; set; }
        public Level Division { get; set; }
    }
}
