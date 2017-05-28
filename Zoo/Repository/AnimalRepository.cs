using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo.Repository
{
    sealed class AnimalRepository : IAnimalRepository
    {
        private static readonly Lazy<AnimalRepository> _instance = new Lazy<AnimalRepository>(() => new AnimalRepository());

        private ConcurrentDictionary<string, Animal> _animals;

        public static AnimalRepository Instance { get { return _instance.Value; } }

        private AnimalRepository()
        {
            _animals = new ConcurrentDictionary<string, Animal>();
        }

        public bool Exist(string name)
        {
            return _animals.ContainsKey(name);
        }

        public Animal Find(string name)
        {
            Animal animal;
            _animals.TryGetValue(name, out animal);
            return animal;
        }

        public IEnumerable<Animal> FindAll()
        {
            return _animals.Values;
        }

        public Animal Save(Animal animal)
        {
            _animals.TryAdd(animal.Name, animal);
            return animal;
        }

        public Animal Update(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Animal GetRandom()
        {
            var rnd = new Random();
            var keys = _animals.Keys;
            if (keys.Count == 0)
            {
                return null;
            }
            return _animals[keys.ElementAt(rnd.Next(keys.Count))];
        }

        public Animal Remove(string name)
        {
            Animal value;
            _animals.TryRemove(name, out value);
            return value;
        }

        //linq

        public IEnumerable<IGrouping<string, Animal>> FindAllGroupByType()
        {
            return FindAll().GroupBy(x => x.GetAnimalType(), x => x);
        }

        public IEnumerable<Animal> FindAllByState(string state)
        {
            return FindAll().Where(x => x.State.ToString().ToLower() == state);
        }

        public IEnumerable<Animal> FindIllTigers()
        {
            return FindAll().Where(t => t.GetAnimalType().Equals("tiger") && t.State == AnimalState.Ill);
        }

        public Animal FindElephantByName(string name)
        {
            return FindAll().Where(e => e.GetAnimalType().Equals("elephant") && e.Name.Equals(name)).SingleOrDefault();
        }

        public IEnumerable<string> FindNamesOfHungryAnimals()
        {
            return FindAll().Where(x => x.State == AnimalState.Hungry).Select(x => x.Name);
        }

        public IEnumerable<Animal> FindTheMostHealthyAnimals()
        {
            return FindAll().GroupBy(g => g.GetAnimalType()).Select(a => a.First(x => x.Health == x.GetMaxHealth()));
        }

        public IEnumerable<(string, int)> FindCountOfDeadAnimals()
        {
            return FindAll().GroupBy(g => g.GetAnimalType()).Select(a => (a.Key, a.Where(x => x.State == AnimalState.Dead).Count()));
        }

        public IEnumerable<Animal> FindWolfsAndBears(int health)
        {
            return FindAll().Where(x => (x.GetAnimalType().Equals("wolf") || x.GetAnimalType().Equals("bear")) && x.Health > health);
        }

        public (Animal, Animal) FindMinMaxHealthAnimals()
        {
            var all = FindAll();
            var maxmin = all.Where(x => x.Health == all.Min(t => t.Health) || x.Health == all.Max(t => t.Health))
            .OrderBy(x => x.Health);
            return (maxmin.First(), maxmin.Last());
        }

        public double AverageHealth()
        {
            return FindAll().Average(x => x.Health);
        }
    }
}
