using Microsoft.VisualBasic;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

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
                            LoadGame();
                            break;
                        case 3:
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
                            throw new OptionUnavailableException($"{VAction} is not in the options!");
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
                            Database.ViewDatabase();
                            pirate = Database.GetPirate(Utility.Validate(Utility.GetInput("Enter Pirate Number"), 1));
                            Utility.ShowPirate(pirate);

                            break;
                        case 2:
                            Database.ViewDatabase();
                            pirate = Database.GetPirate(Utility.Validate(Utility.GetInput("Enter Pirate Number"), 1));
                            Utility.ShowPirate(pirate);
                            Database.RemoveFromDatabase(pirate);
                            break;
                        case 3:
                            load = false;
                            break;
                        default:
                            throw new OptionUnavailableException($"{VAction} is not in the options!");
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

            Console.WriteLine("\nCREATE YOUR PIRATE\n");
            
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
                            Console.WriteLine("\nCharacter Creation Successful!\n");
                            Utility.ShowPirate(pirate);
                            break;
                        case 2:
                            Console.WriteLine("\nEDITING CHARACTER!\n");
                            pirate = Utility.CreateCharacter(EditChoice(informationArray));
                            break;
                        case 3:
                            edit = false;
                            break;
                        default:
                            throw new OptionUnavailableException($"{VAction} is not in the options!");
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
                        Console.WriteLine();
                        informationArray[VAction - 1] = element;
                    }
                    else
                    {
                        throw new OptionUnavailableException($"{VAction} is not in the options!");
                    }
                    
                    break;
                }
                catch (Exception e) when (e is FormatException || e is OptionUnavailableException)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
            return informationArray; 
        }

        public static void CampaignMode()
        {
            Console.WriteLine("In the treacherous waters of the Sea of Forgotten Legends where myths and curses collide, a new breed of pirates has emerged to claim the legacy of the fallen titans: Morgan Soulweaver, Darius Bloodbance, Selene Shapetide, Balthazar Goldflask, and Nysaa Riftwalker. These legendary figures once ruled the seas with unmatched power, their names etched into the annals of history. But ambition was their downfall. The remnants of their crews and their legendary ships are now the stuff of legend, scattered across the seas. Yet, their unfinished quests and the cursed treasures they sought still lie waiting, tempting new pirates to take up their mantle. ");
            Console.WriteLine("\nPressEnter to continue...\n");
            Console.ReadLine();
            Console.WriteLine("For some, it's about revenge against old enemies; for others, it's about the promise of unimaginable power or ancient knowledge. In this world, new pirates will rise, their fates tied to those of their predecessors as they strive either to finish what was left undone—or to surpass their masters entirely. With a play of power and curses, players set sail in this enormous, and unforgiving seas. They have to manage their resources, build their ships, and live in these dangers. The sea is dangerous by itself, as stormy winds, other rival pirate groups, and other sea-beast monsters in its dark deep threaten survival.");
            Console.WriteLine("\nPressEnter to continue...\n");
            Console.ReadLine();
            Console.WriteLine("In a game filled with crests and troughs, players have to decide whether to push forward with the ever-mounting cost or find a way to break the curse. The ultimate victory means total power. It could come at the cost of lives—or even souls. Alliances and rival factions are constantly changing. Unravel the mystery and join in the race. Yet, in the end, it all comes down to this final question: will the captain succumb to the curse of the pirate or become the greatest pirate of all? \r\n");
            Console.WriteLine("\nPressEnter to continue...\n");
            Console.ReadLine();
        }

        public static void Credits()
        {
            
            Console.WriteLine("\nReyn Penus");
            Console.WriteLine("Leader, Programmer");
            Console.WriteLine("Penus is the leader and programmer of the group. With both his technical and theoretical expertise in programming, he have lead the creation of the system. In addition, his leadership allowed the group to create and properly implement the developed game.\n");

            Console.WriteLine("Hannah Diamos");
            Console.WriteLine("Documentation");
            Console.WriteLine("Diamos works with the documentation. She helped with the design and documentation of the code for the game. She carefully made flowcharts to show how the game works, making it easier for the team to build it. Her ability to organize complex ideas into simple plans has been very helpful for the project.\n");

            Console.WriteLine("Kael Alegria");
            Console.WriteLine("Documentation");
            Console.WriteLine("Alegria works alongside Diamos to accomplish the documentation. He's also responsible for the creation of the data and stories included in the game. He also handles the testing and quality checking of the game.\n");

            Console.WriteLine("\nPressEnter to continue...\n");
            Console.ReadLine();
        }
    }
}