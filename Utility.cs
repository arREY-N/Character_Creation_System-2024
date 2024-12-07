using System;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;

namespace CharacterCreationSystem
{
    // Class containing input and validation methods
    public class Utility
    {
        // Method to display action and get input
        public static string GetInput(string action)
        {
            Console.Write($"{action}: ");
            return Console.ReadLine() ?? String.Empty;
        }
        // Validation method for int input
        public static int Validate(String input, int key)
        {
            try
            {
                return Convert.ToInt32(input);
            } 
            catch (Exception e) when (e is FormatException || e is OverflowException)
            {
                throw new FormatException("Input must be a valid integer number!");
            }   
        }
        // Validation method for string input
        public static string Validate(String input, char key)
        {
            string? text;

            if (Regex.IsMatch(input, @"^[a-zA-Z0-9]+$"))
            {
                text = input;
            }
            else
            {
                throw new FormatException("Only alphanumeric characters are allowed in the input!");
            }
            return text ?? throw new Exception("Empty string!");
        }

        public static string ValidateName(string input)
        {
            string? name;

            if (Database.pirateDictionary.ContainsKey(input))
            {
                throw new NameUnavailableException("Name already found in the system, use another one!");
            } else if (input.Length < 4)
            {
                throw new ArgumentException("Name must be more than 4 characters long!");
            } 

            return input;
        }
        // Program buffer
        public static void EnterToContinue()
        {
            DisplayCenter("Press ENTER to continue...");
            Console.ReadKey();
            Console.Clear();
            Loading();
        }

        public static void Loading()
        {
            DisplayHeader("LOADING");
            Thread.Sleep(1000);
            Console.Clear();
        }
        // Displaying formatted error message
        public static void DisplayErrorMessage(string message)
        {
            Console.Clear();
            DisplayHeader(message);
            EnterToContinue();
        }

        public static void DisplayCenter(string text)
        {
            int LRmargin = (Console.WindowWidth - text.Length) / 2;
            int Wcenter = Console.WindowWidth / 2;
            string margin = new string(' ', LRmargin);
            string center = new string(' ', Wcenter);

            Console.Write($"\n{margin}{text}{margin}\n");
        }

        public static void DisplayHeader(string section)
        {
            Console.Clear();
            DisplayCenter("SeaPAG: A Sea Pirate Adventure Game");
            DisplayCenter("\u00A9 2024\n");
            Console.WriteLine(new string('=', Console.WindowWidth));
            DisplayCenter(section);
            Console.WriteLine();
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.WriteLine();
        }

        public static bool Confirm(int confirm)
        {
            switch (confirm)
            {
                case 1:
                    return true;
                    break;
                case 2:
                    return false;
                    break;
                default:
                    throw new OptionUnavailableException($"{confirm} is not in the option");
            }
        }
    }

    // Class containing methods to access game information from dictionaries
    public class DictionaryDisplay
    {
        // Displays the trait name, trait question, and calls the dictionary contents
        public static Dictionary<int, Element> DisplayInformation(object[,] information, int i)
        {
            string name = Convert.ToString(information[i, 0]);
            Dictionary<int, Element>? dictionary = information[i, 1] == null ? null : (Dictionary<int, Element>)information[i, 1];
            string question = Convert.ToString(information[i, 2]);

            Console.WriteLine(question);
            if (dictionary != null)
            {
                DisplayDictionary(dictionary);
            }
            Console.Write($"{name}: ");
            return dictionary;
        }
        // Displays the trait name, trait question, and calls the dictionary contents
        public static Dictionary<int, Element> GetDictionary(object[,] information, int i)
        {
            Dictionary<int, Element>? dictionary = information[i, 1] == null ? null : (Dictionary<int, Element>)information[i, 1];
            return dictionary;
        }
        // Displays the trait options within a dictionary
        public static void DisplayDictionary(Dictionary<int, Element> dictionary)
        {
            foreach (KeyValuePair<int, Element> Item in dictionary)
            {
                Console.WriteLine($"| {Item.Key,-2} | {Item.Value.Name,-17} | {Item.Value.Description}");
            }
        }
        // Returns chosen element
        public static Element GetElement(Dictionary<int, Element> dictionary, int index)
        {
            if (dictionary.TryGetValue(index, out Element element))
            {
                return element;
            }
            else
            {
                throw new OptionUnavailableException($"{index} not found in the options!");
            }
        }
        // Allows user to select a pirate character from the list of pirates
        public static Pirate GetPirateFromList()
        {
            Pirate pirate;
            Utility.DisplayHeader($"PIRATE LIST");
            Database.ViewDatabase();
            pirate = Database.GetPirate(Utility.Validate(Utility.GetInput("Enter Pirate Number"), 1));
            Utility.DisplayHeader($"ACCESSING '{pirate.CharacterInfo.Name}'");
            CharacterDisplay.ShowPirate(pirate);
            return pirate;
        }
    }

