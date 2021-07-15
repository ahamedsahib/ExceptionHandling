using System;
namespace ExceptionHandling
{
    public class MoodAnalyser
    {
        string message;
        public MoodAnalyser()
        {
            Console.WriteLine("Default Constructor is invoked");
        }
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                if (message.Equals(string.Empty))
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.EMPTY_EXCEPTION, "Mood can't be Empty");
                }
                else if (message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "sad";
                }
            }catch(NullReferenceException ex)
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Mood can't be Null");
            }
        }
    }
}
