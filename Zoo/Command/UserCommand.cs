using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Command
{
    class UserCommand : ICommand
    {
        private CommandHandler _handler;

        public UserCommand(CommandHandler handler)
        {
            _handler = handler;
        }

        public void Execute()
        {
            _handler.Handle();
        }
    }
}
