using System;

namespace CharacterCreationSystem
{
    public class OptionUnavailableException : Exception
    {
        public OptionUnavailableException(String message) : base(message)
        {
            
        }

        
    }

    public class DatabaseEmptyException : Exception
    {
        public DatabaseEmptyException(String message) : base(message)
        {
         
        }
    }

    public class NameUnavailableException: Exception
    {
        public NameUnavailableException(String message) : base(message)
        {
            
        }
    }


}
