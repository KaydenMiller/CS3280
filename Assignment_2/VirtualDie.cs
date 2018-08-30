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

        public VirtualDie(int sides)
        {
            this.sides = sides;
            timesRolled = new int[sides];
        }

        public int Roll()
        {
            int output = 0;
            Random rand = new Random();
            output = rand.Next(1, sides + 1);
            ++timesRolled[output - 1];
            return output;
        }

        public void Reset()
        {
            for (int i = 0; i < sides; i++)
            {
                timesRolled[i] = 0;
            }
        }

        public int GetHowManyTimesSideRolled(int side)
        {
            return timesRolled[side - 1];
        }
    }
}
