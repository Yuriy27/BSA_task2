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

        IEnumerable<Animal> FindAllGroupByType(string type);

        IEnumerable<Animal> FindAllByState(AnimalState state);

        IEnumerable<Animal> FindIllTigers();

        Animal FindElephantByName(string name);

        IEnumerable<string> FindNamesOfHungryAnimals();

        IEnumerable<Animal> FindTheMostHealthyAnimals();

        IEnumerable<Animal> FindCountOfDeadAnimals();

        /// <summary>
        /// Find wolfs and bears with health more than 3
        /// </summary>
        /// <returns></returns>
        IEnumerable<Animal> FindWolfsAndBears();

        IEnumerable<Animal> FindMinMaxHealthAnimals();

        double AverageHealth();

    }
}
