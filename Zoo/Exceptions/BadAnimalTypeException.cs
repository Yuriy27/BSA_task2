using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Exceptions
{
    class BadAnimalTypeException : Exception
    {
        public BadAnimalTypeException() { }

        public BadAnimalTypeException(string message) : base(message) { }
    }
}
