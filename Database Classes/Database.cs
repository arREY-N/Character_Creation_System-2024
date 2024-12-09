using System;
using System.Collections.Generic;


namespace CharacterCreationSystem
{ 
    public class Database
    {
        public static Dictionary<string, Pirate> pirateDictionary { get; set; } = [];
        public static List<Pirate> pirateList { get; set; } = [];    

        // Adds pirate to local databases
        public static void AddToLocalDatabase(Pirate pirate)
        {
            try
            {
                pirateDictionary.Add(pirate.CharacterInfo.Name, pirate);
                pirateList.Add(pirate);
            }
            catch (Exception e)
            {
                Utility.DisplayErrorMessage(e.Message);
            }
        }
        // Removes pirate from local databases
        public static void RemoveFromLocalDatabase(Pirate pirate)
        {
            try
            {
                pirateDictionary.Remove(pirate.CharacterInfo.Name);
                pirateList.Remove(pirate);
            } 
            catch (Exception e)
            {
                Utility.DisplayErrorMessage(e.Message);
            }
            
        }
        
        // Returns the pirate from the local database
        public static Pirate GetPirate(int index)
        {
            if(index <= pirateList.Count && index > 0)
            {
                return pirateList[index - 1];
            } else
            {
                throw new OptionUnavailableException($"{index} not found in the options!");
            }   
        }
    }
}