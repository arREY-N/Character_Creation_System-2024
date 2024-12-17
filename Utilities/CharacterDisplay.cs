using System;

namespace CharacterCreationSystem
{
    // Class containing methods to display character information
    public class CharacterDisplay
    {
        // Displays the chosen traits of the user
        public static void DisplayChoices(object[] dictionaries, object[] informationArray)
        {
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
        // Displays the information regarding the character
        public static void ShowPirate(Pirate pirate)
        {
            Utility.DisplayColumn($" C  | Name               | {pirate.CharacterInfo.Name}", $" S  | Health             | {pirate.CharacterStats.Health}");
            Utility.DisplayColumn($" H  | Moon Cycles        | {pirate.CharacterInfo.MoonCycles.Name}", $" T  | Strength           | {pirate.CharacterStats.Strength}");
            Utility.DisplayColumn($" A  | Form               | {pirate.CharacterInfo.Form.Name}", $" A  | Agility            | {pirate.CharacterStats.Agility}");
            Utility.DisplayColumn($" R  | Pirate Code        | {pirate.CharacterInfo.PirateCode}", $" T  | Intelligence       | {pirate.CharacterStats.Intelligence}");
            Utility.DisplayColumn($" A  | Main Weapon        | {pirate.CharacterWeapons.MainWeapon.Name}", $" S  | Charisma           | {pirate.CharacterStats.Charisma}");
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
            Console.WriteLine($"    | Debuff             | {pirate.CharacterTraits.Debuff.Name}\n");
            Utility.Divider('=');
        }
        // Displays all the pirates from the local database
        public static void ViewDatabase()
        {
            int i = 0;

            if (Database.pirateDictionary.Count > 0 && i < Database.pirateDictionary.Count)
            {
                foreach (KeyValuePair<string, Pirate> pirate in Database.pirateDictionary)
                {
                    Console.WriteLine($"| {i + 1,-2} | {pirate.Key} ");
                    i++;
                }
            }
            else
            {
                throw new DatabaseEmptyException("The database doensn't contain any entries!");
            }
        }
        // Allows user to select a pirate character from the list of pirates
        public static Pirate GetPirateFromList()
        {
            Utility.DisplayHeader("GET PIRATE");
            Pirate pirate;
            ViewDatabase();

            String VAction = Utility.GetInput("Enter Pirate Number (Enter 0 to go back to menu)");
            if (VAction != "0")
            {
                pirate = Database.GetPirate(Utility.Validate(VAction, 1));
                return pirate;
            }
            else
            {
                throw new BackTrackingException();
            }
        }
    }
}
