using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGames.Business.Classes.Common
{
    public class Messages
    {
        // Anledning till detta är att få bort alla magic strings och göra det enklare att ändra i framtiden
        public static string WelcomeMessage { get; } = $@"
                    ██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗ 
                    ██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗
                    ██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║
                    ██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║
                    ╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝
                     ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝ 
                                                                                    
                    ███╗   ███╗ ██████╗  ██████╗      ██████╗  █████╗ ███╗   ███╗███████╗███████╗       
                    ████╗ ████║██╔═══██╗██╔═══██╗    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝██╔════╝       
                    ██╔████╔██║██║   ██║██║   ██║    ██║  ███╗███████║██╔████╔██║█████╗  ███████╗       
                    ██║╚██╔╝██║██║   ██║██║   ██║    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ╚════██║       
                    ██║ ╚═╝ ██║╚██████╔╝╚██████╔╝    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗███████║       
                    ╚═╝     ╚═╝ ╚═════╝  ╚═════╝      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝╚══════╝                                                
         ";

        public static string GameOverMessage { get; } = "Game Over!";
        public static string GameWonMessage { get; } = "Congratulations! You won the game!";

        public static string InvalidGuessMessage { get; } = "Invalid guess. Please enter a 4-digit number with no repeating digits.";
        public static string EnterUserNameMessage { get; } = "Please enter your name:\n";
        public static string EnterGuessMessage { get; } = "Please enter your guess:\n (Q = quit)\n";
        public static string NewGameMessage { get; } = "New game started!\n";

        public static string Menu { get; } = $@"
                                                Meny 
                                                1 = MooGames
                                                5 = Topplista
                                                Anykey except for 1 and 5 = Quit";
        public static string MenuChoiceMessage { get; } = "\n Please enter your choice: ";
        public static string MenuChoice1 { get; } = "1";
        public static string MenuChoice5 { get; } = "5";

        public static string ThankYouForPlayingMessage { get; } = "Thank you for playing!";

    }
}