using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ExceptionHandling
{
    public class MoodAnalyseFactory
    {
       public Object CreateMoodAnalyserObject(string className,string constructor)
        {
            string pattern =   constructor + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalysertype = assembly.GetType(className);
                    var newObject = Activator.CreateInstance(moodAnalysertype);
                    return newObject;
                }
                catch (Exception e)
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class Not Found");
                }
            }
            else
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not Found");
            }



        }
    }
}
