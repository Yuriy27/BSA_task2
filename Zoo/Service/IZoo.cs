using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zoo.Animals;

namespace Zoo.Service
{
    interface IZoo
    {
        void Add(Animal animal);

        void Feed(string name);

        void Heal(string name);

        void Delete(string name);

        bool Exist(string name);
    }
}
