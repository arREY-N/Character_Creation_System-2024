using System;
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
                throw new FormatException(":::::Input must be a valid integer number!:::::");
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
                throw new FormatException(":::::Only alphanumeric characters are allowed in the input!:::::");
            }
            return text ?? throw new Exception(":::::Empty string!:::::");
        }
        // Program buffer
        public static void EnterToContinue()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.Write("\nPress enter to continue... ");
            Console.ReadKey();
            Console.Clear();
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
                throw new OptionUnavailableException($":::::{index} not found in the options!:::::");
            }
        }
        // Allows user to select a pirate character from the list of pirates
        public static Pirate GetPirateFromList()
        {
            Pirate pirate;
            Database.ViewDatabase();
            pirate = Database.GetPirate(Utility.Validate(Utility.GetInput("Enter Pirate Number"), 1));
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
            Console.WriteLine("Character Traits");
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
            Console.WriteLine("\nCHARACTER STATS\n");
            Console.WriteLine($"    | Health             | {pirate.CharacterStats.Health}");
            Console.WriteLine($"    | Strength           | {pirate.CharacterStats.Strength}");
            Console.WriteLine($"    | Agility            | {pirate.CharacterStats.Agility}");
            Console.WriteLine($"    | Intelligence       | {pirate.CharacterStats.Intelligence}");
            Console.WriteLine($"    | Charisma           | {pirate.CharacterStats.Charisma}\n");
        }

        // Displays the information regarding the character
        public static void ShowPirate(Pirate pirate)
        {
            Console.Clear();
            Console.WriteLine("\nCHARACTER TRAITS\n");
            Console.WriteLine($"    | Name               | {pirate.CharacterInfo.Name}");
            Console.WriteLine($"    | Moon Cycles        | {pirate.CharacterInfo.MoonCycles.Name}");
            Console.WriteLine($"    | Form               | {pirate.CharacterInfo.Form.Name}");
            Console.WriteLine($"    | Pirate Code        | {pirate.CharacterInfo.PirateCode.ToString()}");
            Console.WriteLine($"    | Main Weapon        | {pirate.CharacterWeapons.MainWeapon.Name}");
            Console.WriteLine($"    | Secondary Skill    | {pirate.CharacterWeapons.SecondarySkill.Name}");
            Console.WriteLine($"    | Nature Skill       | {pirate.CharacterWeapons.NatureSkill.Name}");
            Console.WriteLine($"    | Additional Skill   | {pirate.CharacterWeapons.AdditionalSkill.Name}");
            Console.WriteLine($"    | Physical Trademark | {pirate.CharacterTraits.PhysicalTrademark.Name}");
            Console.WriteLine($"    | Skin Tone          | {pirate.CharacterTraits.SkinTone.Name}");
            Console.WriteLine($"    | Hair Style         | {pirate.CharacterTraits.HairStyle.Name}");
            Console.WriteLine($"    | Facial Hair        | {pirate.CharacterTraits.FacialHair.Name}");
            Console.WriteLine($"    | Base Clothing      | {pirate.CharacterTraits.BaseClothing.Name}");
            Console.WriteLine($"    | Accessory          | {pirate.CharacterTraits.Accessory.Name}");
            Console.WriteLine($"    | Pirate Origin      | {pirate.CharacterTraits.PirateOrigin.Name}");
            Console.WriteLine($"    | Ship Type          | {pirate.CharacterTraits.ShipType.Name}");
            Console.WriteLine($"    | Shipe Size         | {pirate.CharacterTraits.ShipSize.Name}");
            Console.WriteLine($"    | Pet                | {pirate.CharacterTraits.Pet.Name}");
            Console.WriteLine($"    | Crew               | {pirate.CharacterTraits.Crew.Name}");
            Console.WriteLine($"    | Trigger            | {pirate.CharacterTraits.Trigger.Name}");
            Console.WriteLine($"    | Debuff             | {pirate.CharacterTraits.Debuff.Name}");
        }
    }
}