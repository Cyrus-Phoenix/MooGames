using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Classes
{
    internal class GameNumberGenerator
    {
        public string RandomGameNumber()
        {
            var randomGenerator = new Random();

            string correctGameNumber =
                Enumerable.Range(0, 10)
                .OrderBy(x => randomGenerator.Next())
                .Take(4)
                .Aggregate("", (current, number) => current + number.ToString());

            //string correctGameNumber = "";

            //for (int i = 0; i < 4; i++)
            //{
            //    int random = randomGenerator.Next(10);
            //    string randomDigit = "" + random;
            //    while (correctGameNumber.Contains(randomDigit))
            //    {
            //        random = randomGenerator.Next(10);
            //        randomDigit = "" + random;
            //    }
            //    correctGameNumber = correctGameNumber + randomDigit;
            //}

            return correctGameNumber;
        }
    }
}
