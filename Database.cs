using System;
using System.Collections.Generic;

namespace CharacterCreationSystem
{ 
    public class Database
    {
        public static Dictionary<string, Pirate> pirateDictionary { get; set; } = [];
        public static List<Pirate> pirateList { get; set; } = [];    

        public static void AddToDatabase(Pirate pirate)
        {
            try
            {
                pirateDictionary.Add(pirate.CharacterInfo.Name, pirate);
                pirateList.Add(pirate);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n:::::Error adding to database!:::::\n" + e.Message);
            }
        }

        public static void RemoveFromDatabase(Pirate pirate)
        {
            try
            {
                pirateDictionary.Remove(pirate.CharacterInfo.Name);
                pirateList.Remove(pirate);
            } 
            catch (Exception e)
            {
                Console.WriteLine("\n:::::Error removing from database!:::::\n" + e.Message);
            }
            
        }

        public static void ViewDatabase()
        {
            int i = 0;
            Console.WriteLine($"\n{"Pirate Name", -15}");

            if(pirateDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, Pirate> pirate in pirateDictionary)
                {
                    Console.WriteLine($"| {i + 1,-2} | {pirate.Key} ");
                    i++;
                }
            } else
            {
                throw new DatabaseEmptyException(":::::The database doensn't contain any entries!:::::");
            }
        } 

        public static Pirate GetPirate(int index)
        {
            if(index <= pirateList.Count && index > 0)
            {
                return pirateList[index - 1];
            } else
            {
                throw new OptionUnavailableException($":::::{index} not found in the options!:::::");
            }   
        }
    }
}