﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    class Tiger : Animal
    {
        public override int GetMaxHealth()
        {
            return 4;
        }

        public override string GetAnimalType()
        {
            return "tiger";
        }

        public Tiger(string name) : base(name)
        {
        }
    }
}
