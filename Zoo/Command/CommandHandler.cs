﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zoo.Service;
using Zoo.Exceptions;
using Zoo.Animals;

namespace Zoo.Command
{
    class CommandHandler
    {
        
        private IZoo _zoo;

        private string _command;

        public CommandHandler(string command, IZoo zoo)
        {
            _command = command;
            _zoo = zoo;
        }

        public void Handle()
        {
            var tokens = _command.Trim().Split(' ');
            var comm = tokens[0];
            try
            {
                switch (comm)
                {
                    case "exit": Exit(); break;
                    case "clr": Clear(); break;
                    case "add": AddAnimal(tokens); break;
                    case "feed": FeedAnimal(tokens); break;
                    case "heal": HealAnimal(tokens); break;
                    case "delete": DeleteAnimal(tokens); break;
                    case "info": ShowInfo(tokens); break;
                    case "all": ShowAll(tokens); break;
                    case "linq_help": ShowLinqHelp(); break;
                    case "linq": ShowLinq(tokens); break;
                    default: throw new CommandNotFoundException();
                }
            }
            catch (CommandNotFoundException e)
            {
                Console.WriteLine("command '{0}' not found", comm);
            }
            catch (BadParametersException e)
            {
                Console.WriteLine("wrong parameters for command '{0}'", comm);
            }
            catch (AnimalAlreadyExistException e)
            {
                Console.WriteLine("animal named '{0}' already exists", tokens[2]);
            }
            catch (BadAnimalTypeException e)
            {
                Console.WriteLine("There is no animal type named '{0}'", tokens[1]);
            }
            catch (AnimalRemoveException e)
            {
                Console.WriteLine("animal named '{0}' can not be removed", tokens[1]);
            }
            catch (AnimalNotFoundException e)
            {
                Console.WriteLine("animal named '{0}' not found", tokens[1]);
            }
        }

        private void ShowLinqHelp()
        {
            var linqHelp = "linq [number]\n"
                + "0 - show all animals grouped by type\n"
                + "1 - show animals by state\n"
                + "2 - show ill tigers\n"
                + "3 - show elephant by name\n"
                + "4 - show names of hungry animals\n"
                + "5 - show the most health animals (1 per type)\n"
                + "6 - show count of dead animals per type\n"
                + "7 - show wolfes and bears with health > 3\n"
                + "8 - show animal with min and max health\n"
                + "9 - show average animals health\n";

            Console.Write(linqHelp);
        }

        private void ShowLinq(string[] tokens)
        {
            if (tokens.Length < 2)
            {
                throw new BadParametersException();
            }
            try
            {
                new LinqHandler().Handle(tokens);
            }
            catch (BadParametersException e)
            {
                throw;
            }
        }

        private void ShowAll(string[] tokens)
        {
            foreach (var animal in _zoo.FindAll())
            {
                Console.WriteLine(animal);
            }
        }

        private void ShowInfo(string[] tokens)
        {
            if (tokens.Length != 2)
            {
                throw new BadParametersException();
            }
            if (!_zoo.Exist(tokens[1]))
                throw new AnimalNotFoundException();
            Console.WriteLine(_zoo.Find(tokens[1]));
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void Clear()
        {
            Console.Clear();
        }

        private void AddAnimal(string[] tokens)
        {
            if (tokens.Length != 3)
            {
                throw new BadParametersException();
            }
            var type = tokens[1];
            var name = tokens[2];
            Animal animal;
            try
            {
                animal = AnimalFactory.Create(type, name);
            }
            catch (BadAnimalTypeException e)
            {
                throw;
            }
            if (_zoo.Exist(animal.Name))
                throw new AnimalAlreadyExistException();
            _zoo.Add(animal);
            Console.WriteLine("created {0} named '{1}'", type, name);
        }

        private void FeedAnimal(string[] tokens)
        {
            if (tokens.Length != 2)
            {
                throw new BadParametersException();
            }
            var name = tokens[1];
            if (!_zoo.Exist(name))
                throw new AnimalNotFoundException();
            _zoo.Feed(name);
            Console.WriteLine("animal '{0}' was feeded", name);
        }

        private void HealAnimal(string[] tokens)
        {
            if (tokens.Length != 2)
            {
                throw new BadParametersException();
            }
            var name = tokens[1];
            if (!_zoo.Exist(name))
                throw new AnimalNotFoundException();
            _zoo.Heal(name);
            Console.WriteLine("animal '{0}' was healed", name);
        }

        private void DeleteAnimal(string[] tokens)
        {
            if (tokens.Length != 2)
            {
                throw new BadParametersException();
            }
            var name = tokens[1];
            if (!_zoo.Exist(name))
                throw new AnimalNotFoundException();
            try
            {
                _zoo.Delete(name);
            }
            catch (AnimalRemoveException e)
            {
                throw;
            }
            Console.WriteLine("animal '{0}' was deleted", name);
        }
    }
}
