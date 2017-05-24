using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    class Bear : Animal
    {
        public override int GetMaxHealth()
        {
            return 6;
        }

        public Bear(string name) : base(name)
        {
        }
    }
}
