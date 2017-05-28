using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zoo.Exceptions;
using Zoo.Repository;

namespace Zoo.Command
{
    class LinqHandler
    {
        private readonly IAnimalRepository _rep = AnimalRepository.Instance;

        public void Handle(string[] tokens)
        {
            int num;
            try
            {
                num = Convert.ToInt32(tokens[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("second param should be a number");
                return;
            }
            switch (num)
            {
                case 0: ShowAllGroupByType(); break;//
                case 1: ShowAllByState(tokens); break;//
                case 2: ShowIllTigers(); break;//
                case 3: ShowElephantByName(tokens); break;//
                case 4: ShowNamesOfHungryAnimals(); break;//
                case 5: ShowTheMostHealthyAnimals(); break;//
                case 6: ShowCountOfDeadAnimals(); break;//
                case 7: ShowWolfsAndBears(); break;//
                case 8: ShowMinMaxHealthAnimals(); break;//
                case 9: ShowAverageHealth(); break;//
            }
        }

        private void ShowAllGroupByType()
        {
            foreach (var item in _rep.FindAllGroupByType())
            {
                Console.WriteLine($"type: {item.Key}");
                foreach (var anim in item)
                {
                    Console.WriteLine(anim);
                }
            }
        }
        private void ShowAllByState(string[] tokens)
        {
            if (tokens.Length != 3)
            {
                throw new BadParametersException();
            }
            string state = tokens[2];
            foreach (var anim in _rep.FindAllByState(state))
            {
                Console.WriteLine(anim);
            }
        }
        private void ShowIllTigers()
        {
            foreach (var tiger in _rep.FindIllTigers())
            {
                Console.WriteLine(tiger);
            }
        }
        private void ShowElephantByName(string[] tokens)
        {
            if (tokens.Length != 3)
            {
                throw new BadParametersException();
            }
            string name = tokens[2];
            Console.WriteLine(_rep.FindElephantByName(name));
        }
        private void ShowNamesOfHungryAnimals()
        {
            foreach (var anim in _rep.FindNamesOfHungryAnimals())
            {
                Console.WriteLine(anim);
            }
        }
        private void ShowTheMostHealthyAnimals()
        {
            foreach (var anim in _rep.FindTheMostHealthyAnimals())
            {
                Console.WriteLine(anim);
            }
        }
        private void ShowCountOfDeadAnimals()
        {
            foreach (var item in _rep.FindCountOfDeadAnimals())
            {
                Console.WriteLine($"type: {item.Item1}; dead: {item.Item2}");
            }
        }
        private void ShowWolfsAndBears()
        {
            foreach (var anim in _rep.FindWolfsAndBears(3))
            {
                Console.WriteLine(anim);
            }
        }
        private void ShowMinMaxHealthAnimals()
        {
            try
            {
                var item = _rep.FindMinMaxHealthAnimals();
                Console.WriteLine($"MIN:\n{item.Item1}");
                Console.WriteLine($"MAX:\n{item.Item2}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("There is no animals");
            }
        }
        private void ShowAverageHealth()
        {
            try
            {
                Console.WriteLine($"Average health: {_rep.AverageHealth()}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("There is no animals");
            }
        }
    }
}
