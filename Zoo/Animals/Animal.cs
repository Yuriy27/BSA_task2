using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    enum AnimalState
    {
        Full, Hungry, Ill, Dead
    }

    abstract class Animal
    {
        public string Name { get; private set; }

        public int Health { get; set; }

        public AnimalState State { get; set; }

        public Animal(string name)
        {
            Name = name;
            Health = GetMaxHealth();
        }

        public abstract int GetMaxHealth();

        public abstract string GetAnimalType();

        public override string ToString()
        {
            return "-----------\n"
                + $"Name: {Name}\n"
                + $"Health: {Health}\n"
                + $"State: {State.ToString()}\n"
                + $"Type: {GetAnimalType()}\n"
                + "-----------";
        }
    }
}
