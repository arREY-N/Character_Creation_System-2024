using System;
using System.Reflection;

namespace CharacterCreationSystem
{
    public class Menus
    {
        public static void Main(string[] args)
        {
            Dictionaries.CreateDataMaps();
            MainMenu();

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
                            object[] informationArray = SetCharacter();
                            ConfirmChoices(informationArray);
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

        public static object[] SetCharacter()
        {
            object[] informationArray = new object[
                Dictionaries.CharacterInfoTitles.GetLength(0) +
                Dictionaries.CharacterWeaponsTitles.GetLength(0) +
                Dictionaries.CharacterTraitTitles.GetLength(0)
            ];

            Console.WriteLine("\n>>>>> CREATE YOUR PIRATE <<<<<\n");
            
            int infoIndex = 0;

            foreach (object[,] infoArray in Dictionaries.dictionaries)
            {
                for (int i = 0; i < infoArray.GetLength(0); i++)
                {
                    Dictionary<int, Element> dictionary = Utility.DisplayInformation(infoArray, i);

                    while (true)
                    {
                        try
                        {
                            if (dictionary != null)
                            {
                                int VAction = Utility.Validate(Console.ReadLine() ?? String.Empty, 1);
                                informationArray[infoIndex] = Utility.GetElement(dictionary, VAction);
                                break;
                            }
                            else
                            {
                                informationArray[infoIndex] = Utility.Validate(Console.ReadLine() ?? String.Empty, ' ');
                                break;
                            }
                        }
                        catch (Exception e) when (e is FormatException || e is OptionUnavailableException)
                        {
                            Console.WriteLine($"\n{e.Message}\n");
                            Console.Write($"{Convert.ToString(infoArray[i, 0])}: ");
                        }
                    };
                    infoIndex++;
                    Console.WriteLine();
                }
            }
            return informationArray;
        }

        public static void ConfirmChoices(object[] informationArray)
        {
            bool edit = true;
            Pirate pirate;
            while (edit)
            {
                Utility.DisplayChoices(Dictionaries.dictionaries, informationArray);

                Console.WriteLine("\nSave character details?");
                Console.WriteLine("| 1  | Save");
                Console.WriteLine("| 2  | Edit");
                Console.WriteLine("| 3  | Main Menu");

                try
                {
                    int VAction = Utility.Validate(Utility.GetInput("Action"), 1);
                    switch (VAction)
                    {
                        case 1:
                            pirate = Utility.CreateCharacter(informationArray);
                            edit = false;
                            Database.AddToDatabase(pirate);
                            Console.WriteLine("\n:::::Character Creation Successful!:::::"); 
                            Utility.ShowPirate(pirate);
                            Utility.ShowStats(pirate);
                            Utility.EnterToContinue();
                            break;
                        case 2:
                            Console.WriteLine("\n >>>>> EDITING CHARACTER! <<<<<\n");
                            pirate = Utility.CreateCharacter(EditChoice(informationArray));
                            
                            break;
                        case 3:
                            edit = false;
                            break;
                        default:
                            throw new OptionUnavailableException($":::::{VAction} is not in the options!:::::");
                    }
                }
                catch (OptionUnavailableException e)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
        }

        public static object[] EditChoice(object[] informationArray)
        {
            Dictionaries myDictionaries = new Dictionaries();
            PropertyInfo[] properties = myDictionaries.GetType().GetProperties();
            
            Utility.DisplayChoices(Dictionaries.dictionaries, informationArray);

            while (true)
            {
                try
                {
                    int VAction = Utility.Validate(Utility.GetInput("Edit Trait"), 1);
                    Console.WriteLine();
                    if (VAction == 1)
                    {
                        string newChoice = Utility.Validate(Utility.GetInput("Enter New Trait"), ' ');
                        informationArray[VAction - 1] = newChoice;
                    } 
                    else if(VAction > 1 && VAction < properties.Length + 2)
                    {
                        Dictionary<int, Element> dictionary = (Dictionary<int, Element>) properties[VAction - 2].GetValue(myDictionaries);

                        Utility.DisplayDictionary(dictionary);
                        int newChoice = Utility.Validate(Utility.GetInput("Enter New Trait"), 1);

                        Element element = Utility.GetElement(dictionary, newChoice);
                        informationArray[VAction - 1] = element;
                    }
                    else
                    {
                        throw new OptionUnavailableException($":::::{VAction} is not in the options!:::::");
                    }
                    
                    break;
                }
                catch (Exception e) when (e is FormatException || e is OptionUnavailableException)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
            Console.WriteLine();
            return informationArray; 
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
                                pirate = Utility.GetPirateFromList();
                                Utility.ShowStats(pirate);
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
                                pirate = Utility.GetPirateFromList();
                                Utility.ShowStats(pirate);
                                Database.RemoveFromDatabase(pirate);
                                Console.WriteLine("\n:::::Pirate removed from database successfully!:::::");
                                Utility.EnterToContinue();
                            }
                            catch (DatabaseEmptyException e)
                            {
                                Console.WriteLine($"\n{e.Message}\n");
                            }
                            break;
                        case 3:
                            load = false;
                            ;
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
            Console.WriteLine();
        }

        public static void CampaignMode()
        {
            
        }

        public static void Credits()
        {
            
            
        }
    }
}