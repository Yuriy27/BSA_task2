using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zoo.Repository;
using Zoo.Exceptions;

namespace Zoo.Animals
{
    class AnimalFactory
    {
   
        public static Animal Create(string type, string name)
        {
            Animal result = null;
            switch (type)
            {
                case "lion": result = new Lion(name); break;
                case "tiger": result = new Tiger(name); break;
                case "elephant": result = new Elephant(name); break;
                case "bear": result = new Bear(name); break;
                case "wolf": result = new Wolf(name); break;
                case "fox": result = new Fox(name); break;
                default: throw new BadAnimalTypeException();
            }
            return result;
        }
    }
}
