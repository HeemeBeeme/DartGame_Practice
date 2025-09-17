using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCode
{
    internal class Program
    {
        static int ScoreHUD = 0;

        static int Accuracy;
        static int PlayTimes = 0;

        static string ToolName = "None";
        static string PlayerInput;
        static string ThrowStatus;

        //creates a string collection
        static StringCollection ToolNames = new StringCollection();

        //creates a string array                       //all the stuff in the array
        static String[] ToolNamesArr = new String[] {"dart", "knife", "screwdriver", "axe", "hammer", "1", "2", "3", "4", "5"};

        enum ToolType
        {
            Dart,
            Knife,
            Screwdriver,
            Axe,
            Hammer
        }

        //creates var for random int
        static Random AccuracyRnD = new Random();
        static Random ScoreRnD = new Random();


        //shows the HUD
        static void ShowHUD()
        {
            //composite formatting (first number is the string, second number is the space between)
            Console.WriteLine("{0,0}{1,20}{2,20}{3,20}", $"Score: {ScoreHUD}", $"Accuracy: {Accuracy}", $"Tool: {ToolName}", $"Times Played: {PlayTimes}");
        }

        //basic press any key setup
        static void PressAny()
        {
            Console.WriteLine("\nPress Any Key...");
            Console.ReadKey();
            Console.Clear();
        }

        //shows the tool options (\n moves the line down)
        static void ChooseYourTool()
        {
            Console.Write($"\nChoose Your Tool: ");
            Console.Write("{0,5}{1,10}{2,16}{3,8}{4,11}", "Dart(1)", "Knife(2)", "Screwdriver(3)", "Axe(4)", "Hammer(5)");
            Console.Write("\n{0,18}{1,7}{2,10}{3,16}{4,8}{5,11}", "Throwing Accuracy:", "85%", "65%", "50%", "25%", "15%");
            Console.Write("\n\nType Your Answer (Number, or Name): ");
        }

        //generates all the random variables and sets text
        static void ToolChoice()
        {
            //takes PlayerInput and makes it equal to what the player types in the console
            PlayerInput = Console.ReadLine();

            // the "||" means or, StringComparison.OrdinalIgnoreCase tells the console to be case insensitive to the PlayerInput variable
            if (PlayerInput == "1" || PlayerInput.Equals("Dart", StringComparison.OrdinalIgnoreCase))
            {
                ToolName = "Dart";

                //sets the Accuracy variable to the AccuracyRnD value (.Next(0, 100) makes the AccuracyRnD generate a number between 0, 100 (min, max))
                Accuracy = 100 - AccuracyRnD.Next(0, 100);
                if(Accuracy >= 15)
                {
                    //same with the Accuracy variable, just for score
                    ScoreHUD += ScoreRnD.Next(0, 15);
                    ThrowStatus = "Hit!";
                }
                else
                {
                    ThrowStatus = "Missed!";
                }
            }
            else if(PlayerInput == "2" || PlayerInput.Equals("Knife", StringComparison.OrdinalIgnoreCase))
            {
                ToolName = "Knife";
                Accuracy = 100 - AccuracyRnD.Next(0, 100);
                if (Accuracy >= 35)
                {
                    ScoreHUD += ScoreRnD.Next(0, 35);
                    ThrowStatus = "Hit!";
                }
                else
                {
                    ThrowStatus = "Missed!";
                }
            }
            else if(PlayerInput == "3" || PlayerInput.Equals("Screwdriver", StringComparison.OrdinalIgnoreCase))
            {
                ToolName = "Screwdriver";
                Accuracy = 100 - AccuracyRnD.Next(0, 100);
                if (Accuracy >= 50)
                {
                    ScoreHUD += ScoreRnD.Next(0, 50);
                    ThrowStatus = "Hit!";
                }
                else
                {
                    ThrowStatus = "Missed!";
                }
            }
            else if(PlayerInput == "4" || PlayerInput.Equals("Axe", StringComparison.OrdinalIgnoreCase))
            {
                ToolName = "Axe";
                Accuracy = 100 - AccuracyRnD.Next(0, 100);
                if (Accuracy >= 75)
                {
                    ScoreHUD += ScoreRnD.Next(0, 75);
                    ThrowStatus = "Hit!";
                }
                else
                {
                    ThrowStatus = "Missed!";
                }
            }
            else if(PlayerInput == "5" || PlayerInput.Equals("Hammer", StringComparison.OrdinalIgnoreCase))
            {
                ToolName = "Hammer";
                Accuracy = 100 - AccuracyRnD.Next(0, 100);
                if (Accuracy >= 85)
                {
                    ScoreHUD += ScoreRnD.Next(0, 85);
                    ThrowStatus = "Hit!";
                }
                else
                {
                    ThrowStatus = "Missed!";
                }
            }
        }

        static void ToolThrown()
        {
            //sets PlayerInput to all lowercase
            PlayerInput = PlayerInput.ToLower();
            if (ToolNames.Contains(PlayerInput))
            {
                Console.Clear();
                PlayTimes += 1;
                ShowHUD();
                //the $"" allows you to add variables into the string with {} without having to make it really ugly
                Console.WriteLine($"\nYou threw your {ToolName}, and {ThrowStatus}");
                Console.WriteLine($"\nYour Score is now: {ScoreHUD}");
                PressAny();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\nYour Choice \"{PlayerInput}\" Was Not Found...");
                PressAny();
                Play();
            }
        }

        static void PlayAgain()
        {
            Console.WriteLine("Would You Like To Continue Playing?");
            Console.WriteLine("\nYes or No");

            PlayerInput = Console.ReadLine();

            if (PlayerInput.Equals("Y", StringComparison.OrdinalIgnoreCase) || PlayerInput.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                Play();
                Play();
                Play();

                PlayAgain();
            }
            else if (PlayerInput.Equals("N", StringComparison.OrdinalIgnoreCase) || PlayerInput.Equals("No", StringComparison.OrdinalIgnoreCase))
            {
                //stop all code from executing and ends the program (closes on key press)
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Answer Not Applicable, Please Try Again");
                PressAny();
                PlayAgain();
            }

            Console.Clear();

        }

        static void Play()
        {
            Console.Clear();
            ShowHUD();
            ChooseYourTool();
            ToolChoice();

            ShowHUD();
            ToolThrown();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            //sets the text on screen to white (or any other given colour)
            Console.ForegroundColor = ConsoleColor.White;
            //sets the console tab name to the given string
            Console.Title = "Dart Game";
            //adds all the strings in the string array ToolNamesArr into the StringCollection
            ToolNames.AddRange(ToolNamesArr);

            Play();
            Play();
            Play();

            PlayAgain();
        }

    }
}
