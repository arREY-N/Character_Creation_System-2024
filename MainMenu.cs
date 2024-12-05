using System;
using System.Reflection;

namespace CharacterCreationSystem
{
    public class Menus
    {
        public static void Main(string[] args)
        {
            try
            {
                Dictionaries.CreateDataMaps();
                SQLConnection.AddToLocalDatabase();
                MainMenu();
            } catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}\n");
            }
        }

        public static void MainMenu()
        { 
            int VAction = 0;

            while (true)
            {
                Console.WriteLine("SeaPAG: Sea Pirate Adventure Game\n");

                Console.WriteLine("| 1  | New Game");
                Console.WriteLine("| 2  | Load Game");
                Console.WriteLine("| 3  | Campaign Mode");
                Console.WriteLine("| 4  | Credits");
                Console.WriteLine("| 5  | Exit");

                try
                {
                    VAction = Utility.Validate(Utility.GetInput("Action"), 1);

                    switch (VAction)
                    {
                        case 1:
                            object[] informationArray = Character.SetCharacter();
                            Character.ConfirmChoices(informationArray);
                            break;
                        case 2:
                            Console.WriteLine();
                            LoadGame();
                            break;
                        case 3:
                            Console.WriteLine();
                            CampaignMode();
                            break;
                        case 4:
                            Credits();
                            break;
                        case 5:
                            Console.WriteLine("Thank you! Goodbye!");
                            Environment.Exit(0);
                            break;
                        default:
                            throw new OptionUnavailableException($":::::{VAction} is not in the options!:::::");
                    }
                }
                catch (Exception e) when (e is FormatException || e is OptionUnavailableException)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
        }

        public static void LoadGame()
        {
            int VAction = 0;
            bool load = true;
            Pirate pirate;

            while (load)
            {
                Console.WriteLine("Load Game Menu\n");

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
                                pirate = DictionaryDisplay.GetPirateFromList();
                                CharacterDisplay.ShowStats(pirate);
                                Utility.EnterToContinue();
                            }
                            catch (DatabaseEmptyException e)
                            {
                                Console.WriteLine($"\n{e.Message}\n");
                            }

                            break;
                        case 2:
                            try
                            {
                                pirate = DictionaryDisplay.GetPirateFromList();
                                CharacterDisplay.ShowStats(pirate);
                                Utility.EnterToContinue();
                                Database.RemoveFromDatabase(pirate);
                                Console.WriteLine("\n:::::Pirate removed from database successfully!:::::");
                            }
                            catch (DatabaseEmptyException e)
                            {
                                Console.WriteLine($"\n{e.Message}\n");
                            }
                            break;
                        case 3:
                            Console.Clear();
                            load = false;
                            break;
                        default:
                            throw new OptionUnavailableException($":::::{VAction} is not in the options!:::::");
                    }
                }
                catch (Exception e) when (e is FormatException || e is OptionUnavailableException)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
        }

        public static void CampaignMode()
        {
            
        }

        public static void Credits()
        {
            Utility.EnterToContinue();
            
        }
    }
}