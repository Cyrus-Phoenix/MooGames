using MooGames.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGames.Business.Classes.Common
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
