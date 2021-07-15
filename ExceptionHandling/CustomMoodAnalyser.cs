using System;
namespace ExceptionHandling
{
    public class CustomMoodAnalyserException:Exception
    {
        ExceptionType type;

        public enum ExceptionType
        {
            NULL_EXCEPTION,EMPTY_EXCEPTION
        }
        public CustomMoodAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    } 
}
