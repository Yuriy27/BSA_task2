using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    class Lion : Animal
    {
        public override int GetMaxHealth()
        {
            return 5;
        }

        public Lion(string name) : base(name)
        {
        }
    }
}
