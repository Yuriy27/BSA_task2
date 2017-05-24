using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zoo.Animals;
using Zoo.Repository;

namespace Zoo.Time
{
    class ZooTimer
    {
        public const int frequency = 5000;

        private IAnimalRepository _rep = AnimalRepository.Instance;

        private Timer _timer;

        public bool IsEnd()
        {
            return _timer == null;
        }

        public void Start()
        {
            var callBack = new TimerCallback(DoChanges);
            _timer = new Timer(callBack, null, 0, frequency);
        }

        private void DoChanges(object obj)
        {
            Animal randomAnimal = _rep.GetRandom();          
            if (randomAnimal != null)
            {
                int state = (int)(randomAnimal.State);
                if (state < 2)
                {
                    randomAnimal.State++;
                }
                else if (randomAnimal.State == AnimalState.Ill && randomAnimal.Health-- == 0)
                {
                    randomAnimal.State = AnimalState.Dead;
                }
                _rep.Save(randomAnimal);
                if (randomAnimal.State == AnimalState.Dead)
                {
                    if (IsAllDead())
                    {
                        _timer.Dispose();
                        _timer = null;
                        Console.WriteLine("all animals are dead");
                    }
                }
            }
        }

        private bool IsAllDead()
        {
            foreach (var animal in _rep.FindAll())
            {
                if (animal.State != AnimalState.Dead)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
