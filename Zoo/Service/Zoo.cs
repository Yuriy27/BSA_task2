using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;
using Zoo.Repository;
using Zoo.Exceptions;

namespace Zoo.Service
{
    class Zoo : IZoo
    {
        private IAnimalRepository _rep = AnimalRepository.Instance;

        public void Add(Animal animal)
        {
            _rep.Save(animal);
        }

        public void Delete(string name)
        {
            var animal = _rep.Find(name);
            if (animal != null && animal.State == AnimalState.Dead)
            {
                _rep.Remove(name);
            }
            else
            {
                throw new AnimalRemoveException();
            }
        }

        public void Feed(string name)
        {
            var animal = _rep.Find(name);
            if (animal != null)
            {
                animal.State = AnimalState.Full;
                _rep.Save(animal);
            }
        }

        public void Heal(string name)
        {
            var animal = _rep.Find(name);
            if (animal != null)
            {
                animal.Health = Math.Min(animal.Health + 1, animal.GetMaxHealth());
            }
        }

        public bool Exist(string name)
        {
            return _rep.Exist(name);
        }

        public Animal Find(string name)
        {
            return _rep.Find(name);
        }

        public IEnumerable<Animal> FindAll()
        {
            return _rep.FindAll();
        }

    }
}
