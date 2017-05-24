using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo.Repository
{
    interface IAnimalRepository
    {
        bool Exist(string name);

        Animal Find(string name);

        IEnumerable<Animal> FindAll();

        Animal Save(Animal animal);

        Animal Update(Animal animal);

        Animal GetRandom();

        Animal Remove(string name);
    }
}
