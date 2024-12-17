using System;
using System.Reflection;

namespace CharacterCreationSystem
{
    // Class containing methods to create the character
    public class Character
    {
        // Creates character based on user input
        public static object[] SetCharacter()
        {
            object[] informationArray = new object[
                Dictionaries.CharacterInfoTitles.GetLength(0) +
                Dictionaries.CharacterWeaponsTitles.GetLength(0) +
                Dictionaries.CharacterTraitTitles.GetLength(0) + 5
            ];

            int infoIndex = 0;

            Utility.DisplayHeader("SET CHARACTER");

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
                                break;
                            }
                            else
                            {
                                informationArray[infoIndex] = Utility.ValidateName(Utility.Validate(Console.ReadLine() ?? String.Empty, ' '));
                                break;
                            }
                        }
                        catch (Exception e) when (e is FormatException || e is OptionUnavailableException || e is NameUnavailableException  || e is ArgumentException)
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
        // Method for choice confirmation 
        public static void ConfirmChoices(object[] informationArray)
        {
            bool edit = true;
            Pirate pirate;
            while (edit)
            {
                Utility.DisplayHeader("CONFIRM CHOICES");
                CharacterDisplay.DisplayChoices(Dictionaries.dictionaries, informationArray);
                Utility.Divider('=');
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
                            Database.AddToLocalDatabase(pirate);
                            SQLConnection.AddToSQLDatabase(pirate);
                            Utility.DisplayHeader("CHARACTER SUCCESSFULLY CREATED");
                            CharacterDisplay.ShowPirate(pirate);
                            Utility.EnterToContinue();
                            edit = false;
                            break;
                        case 2:
                            Utility.DisplayHeader("EDITING CHARACTER");
                            pirate = CreateCharacter(EditChoice(informationArray));
                            break;
                        case 3:
                            edit = false;
                            break;
                        default:
                            throw new OptionUnavailableException($"{VAction} is not in the options!");
                    }
                }
                catch (Exception e) when (e is OptionUnavailableException || e is FormatException)
                {
                    Utility.DisplayErrorMessage(e.Message);
                }
            }
        }
        // Allows user to edit character traits before saving to database
        public static object[] EditChoice(object[] informationArray)
        {
            Dictionaries myDictionaries = new Dictionaries();
            PropertyInfo[] properties = myDictionaries.GetType().GetProperties();
            Utility.DisplayHeader("EDITING CHOICES");
            CharacterDisplay.DisplayChoices(Dictionaries.dictionaries, informationArray);

            while (true)
            {
                try
                {
                    Utility.Divider('=');
                    int VAction = Utility.Validate(Utility.GetInput("Edit Trait"), 1);
                    Console.WriteLine();
                    if (VAction == 1)
                    {
                        while (true)
                        {
                            try
                            {
                                string newChoice = Utility.ValidateName(Utility.Validate(Utility.GetInput("\nEnter New Trait"), ' '));
                                informationArray[VAction - 1] = newChoice;
                                break;
                            } catch (Exception e) when (e is ArgumentException || e is NameUnavailableException)
                            {
                                Console.WriteLine($"\n{e.Message}\n");
                            }
                        }
                    }
                    else if (VAction > 1 && VAction < properties.Length + 2)
                    {
                        Dictionary<int, Element> dictionary = (Dictionary<int, Element>)properties[VAction - 2].GetValue(myDictionaries);

                        while (true)
                        {
                            try
                            {
                                DictionaryDisplay.DisplayDictionary(dictionary);
                                int newChoice = Utility.Validate(Utility.GetInput("Enter New Trait"), 1);

                                Element element = DictionaryDisplay.GetElement(dictionary, newChoice);
                                informationArray[VAction - 1] = element;
                                break;
                            } 
                            catch(Exception e) when (e is FormatException || e is OptionUnavailableException)
                            {
                                Utility.DisplayErrorMessage(e.Message);
                            }
                        }
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
            catch (Exception)
            {
                throw new Exception("Character Creation Unsuccessful");
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