    // Class containing methods to display character information
    public class CharacterDisplay
    {
        // Displays the chosen traits of the user
        public static void DisplayChoices(object[] dictionaries, object[] informationArray)
        {
            Utility.DisplayHeader("CONFIRM CHOICES");
            int element = 0;
            foreach (object[,] infoArray in dictionaries)
            {
                for (int i = 0; i < infoArray.GetLength(0); i++)
                {
                    string name = Convert.ToString(infoArray[i, 0]);
                    string? elementName = (element > 0) ? ((Element)informationArray[element]).Name : Convert.ToString(informationArray[element]);
                    Console.WriteLine($"| {element + 1,-2} | {name,-20} | {elementName}");
                    element++;
                }
            }
        }
        // Displays the computed character stats
        public static void ShowStats(Pirate pirate)
        {
            Console.WriteLine($"\n S  | Health             | {pirate.CharacterStats.Health}");
            Console.WriteLine($" T  | Strength           | {pirate.CharacterStats.Strength}");
            Console.WriteLine($" A  | Agility            | {pirate.CharacterStats.Agility}");
            Console.WriteLine($" T  | Intelligence       | {pirate.CharacterStats.Intelligence}");
            Console.WriteLine($" S  | Charisma           | {pirate.CharacterStats.Charisma}\n");
        }

        // Displays the information regarding the character
        public static void ShowPirate(Pirate pirate)
        {
            Console.WriteLine($" C  | Name               | {pirate.CharacterInfo.Name}");
            Console.WriteLine($" H  | Moon Cycles        | {pirate.CharacterInfo.MoonCycles.Name}");
            Console.WriteLine($" A  | Form               | {pirate.CharacterInfo.Form.Name}");
            Console.WriteLine($" R  | Pirate Code        | {pirate.CharacterInfo.PirateCode.ToString()}");
            Console.WriteLine($" A  | Main Weapon        | {pirate.CharacterWeapons.MainWeapon.Name}");
            Console.WriteLine($" C  | Secondary Skill    | {pirate.CharacterWeapons.SecondarySkill.Name}");
            Console.WriteLine($" T  | Nature Skill       | {pirate.CharacterWeapons.NatureSkill.Name}");
            Console.WriteLine($" E  | Additional Skill   | {pirate.CharacterWeapons.AdditionalSkill.Name}");
            Console.WriteLine($" R  | Physical Trademark | {pirate.CharacterTraits.PhysicalTrademark.Name}");
            Console.WriteLine($"    | Skin Tone          | {pirate.CharacterTraits.SkinTone.Name}");
            Console.WriteLine($" T  | Hair Style         | {pirate.CharacterTraits.HairStyle.Name}");
            Console.WriteLine($" R  | Facial Hair        | {pirate.CharacterTraits.FacialHair.Name}");
            Console.WriteLine($" A  | Base Clothing      | {pirate.CharacterTraits.BaseClothing.Name}");
            Console.WriteLine($" I  | Accessory          | {pirate.CharacterTraits.Accessory.Name}");
            Console.WriteLine($" T  | Pirate Origin      | {pirate.CharacterTraits.PirateOrigin.Name}");
            Console.WriteLine($" S  | Ship Type          | {pirate.CharacterTraits.ShipType.Name}");
            Console.WriteLine($"    | Ship Size          | {pirate.CharacterTraits.ShipSize.Name}");
            Console.WriteLine($"    | Pet                | {pirate.CharacterTraits.Pet.Name}");
            Console.WriteLine($"    | Crew               | {pirate.CharacterTraits.Crew.Name}");
            Console.WriteLine($"    | Trigger            | {pirate.CharacterTraits.Trigger.Name}");
            Console.WriteLine($"    | Debuff             | {pirate.CharacterTraits.Debuff.Name}");
        }
    }
}