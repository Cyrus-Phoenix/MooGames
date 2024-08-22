using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGames.Menu.Interfaces
{
    public interface IUserInterface
    {
        void Write(string message);

        string Read();
    }
}
