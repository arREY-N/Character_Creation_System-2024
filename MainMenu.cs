using System;
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
                Console.WriteLine("[Enter Game Name Here]\n");

                Console.WriteLine("| 1 | New Game");
                Console.WriteLine("| 2 | Load Game");
                Console.WriteLine("| 3 | Campaign Mode");
                Console.WriteLine("| 4 | Credits");
                Console.WriteLine("| 5 | Exit");
                Console.Write("Enter Action >>> ");
                
                try
                {
                    VAction = Utility.Validate(Console.ReadLine() ?? String.Empty, 1);

                    switch (VAction)
                    {
                        case 1:
                            SetCharacter();
                            break;
                        case 2:
                            Console.WriteLine("\n[LOAD GAME]");
                            break;
                        case 3:
                            Console.WriteLine("\n[CAMPAIGN MODE]");
                            break;
                        case 4:
                            Console.WriteLine("\n[CREDITS]");
                            break;
                        case 5:
                            Console.WriteLine("Thank you! Goodbye!");
                            Environment.Exit(0);
                            break;
                        default:
                            throw new OptionUnavailableException($"{VAction} is not in the options!");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
                catch (OptionUnavailableException e)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
        }

        public static void SetCharacter()
        {
            string? name;

            object[] infoArray = new object[4];

            Console.WriteLine("\n==Create Your Pirate!==");

            Console.Write("\nWhat is the name of your pirate? (Maximum of 20 ALPHANUMERIC CHARACTERS ONLY)\n");
            while (true)
            {
                Console.Write("Pirate Name: ");
                try
                {
                    string VAction = Utility.Validate(Console.ReadLine() ?? String.Empty, "");
                    name = (VAction.Length <= 20 && VAction.Length > 0) ? VAction :  throw new FormatException("Maximum of 20 characters only!");
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
            
            for(int i = 0; i < Dictionaries.PirateDictionaries.Length; i++)
            {
                foreach (KeyValuePair<int, string[]> Element in Dictionaries.PirateDictionaries[i])
                {
                    Console.WriteLine($"| {Element.Key} | {Element.Value[0],-17} | {Element.Value[1]}");
                }

                while (true)
                {
                    Console.Write("Choice: ");
                    try
                    {
                        int VAction = Utility.Validate(Console.ReadLine() ?? String.Empty, 1);
                        if (VAction <= Dictionaries.PirateDictionaries[i].Count && VAction > 0)
                        {
                            infoArray[i] = Dictionaries.PirateDictionaries[i][VAction][0];
                            break;
                        }
                        else
                        {
                            throw new OptionUnavailableException($"{VAction} is not in the options!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"\n{e.Message}\n");
                    }
                    catch (OptionUnavailableException e)
                    {
                        Console.WriteLine($"\n{e.Message}\n");
                    }
                }
            }
            // moon cycle, form, type, code output
            // moon cycle, form, code, type code
            string? moonCycle = Convert.ToString(infoArray[0]);
            string? form = Convert.ToString(infoArray[1]);
            string? pirateType = Convert.ToString(infoArray[2]);
            bool pirateCode = (infoArray[3] == "Yes") ? true : false;
            
            try
            {
                Console.WriteLine();
                Pirate pirate = CreateCharacter(name, moonCycle, form, pirateCode, pirateType);
                
                ShowCharacter(pirate);

                SetCharacteristics(pirate);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}\n");
            }
            Console.WriteLine();
            
        }

        public static Pirate CreateCharacter(string name, string moonCycle, string form, bool pirateCode, string pirateType)
        {
            Pirate? pirate = null;
            try
            {
                switch (pirateType)
                {
                    case "Necromancy":
                        pirate = new NecromancyPirate(name, moonCycle, form, pirateCode, pirateType);
                        break;
                    case "Blood Magic":
                        pirate = new BloodMagicPirate(name, moonCycle, form, pirateCode, pirateType);
                        break;
                    case "Transmutation":
                        pirate = new TransmutationPirate(name, moonCycle, form, pirateCode, pirateType);
                        break;
                    case "Alchemy":
                        pirate = new AlchemyPirate(name, moonCycle, form, pirateCode, pirateType);
                        break;
                    case "Teleportation":
                        pirate = new TeleportationPirate(name, moonCycle, form, pirateCode, pirateType);
                        break;
                }
                Console.WriteLine($"\nCongratulations! New Pirate Created!\n");
            } 
            catch (Exception)
            {
                throw new Exception("Character Creation Unsuccessful");
            }
            return pirate;
        }

        public static void SetCharacteristics(Pirate pirate)
        {
            object[] traitsArray = new object[Dictionaries.TraitsDictionaries.Length];
            Console.WriteLine(Dictionaries.TraitsDictionaries.Length);
            for (int j = 0; j < Dictionaries.TraitsDictionaries.Length; j++)
            {
                foreach (KeyValuePair<int, object[]> Element in Dictionaries.TraitsDictionaries[j])
                {
                    Console.WriteLine($"| {Element.Key} | {Element.Value[0],-30} | {Element.Value[1]}");
                }

                while (true)
                {
                    Console.Write("Choice: ");
                    try
                    {
                        int VAction = Utility.Validate(Console.ReadLine() ?? String.Empty, 1);
                        if (VAction <= Dictionaries.TraitsDictionaries[j].Count && VAction > 0)
                        {
                            traitsArray[j] = Dictionaries.TraitsDictionaries[j][VAction][0];
                            break;
                        }
                        else
                        {
                            throw new OptionUnavailableException($"{VAction} is not in the options!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"\n{e.Message}\n");
                    }
                    catch (OptionUnavailableException e)
                    {
                        Console.WriteLine($"\n{e.Message}\n");
                    }
                }
            }

            foreach(object obj in traitsArray)
            {
                Console.WriteLine(obj);
            }
        }
        public static void ShowCharacter(Pirate pirate)
        {
            Console.WriteLine($"Name: {pirate.CharacterInfo.Name}");
            Console.WriteLine($"Moon Cycles: {pirate.CharacterInfo.MoonCycles}");
            Console.WriteLine($"Form: {pirate.CharacterInfo.Form}");
            Console.WriteLine($"Pirate Code: {pirate.CharacterInfo.PirateCode}");
            Console.WriteLine($"Type: {pirate.CharacterInfo.PirateType}\n");
        }
    }
}