using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    class Elephant : Animal
    {
        public override int GetMaxHealth()
        {
            return 7;
        }

        public override string GetAnimalType()
        {
            return "elephant";
        }

        public Elephant(string name) : base(name)
        {
        }
    }
}
