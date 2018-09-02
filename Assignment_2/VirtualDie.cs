using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    /// <summary>
    /// The VirtualDie class represents a Die of 'x' sides. The die can then be 'rolled' to determine which side will be face up.
    /// </summary>
    public class VirtualDie
    {
        private int sides = 6;
        private int[] timesRolled;

        /// <summary>
        /// Constructor for the virtual die. Pass in the amount of sides on the die you wish it to have.
        /// </summary>
        /// <param name="sides"></param>
        public VirtualDie(int sides)
        {
            this.sides = sides;
            timesRolled = new int[sides];
        }

        /// <summary>
        /// Will roll the die based on how many sides the die has.
        /// </summary>
        /// <returns>Side Rolled as int</returns>
        public int Roll()
        {
            int output = 0;
            Random rand = new Random();
            output = rand.Next(1, sides + 1);
            ++timesRolled[output - 1];
            return output;
        }

        /// <summary>
        /// Resets all information stored in the die, not including sides.
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < sides; i++)
            {
                timesRolled[i] = 0;
            }
        }

        /// <summary>
        /// Gets the value of how many times the requested side on this die has been rolled.
        /// </summary>
        /// <param name="side"></param>
        /// <returns>The times the side inputed has been rolled as int</returns>
        public int GetHowManyTimesSideRolled(int side)
        {
            return timesRolled[side - 1];
        }
    }
}
