﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    class Wolf : Animal
    {
        public override int GetMaxHealth()
        {
            return 4;
        }

        public override string GetAnimalType()
        {
            return "wolf";
        }

        public Wolf(string name) : base(name)
        {
        }
    }
}
