using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    class Fox : Animal
    {
        public override int GetMaxHealth()
        {
            return 3;
        }

        public override string GetType()
        {
            return "fox";
        }

        public Fox(string name) : base(name)
        {
        }
    }
}
