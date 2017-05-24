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
    }
}
