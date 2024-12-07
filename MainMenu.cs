using System;
using System.Reflection;
using static System.Collections.Specialized.BitVector32;

namespace CharacterCreationSystem
{
    public class Menus
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                Utility.DisplayHeader("GAME LOADING");

                Thread thread1 = new Thread(() => Dictionaries.CreateDataMaps());
                Thread thread2 = new Thread(() => SQLConnection.AddToLocalDatabase());

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();

                Thread.Sleep(10);
                MainMenu();
            } 
            catch (Exception e)
            {
                Utility.DisplayErrorMessage(e.Message);
            }
        }
        public static void MainMenu()
        {
            Console.Clear();
            int VAction = 0;

            while (true)
            {
                Utility.DisplayHeader("MAIN MENU");
                Console.WriteLine("| 1  | New Game");
                Console.WriteLine("| 2  | Load Game");
                Console.WriteLine("| 3  | Campaign Mode");
                Console.WriteLine("| 4  | Credits");
                Console.WriteLine("| 5  | Exit");

                try
                {
                    VAction = Utility.Validate(Utility.GetInput("Action"), 1);
                    Utility.Loading();
                    switch (VAction)
                    {
                        case 1:
                            
                            NewGame();
                            break;
                        case 2:
                            LoadGame();
                            break;
                        case 3:
                            CampaignMode();
                            break;
                        case 4:
                            Credits();
                            break;
                        case 5:
                            if (Exit() == true)
                            {
                                Utility.DisplayHeader("See ya later!");
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.Clear();
                                Utility.Loading();
                            }
                            break;
                        default:
                            throw new OptionUnavailableException($"{VAction} is not in the options!");
                    }
                }
                catch (Exception e) when (e is FormatException || e is OptionUnavailableException)
                {
                    Utility.DisplayErrorMessage(e.Message);
                }
            }
        }

        

        public static void NewGame()
        {
            Utility.DisplayHeader("NEW GAME");
            object[] informationArray = Character.SetCharacter();
            Character.ConfirmChoices(informationArray);
        }

        public static void LoadGame()
        {
            int VAction = 0;
            bool load = true;
            Pirate pirate;

            while (load)
            {
                Utility.DisplayHeader("LOAD GAME");
                Console.WriteLine("| 1  | View Characters");
                Console.WriteLine("| 2  | Delete Character");
                Console.WriteLine("| 3  | Main Menu");

                try
                {
                    VAction = Utility.Validate(Utility.GetInput("Action"), 1);

                    switch (VAction)
                    {
                        case 1:
                            try
                            {
                                Utility.DisplayHeader("VIEW CHARACTERS");
                                pirate = DictionaryDisplay.GetPirateFromList();
                                CharacterDisplay.ShowStats(pirate);
                                Utility.EnterToContinue();
                            }
                            catch (DatabaseEmptyException e)
                            {
                                Utility.DisplayErrorMessage(e.Message);
                            }

                            break;
                        case 2:
                            try
                            {
                                pirate = DictionaryDisplay.GetPirateFromList();
                                CharacterDisplay.ShowStats(pirate);
                                Database.RemoveFromLocalDatabase(pirate);
                                SQLConnection.RemoveFromSQLDatabase(pirate);
                                Utility.DisplayHeader("Pirate removed from database successfully!");
                                Utility.EnterToContinue();
                            }
                            catch (DatabaseEmptyException e)
                            {
                                Utility.DisplayErrorMessage(e.Message);
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Utility.Loading();
                            
                            load = false;
                            break;
                        default:
                            throw new OptionUnavailableException($"{VAction} is not in the options!");
                    }
                }
                catch (Exception e) when (e is FormatException || e is OptionUnavailableException)
                {
                    Utility.DisplayErrorMessage(e.Message);
                }
            }
        }

        public static void CampaignMode()
        {
            Utility.DisplayHeader("CAMPAIGN MODE");
            foreach (string paragraph in GameInfo.gameStory)
            {
                
                char[] charParagraph = paragraph.ToCharArray();
                foreach(char characters in charParagraph)
                {
                    Console.Write(characters);
                    Thread.Sleep(10);
                }
                Console.WriteLine("\n");
            }
            Utility.EnterToContinue();
        }

        public static void Credits()
        {
            Utility.DisplayHeader("THE MA-SeaPAG TEAM");
            for (int i = 0; i < GameInfo.credits.GetLength(0); i++) 
            {
                for (int j = 0; j < GameInfo.credits.GetLength(1); j++) 
                {
                    string person = GameInfo.credits[i, j]; 
                    char[] charParagraph = person.ToCharArray();
                    Console.WriteLine();
                    foreach (char character in charParagraph)
                    {
                        Console.Write(character);
                        Thread.Sleep(10); 
                    }
                }
                Console.WriteLine();
            }
            Utility.EnterToContinue();
        }

        public static bool Exit()
        {
            while (true)
            {
                try
                {
                    Utility.DisplayHeader("EXIT GAME");
                    Console.WriteLine("| 1  | Confirm Exit");
                    Console.WriteLine("| 2  | Stay in the program");

                    int VAction = Utility.Validate(Utility.GetInput("Action"), 1);

                    return Utility.Confirm(VAction);
                }
                catch (Exception e) when (e is OptionUnavailableException || e is FormatException)
                {
                    Utility.DisplayErrorMessage(e.Message);
                }
            }
            
        }
    }
}