using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGames.Data.Interface
{
    internal interface IPlayerData
    {
       
        string Name { get; }
        int NGames { get; }

     

        void Update(int guesses);
        double Average();

        bool Equals(Object p);
        int GetHashCode();
       

    }
}
