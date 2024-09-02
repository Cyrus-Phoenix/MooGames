using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MooGames.Menu.Classes.Common
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


        // ************ Game ************
        public static string NewGameMessage { get; } = "New game started!\n";
        public static string EnterGuessMessage { get; } = "Please enter your guess or enter letter 'Q' to quit and lose all progress made this round.";
        public static string InvalidGuessMessage { get; } = "Invalid guess. Please enter a 4-digit number with no repeating digits.";
        public static string InvalidReplayChoiceMessage { get; } = "Invalid choice!";
        public static string ReplayChoiceMessage { get; } = "\nDo you want to play again? (Y/N)";
        public static string EnterNameMessage { get; } = "Please enter your name:";
        public static string GameOverMessage { get; } = "Game Over!";
        public static string GameWonMessage { get; } = "Congratulations! You won the game!";
        public static string QuitGame { get; } = "Q";
        public static string Divider { get; } = "---------------------------------";
        public static string GameRules { get; } = @" 
                                                Game Rules
                                                1. The computer will generate a 4-digit number with no repeating digits.
                                                2. You will have to guess the number.
                                                3. The computer will give you feedback on your guess.
                                                   The feedback will be in the form of 'B' and 'C'.
                                                   'B' means that you have a correct digit in the correct position.
                                                   'C' means that you have a correct digit in the wrong position.
                                                4. If you want to quit the game, enter 'Q'.
                                                5. Good luck!";
                                              


        // ************ Menu ************
        public static string Menu { get; } = $@"
                                                Meny 
                                                1 = MooGame
                                                2 = MooGame Rules
                                                3 = MooGame Highscore
                                                4 = Game not released yet
                                                Q = Quit";
        public static string MenuChoiceMessage { get; } = "\nPlease enter your choice: ";
        public static string MenuChoice1 { get; } = "1";
        public static string MenuChoice2 { get; } = "2";
        public static string MenuChoice3 { get; } = "3";
        public static string MenuChoice4 { get; } = "4";
        public static string MenuChoice5 { get; } = "5";
        public static string QuitApplication { get; } = "Q";
        public static string GameNotReleaseYet { get; } = "Game is not released yet, pick something else!";
        public static string InvalidChoiceMessage { get; } = "Invalid choice. Please enter a valid choice.";
        public static string ThankYouForPlayingMessage { get; } = "Thank you for playing!";

        
        

    }
}