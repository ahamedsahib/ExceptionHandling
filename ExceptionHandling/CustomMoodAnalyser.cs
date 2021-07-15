using System;
namespace ExceptionHandling
{
    public class CustomMoodAnalyserException:Exception
    {
        ExceptionType type;

        public enum ExceptionType
        {
            NULL_EXCEPTION,EMPTY_EXCEPTION,CLASS_NOT_FOUND,CONSTRUCTOR_NOT_FOUND
        }
        public CustomMoodAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    } 
}
