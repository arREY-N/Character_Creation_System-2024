using System;
using System.Text.RegularExpressions;

namespace CharacterCreationSystem
{
    public class Utility
    {
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
            catch (FormatException)
            {
                throw new FormatException("Input must be a valid number!");
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

        // Returns chosen element
        public static Element GetElement(Dictionary<int, Element> dictionary, int index)
        {
            if(dictionary.TryGetValue(index, out Element element))
            {
                return element;
            } else
            {
                throw new OptionUnavailableException($"{index} not found in the options!");
            }
        }

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

        // Displays the trait options within a dictionary
        public static void DisplayDictionary(Dictionary<int, Element> dictionary)
        {
            foreach (KeyValuePair<int, Element> Item in dictionary)
            {
                Console.WriteLine($"| {Item.Key,-2} | {Item.Value.Name,-17} | {Item.Value.Description}");
            }
        }

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

        // Creates the game character
        public static Pirate CreateCharacter(object[] informationArray)
        {
            string? name = Convert.ToString(informationArray[0]);
            Element moonCycle = ((Element)informationArray[1]);
            Element form = ((Element)informationArray[2]);
            bool pirateCode = ((Element)informationArray[3]).Name == "Yes" ? true : false;
            Element mainWeapon = ((Element)informationArray[4]);
            Element secondarySkill = ((Element)informationArray[5]);
            Element natureSkill = ((Element)informationArray[6]);
            Element additionalSkill = ((Element)informationArray[7]);
            Element physicalTrademark = ((Element)informationArray[8]);
            Element skinTone = ((Element)informationArray[9]);
            Element hairStyle = ((Element)informationArray[10]);
            Element facialHair = ((Element)informationArray[11]);
            Element baseClothing = ((Element)informationArray[12]);
            Element accessory = ((Element)informationArray[13]);
            Element pirateOrigin = ((Element)informationArray[14]);
            Element shipType = ((Element)informationArray[15]);
            Element shipSize = ((Element)informationArray[16]);
            Element pet = ((Element)informationArray[17]);
            Element crew = ((Element)informationArray[18]);
            Element trigger = ((Element)informationArray[19]);
            Element debuff = ((Element)informationArray[20]);

            Pirate? pirate = null;
            try
            {
                switch (secondarySkill.Name)
                {
                    case "Necromancy":
                        pirate = new NecromancyPirate(secondarySkill);
                        break;
                    case "Blood Magic":
                        pirate = new BloodMagicPirate(secondarySkill);
                        break;
                    case "Transmutation":
                        pirate = new TransmutationPirate(secondarySkill);
                        break;
                    case "Alchemy":
                        pirate = new AlchemyPirate(secondarySkill);
                        break;
                    case "Teleportation":
                        pirate = new TeleportationPirate(secondarySkill);
                        break;
                    default:
                        Console.WriteLine("na-def");
                        break;
                }
                pirate.CharacterInfo = new CharacterInfo(name, moonCycle, form, pirateCode);
                pirate.CharacterWeapons.MainWeapon = mainWeapon;
                pirate.CharacterWeapons.SecondarySkill = secondarySkill;
                pirate.CharacterWeapons.NatureSkill = natureSkill;
                pirate.CharacterWeapons.AdditionalSkill = additionalSkill;
                pirate.CharacterTraits.PhysicalTrademark = physicalTrademark;
                pirate.CharacterTraits.SkinTone = skinTone;
                pirate.CharacterTraits.HairStyle = hairStyle;
                pirate.CharacterTraits.FacialHair = facialHair;
                pirate.CharacterTraits.BaseClothing = baseClothing;
                pirate.CharacterTraits.Accessory = accessory;
                pirate.CharacterTraits.PirateOrigin = pirateOrigin;
                pirate.CharacterTraits.ShipType = shipType;
                pirate.CharacterTraits.ShipSize = shipSize;
                pirate.CharacterTraits.Pet = pet;
                pirate.CharacterTraits.Crew = crew;
                pirate.CharacterTraits.Trigger = trigger;
                pirate.CharacterTraits.Debuff = debuff;
            }
            catch (Exception e)
            {
                throw new Exception("Character Creation Unsuccessful: " + e.Message);
            }
            return pirate;
        }

        // Displays the information regarding the character
        public static void ShowPirate(Pirate pirate)
        {
            Console.WriteLine("\nCHARCTER TRAITS\n");
            Console.WriteLine($"    | Name:               | {pirate.CharacterInfo.Name}");
            Console.WriteLine($"    | Moon Cycles:        | {pirate.CharacterInfo.MoonCycles.Name}");
            Console.WriteLine($"    | Form:               | {pirate.CharacterInfo.Form.Name}");
            Console.WriteLine($"    | Pirate Code:        | {pirate.CharacterInfo.PirateCode.ToString()}");
            Console.WriteLine($"    | Main Weapon:        | {pirate.CharacterWeapons.MainWeapon.Name}");
            Console.WriteLine($"    | Secondary Skill:    | {pirate.CharacterWeapons.SecondarySkill.Name}");
            Console.WriteLine($"    | Nature Skill:       | {pirate.CharacterWeapons.NatureSkill.Name}");
            Console.WriteLine($"    | Additional Skill:   | {pirate.CharacterWeapons.AdditionalSkill.Name}");
            Console.WriteLine($"    | Physical Trademark: | {pirate.CharacterTraits.PhysicalTrademark.Name}");
            Console.WriteLine($"    | Skin Tone:          | {pirate.CharacterTraits.SkinTone.Name}");
            Console.WriteLine($"    | Hair Style:         | {pirate.CharacterTraits.HairStyle.Name}");
            Console.WriteLine($"    | Facial Hair:        | {pirate.CharacterTraits.FacialHair.Name}");
            Console.WriteLine($"    | Base Clothing:      | {pirate.CharacterTraits.BaseClothing.Name}");
            Console.WriteLine($"    | Accessory:          | {pirate.CharacterTraits.Accessory.Name}");
            Console.WriteLine($"    | Pirate Origin:      | {pirate.CharacterTraits.PirateOrigin.Name}");
            Console.WriteLine($"    | Ship Type:          | {pirate.CharacterTraits.ShipType.Name}");
            Console.WriteLine($"    | Shipe Size:         | {pirate.CharacterTraits.ShipSize.Name}");
            Console.WriteLine($"    | Pet:                | {pirate.CharacterTraits.Pet.Name}");
            Console.WriteLine($"    | Crew:               | {pirate.CharacterTraits.Crew.Name}");
            Console.WriteLine($"    | Trigger:            | {pirate.CharacterTraits.Trigger.Name}");
            Console.WriteLine($"    | Debuff:             | {pirate.CharacterTraits.Debuff.Name}\n");
        }
    }
}