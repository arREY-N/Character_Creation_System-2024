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
            catch (FormatException)
            {
                throw new FormatException(":::::Input must be a valid number!:::::");
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

    // Class containing methods to create the character
    public class Character
    {
        // Creates character based on user input
        public static object[] SetCharacter()
        {
            object[] informationArray = new object[
                Dictionaries.CharacterInfoTitles.GetLength(0) +
                Dictionaries.CharacterWeaponsTitles.GetLength(0) +
                Dictionaries.CharacterTraitTitles.GetLength(0)
            ];

            object[] dbInformationArray = new object[
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
                    Dictionary<int, Element> dictionary = DictionaryDisplay.DisplayInformation(infoArray, i);

                    while (true)
                    {
                        try
                        {
                            if (dictionary != null)
                            {
                                int VAction = Utility.Validate(Console.ReadLine() ?? String.Empty, 1);
                                informationArray[infoIndex] = DictionaryDisplay.GetElement(dictionary, VAction);
                                dbInformationArray[infoIndex] = VAction;
                                break;
                            }
                            else
                            {
                                informationArray[infoIndex] = Utility.Validate(Console.ReadLine() ?? String.Empty, ' ');
                                dbInformationArray[infoIndex] = informationArray[infoIndex];
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

            object[] dataPackage = { informationArray, dbInformationArray };

            return dataPackage;
        }
        // Creates character based on database input
        public static object[] SetCharacter(object[] databaseInformationArray)
        {
            object[] informationArray = new object[
                Dictionaries.CharacterInfoTitles.GetLength(0) +
                Dictionaries.CharacterWeaponsTitles.GetLength(0) +
                Dictionaries.CharacterTraitTitles.GetLength(0)
            ];

            int infoIndex = 0;

            foreach (object[,] infoArray in Dictionaries.dictionaries)
            {
                for (int i = 0; i < infoArray.GetLength(0); i++)
                {
                    Dictionary<int, Element> dictionary = DictionaryDisplay.GetDictionary(infoArray, i);

                    while (true)
                    {
                        object data = databaseInformationArray[infoIndex];
                        try
                        {
                            if (dictionary != null)
                            {
                                informationArray[infoIndex] = DictionaryDisplay.GetElement(dictionary, Convert.ToInt32(data));
                                break;
                            }
                            else
                            {
                                informationArray[infoIndex] = Convert.ToString(data);
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
                }
            }
            return informationArray;
        }
        // Method for choice confirmation 
        public static void ConfirmChoices(object[] informationArray)
        {
            bool edit = true;
            Pirate pirate;
            while (edit)
            {
                CharacterDisplay.DisplayChoices(Dictionaries.dictionaries, informationArray);

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
                            pirate = CreateCharacter(informationArray);
                            edit = false;
                            Database.AddToDatabase(pirate);
                            Console.WriteLine("\n:::::Character Creation Successful!:::::");
                            CharacterDisplay.ShowPirate(pirate);
                            CharacterDisplay.ShowStats(pirate);
                            Utility.EnterToContinue();
                            break;
                        case 2:
                            Console.WriteLine("\n >>>>> EDITING CHARACTER! <<<<<\n");
                            pirate = CreateCharacter(EditChoice(informationArray));
                            break;
                        case 3:
                            Console.Clear();
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
        // Allows user to edit character traits before saving to database
        public static object[] EditChoice(object[] informationArray)
        {
            Dictionaries myDictionaries = new Dictionaries();
            PropertyInfo[] properties = myDictionaries.GetType().GetProperties();

            CharacterDisplay.DisplayChoices(Dictionaries.dictionaries, informationArray);

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
                    else if (VAction > 1 && VAction < properties.Length + 2)
                    {
                        Dictionary<int, Element> dictionary = (Dictionary<int, Element>)properties[VAction - 2].GetValue(myDictionaries);

                        DictionaryDisplay.DisplayDictionary(dictionary);
                        int newChoice = Utility.Validate(Utility.GetInput("Enter New Trait"), 1);

                        Element element = DictionaryDisplay.GetElement(dictionary, newChoice);
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

            Element[] boosterArray = {
                moonCycle, form, mainWeapon, secondarySkill, natureSkill, additionalSkill,
                physicalTrademark, skinTone, hairStyle, facialHair, baseClothing,
                accessory, pirateOrigin, shipSize, shipType, pet, crew, trigger, debuff
            };

            Pirate? pirate = null;
            try
            {
                switch (secondarySkill.Name)
                {
                    case "Necromancy":
                        pirate = new NecromancyPirate();
                        break;
                    case "Blood Magic":
                        pirate = new BloodMagicPirate();
                        break;
                    case "Transmutation":
                        pirate = new TransmutationPirate();
                        break;
                    case "Alchemy":
                        pirate = new AlchemyPirate();
                        break;
                    case "Teleportation":
                        pirate = new TeleportationPirate();
                        break;
                    default:
                        throw new Exception();
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

                foreach (Element element in boosterArray)
                {
                    GetBoost(pirate, element);
                }
            }
            catch (Exception e)
            {
                throw new Exception(":::::Character Creation Unsuccessful:::::\n" + e.Message);
            }
            return pirate;
        }
        public static void GetBoost(Pirate pirate, Element element)
        {
            pirate.CharacterStats.Agility += element.AgilityBoost;
            pirate.CharacterStats.Charisma += element.CharismaBoost;
            pirate.CharacterStats.Health += element.HealthBoost;
            pirate.CharacterStats.Intelligence += element.IntelligenceBoost;
            pirate.CharacterStats.Strength += element.StrengthBoost;
        }
    }
}