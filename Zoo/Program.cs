using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zoo.Animals;
using Zoo.Repository;
using Zoo.Service;
using Zoo.Command;
using Zoo.Time;

namespace Zoo
{
    class Program
    {
        static string help = "commands:\n"
            + "------------------------\n"
            + "add [type] [name]\n"
            + "feed [name]\n"
            + "heal [name]\n"
            + "delete [name]\n"
            + "exit\n"
            + "clr\n"
            + "------------------------";

        static void Main(string[] args)
        {
            IZoo zoo = new Service.Zoo();
            ZooTimer timer = new ZooTimer();
            timer.Start();
            Console.WriteLine(help);
            while (true) 
            {
                Console.Write("command> ");
                string input = Console.ReadLine().ToLower();
                var handler = new CommandHandler(input, zoo);
                var command = new UserCommand(handler);
                var invoker = new Invoker(command);
                if (!timer.IsEnd())
                {
                    invoker.Run();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
