﻿using MooGames.Menu.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MooGames.Menu.Classes.Common
{
    public class ConsoleUserinterface : IUserInterface
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public string Read()
        {
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }
    }
}
