using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV2
{
    class Die
    {
        private int numberOfSides;

        public Die(int numberOfSides)
        {
            this.numberOfSides = numberOfSides;
        }

        public int Roll()
        {
            int rolledNumber = RandomGenerator.GetInstance().NextInt(1, numberOfSides + 1);
            return rolledNumber;
        }
    }

}
