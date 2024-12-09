using System;

namespace CharacterCreationSystem
{
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
        
    }
}
