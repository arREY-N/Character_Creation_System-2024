using System;
using System.Text.RegularExpressions;

namespace CharacterCreationSystem
{
    public class Utility
    {
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

        public static string Validate(String input, string key)
        {
            string text = "";

            if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                text = input;
            }
            else
            {
                throw new FormatException("Only letters are allowed in the input!");
            }

            return text;
        }
    }
}