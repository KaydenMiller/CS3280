using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5.Models;

namespace Assignment_5.Models
{
    //output = (int)Math.Pow(timeElapsed, 3) / (int)Math.Floor(Math.Sqrt(timeElapsed));
    /// <summary>
    /// The score Data Model
    /// </summary>
    public class Score
    {
        /// <summary>
        /// The username of the user to whom this score belongs
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Score value attatched to this object
        /// </summary>
        public int Value { get; set; }
    }
}
