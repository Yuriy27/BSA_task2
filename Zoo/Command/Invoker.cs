using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Command
{
    class Invoker
    {
        private ICommand _command;

        public Invoker(ICommand command)
        {
            _command = command;
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void Run()
        {
            _command.Execute();
        }
    }
}
