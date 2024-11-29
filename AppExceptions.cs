using System;

namespace CharacterCreationSystem
{
    public class OptionUnavailableException : Exception
    {
        public OptionUnavailableException(String message) : base(message)
        {
        }
    }
}
