using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Classes
{
    internal class GameNumberGenerator
    {
        public string GenerateGameNumber()
        {
            var randomGenerator = new Random();

            string correctGameNumber =
                Enumerable.Range(0, 10)
                .OrderBy(x => randomGenerator.Next())
                .Take(4)
                .Aggregate("", (current, number) => current + number.ToString());
            
            return correctGameNumber;
        }
    }
}
