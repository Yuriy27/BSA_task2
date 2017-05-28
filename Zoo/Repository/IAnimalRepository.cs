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

        //linq

        IEnumerable<IGrouping<string, Animal>> FindAllGroupByType();

        IEnumerable<Animal> FindAllByState(string state);

        IEnumerable<Animal> FindIllTigers();

        Animal FindElephantByName(string name);

        IEnumerable<string> FindNamesOfHungryAnimals();

        IEnumerable<Animal> FindTheMostHealthyAnimals();

        IEnumerable<(string, int)> FindCountOfDeadAnimals();

        IEnumerable<Animal> FindWolfsAndBears(int health);

        (Animal, Animal) FindMinMaxHealthAnimals();

        double AverageHealth();

    }
}
