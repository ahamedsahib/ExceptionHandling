using System;
namespace ExceptionHandling
{
    public class MoodAnalyser
    {
        
        public string AnalyseMood(string message)
        {
            if (message.ToLower().Contains("happy"))
            {
                return "happy";
            }
            else
            {
                return "sad";
            }
        }
    }
}
