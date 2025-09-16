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

        static StringCollection ToolNames = new StringCollection();
        static String[] ToolNamesArr = new String[] {"dart", "knife", "screwdriver", "axe", "hammer", "1", "2", "3", "4", "5"};

        enum ToolType
        {
            Dart,
            Knife,
            Screwdriver,
            Axe,
            Hammer
        }

        static Random AccuracyRnD = new Random();
        static Random ScoreRnD = new Random();

        static void ShowHUD()
        {
            Console.WriteLine("{0,0}{1,20}{2,20}{3,20}", $"Score: {ScoreHUD}", $"Accuracy: {Accuracy}", $"Tool: {ToolName}", $"Times Played: {PlayTimes}");
        }

        static void PressAny()
        {
            Console.WriteLine("\nPress Any Key...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ChooseYourTool()
        {
            Console.WriteLine($"\nChoose Your Tool: Dart(1), Knife(2), Screwdriver(3), Axe(4), Hammer(5)");
            Console.WriteLine("\nType Your Answer (Number, or Name)...");
        }

        static void ToolChoice()
        {
            PlayerInput = Console.ReadLine();

            if (PlayerInput == "1" || PlayerInput.Equals("Dart", StringComparison.OrdinalIgnoreCase))
            {
                ToolName = "Dart";
                Accuracy = AccuracyRnD.Next(0, 100);
                if(Accuracy >= 15)
                {
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
                Accuracy = AccuracyRnD.Next(0, 100);
                if (Accuracy >= 35)
                {
                    ScoreHUD += ScoreRnD.Next(0, 65);
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
                Accuracy = AccuracyRnD.Next(0, 100);
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
                Accuracy = AccuracyRnD.Next(0, 100);
                if (Accuracy >= 75)
                {
                    ScoreHUD += ScoreRnD.Next(0, 25);
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
                Accuracy = AccuracyRnD.Next(0, 100);
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
            PlayerInput = PlayerInput.ToLower();
            if (ToolNames.Contains(PlayerInput))
            {
                Console.Clear();
                PlayTimes += 1;
                ShowHUD();
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Dart Game";
            ToolNames.AddRange(ToolNamesArr);

            Play();
            Play();
            Play();

            PlayAgain();
        }

    }
}
